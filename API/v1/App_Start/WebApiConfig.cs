using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Services.Description;
using Swashbuckle.Application;

namespace API
{

	/// <summary>
	/// WEB API Global Configuration
	/// </summary>
	public static class WebApiConfig
	{
		/// <summary>
		/// Register Config Variables
		/// </summary>
		/// <param name="config"></param>
		public static void Register (HttpConfiguration config)
		{
            //--------------------------------------------------------------------------------------------------------------------------------------------
            // Web API routes defaults

            config.EnableGaleRoutes("v1");  // If you want manual versioning, don't send the api version
                                            //config.EnableSwagger();
            config.EnableSwagger("bin\\documentation.config");
            config.SetJsonDefaultFormatter();

            //config.EnableGaleRoutes("v1");      // If you want manual versioning, don't send the api version
            //config.SetJsonDefaultFormatter();   // Google Chrome Fix (default formatter is xml :/)
            ////--------------------------------------------------------------------------------------------------------------------------------------------

            ////--------------------------------------------------------------------------------------------------------------------------------------------
            //// Swagger Documentation Enable
            //// In Azure Deployment , Azure remove all XML :/, so we need to change the documentation file name
            //config.EnableSwagger("documentation.config");             // Enable Swagger Always =)
            //--------------------------------------------------------------------------------------------------------------------------------------------
           
		}
	}
}
