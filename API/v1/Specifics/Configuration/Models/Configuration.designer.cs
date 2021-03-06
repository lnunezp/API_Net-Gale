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

namespace API.Specifics.Configuration.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BD_GERD_SLA_DES")]
	public partial class ConfigurationDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    #endregion
		
		public ConfigurationDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SGR_Desav3ConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ConfigurationDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConfigurationDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConfigurationDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConfigurationDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Config> Configs
		{
			get
			{
				return this.GetTable<Config>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TB_MAE_Configuracion")]
	public partial class Config
	{
		
		private string _name;
		
		private string _description;
		
		private string _value;
		
		private System.Guid _token;
		
		public Config()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="CONF_Nombre", Storage="_name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this._name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="CONF_Descripcion", Storage="_description", DbType="VarChar(500) NOT NULL", CanBeNull=false)]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this._description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="CONF_Valor", Storage="_value", DbType="VarChar(8000) NOT NULL", CanBeNull=false)]
		public string value
		{
			get
			{
				return this._value;
			}
			set
			{
				if ((this._value != value))
				{
					this._value = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="CONF_Token", Storage="_token", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid token
		{
			get
			{
				return this._token;
			}
			set
			{
				if ((this._token != value))
				{
					this._token = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
