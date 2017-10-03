using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Reflection;

namespace API.Specifics
{
    public class Serialization
    {
        #region JSON Serialization
        public static string ToJson(object Target)
        {
            var s = new System.Web.Script.Serialization.JavaScriptSerializer();
            s.MaxJsonLength = int.MaxValue; //Change to Max Length  (Huge 4 MB!!!)

            if (Target != null && Target.GetType().Equals(typeof(System.Data.DataSet)))
            {
                #region Serializacion Especial para un Dataset
                System.Data.DataSet dsToFragment = (System.Data.DataSet)Target;

                List<JsonTable> JsonDataset = new List<JsonTable>();
                foreach (System.Data.DataTable dtable in dsToFragment.Tables)
                {
                    JsonTable _jsonTable = new JsonTable();

                    //--------------------------------------------------------------------------------------------------
                    //----[ Add Reference to Columns
                    _jsonTable.columns = new List<JsonTable.JsonColumn>();
                    foreach (System.Data.DataColumn col in dtable.Columns)
                    {
                        JsonTable.JsonColumn column = new JsonTable.JsonColumn();
                        column.datattype = col.DataType.ToString();
                        column.name = col.ColumnName;
                        _jsonTable.columns.Add(column);
                    }
                    //--------------------------------------------------------------------------------------------------


                    //--------------------------------------------------------------------------------------------------
                    //----[ Add rows data
                    _jsonTable.rows = new List<object[]>();
                    foreach (System.Data.DataRow row in dtable.Rows)
                    {
                        _jsonTable.rows.Add(row.ItemArray);
                    }
                    //--------------------------------------------------------------------------------------------------


                    JsonDataset.Add(_jsonTable);
                }
                return (s).Serialize(JsonDataset);
                #endregion
            }
            else
            {
                return (s).Serialize(Target);
            }
        }

        public static T FromJson<T>(string json)
        {

            var s = new System.Web.Script.Serialization.JavaScriptSerializer();
            s.MaxJsonLength = int.MaxValue; //Change to Max Length  (Huge 4 MB!!!)

            if (typeof(T).Equals(typeof(System.Data.DataSet)))
            {
                #region Serializacion Especial para un Dataset
                List<JsonTable> jsonDataset = s.Deserialize<List<JsonTable>>(json);

                System.Data.DataSet ds = new System.Data.DataSet();

                foreach (JsonTable jsonTable in jsonDataset)
                {
                    System.Data.DataTable table = ds.Tables.Add();
                    foreach (JsonTable.JsonColumn jcolumn in jsonTable.columns)
                    {
                        table.Columns.Add(jcolumn.name, Type.GetType(jcolumn.datattype));
                    }

                    foreach (object[] jrow in jsonTable.rows)
                    {
                        System.Data.DataRow row = table.NewRow();
                        row.ItemArray = jrow;
                        table.Rows.Add(row);
                    }
                }

                return (T)Convert.ChangeType(ds, typeof(T));
                #endregion
            }
            else
            {
                return s.Deserialize<T>(json);
            }
        }
        #endregion
        
    }

    internal class JsonTable
    {
        public List<JsonColumn> columns { get; set; }
        public List<object[]> rows { get; set; }

        public class JsonColumn
        {
            public string datattype { get; set; }
            public string name { get; set; }
        }
    }
}
