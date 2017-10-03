using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Specifics.Configuration
{
    /// text
    public static class Get
    {
        /// text
        public static Models.Config GetConfiguration(String NameConfiguration, Gale.Db.IDataActions dataActions)
        {
            using (Gale.Db.DataService svc = new Gale.Db.DataService("PA_MAE_SEL_Configuracion"))
            {
                svc.Parameters.Add("@CONF_Nombre", NameConfiguration);

                Gale.Db.EntityRepository rep = dataActions.ExecuteQuery(svc);

                Models.Config result = rep.GetModel<Models.Config>().FirstOrDefault();
                return result;
            }
        }

        /// text
        public static Models.Config GetConfiguration(Nullable<Guid> token, Gale.Db.IDataActions dataActions)
        {
            using (Gale.Db.DataService svc = new Gale.Db.DataService("PA_MAE_SEL_Configuracion"))
            {
                if (token != null)
                {
                    svc.Parameters.Add("@DOCU_Token", token);
                }
                svc.Parameters.Add("@CONF_Nombre", DBNull.Value);

                Gale.Db.EntityRepository rep = dataActions.ExecuteQuery(svc);

                Models.Config result = rep.GetModel<Models.Config>().FirstOrDefault();
                return result;
            }
        }
    }
}