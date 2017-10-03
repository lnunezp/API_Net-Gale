using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Gale.REST.Http;
using API.Endpoints.Dashboard;

namespace API.Endpoints.Dashboard
{
    /// <summary>
    /// cxc
    /// </summary>
    [Gale.Security.Oauth.Jwt.Authorize]
    public class DashboardController : Gale.REST.RestController
    {
        /// <summary>
        /// obtiene dashboard
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("PieChart")]
        public IHttpActionResult Get()
        {
            return new Gale.REST.Http.HttpQueryableActionResult<Models.CXC>(this.Request);
        }
    }
}