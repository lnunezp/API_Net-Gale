using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Gale.REST.Http;
using API.Endpoints.Manager.Client;

namespace API.Endpoints.Manager.Client
{
    /// <summary>
    /// client
    /// </summary>
    [Gale.Security.Oauth.Jwt.Authorize]
    public class ClientController : Gale.REST.RestController
    {
        /// <summary>
        /// crea un registro de la tabla cliente
        /// </summary>
        [HttpPost]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("Create")]
        public IHttpActionResult Post(Models.CREATECLIENT parametros)
        {
            return new Services.Post(parametros);
        }

        /// <summary>
        /// obtiene la lista de clientes
        /// </summary>
        [HttpGet]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("List")]
        public IHttpActionResult Get()
        {
            return new Gale.REST.Http.HttpQueryableActionResult<Models.DATACLIENT>(this.Request);
        }

        /// <summary>
        /// elimina un registro de la tabla cliente
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            return new Services.Delete(id.ToString());
        }

        /// <summary>
        /// modifica un registro de la tabla cliente
        /// </summary>
        [HttpPut]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("Update")]
        public IHttpActionResult Put(Models.CREATECLIENT parametros)
        {
            return new Services.Put(parametros);
        }
    }
}