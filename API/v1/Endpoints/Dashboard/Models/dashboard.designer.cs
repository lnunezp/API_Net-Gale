﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Endpoints.Dashboard.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BD_Base")]
	public partial class dashboardDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertCXC(CXC instance);
    partial void UpdateCXC(CXC instance);
    partial void DeleteCXC(CXC instance);
    #endregion
		
		public dashboardDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["BD_BaseConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dashboardDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dashboardDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dashboardDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dashboardDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CXC> CXC
		{
			get
			{
				return this.GetTable<CXC>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="V_CXC")]
	public partial class CXC : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _ATTORNEY;
		
		private int _VALUECXC;
		
		private int _VALUEPERCENT;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnlabelChanging(string value);
    partial void OnlabelChanged();
    partial void OnvalueChanging(int value);
    partial void OnvalueChanged();
    partial void OnpercentageChanging(int value);
    partial void OnpercentageChanged();
    #endregion
		
		public CXC()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="ABOGADO", Storage="_ATTORNEY", CanBeNull=false, IsPrimaryKey=true)]
		public string label
		{
			get
			{
				return this._ATTORNEY;
			}
			set
			{
				if ((this._ATTORNEY != value))
				{
					this.OnlabelChanging(value);
					this.SendPropertyChanging();
					this._ATTORNEY = value;
					this.SendPropertyChanged("label");
					this.OnlabelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="CXC", Storage="_VALUECXC")]
		public int value
		{
			get
			{
				return this._VALUECXC;
			}
			set
			{
				if ((this._VALUECXC != value))
				{
					this.OnvalueChanging(value);
					this.SendPropertyChanging();
					this._VALUECXC = value;
					this.SendPropertyChanged("value");
					this.OnvalueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="PORCENT", Storage="_VALUEPERCENT")]
		public int percentage
		{
			get
			{
				return this._VALUEPERCENT;
			}
			set
			{
				if ((this._VALUEPERCENT != value))
				{
					this.OnpercentageChanging(value);
					this.SendPropertyChanging();
					this._VALUEPERCENT = value;
					this.SendPropertyChanged("percentage");
					this.OnpercentageChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591