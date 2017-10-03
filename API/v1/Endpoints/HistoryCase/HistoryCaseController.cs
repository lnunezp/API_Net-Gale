using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Gale.REST.Http;
using API.Endpoints.HistoryCase;

namespace API.Endpoints.HistoryCase
{
    /// <summary>
    /// antecedentes case
    /// </summary>
    [Gale.Security.Oauth.Jwt.Authorize]
    public class HistoryCaseController : Gale.REST.RestController
    {
        /// <summary>
        /// crea un registro de la tabla antecedentes de casos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("Create")]
        public IHttpActionResult Post(Models.CREATEHISTORYCASE parametros)
        {
            return new Services.Post(parametros);
        }
    }
}