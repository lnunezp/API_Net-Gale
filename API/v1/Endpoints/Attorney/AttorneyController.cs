using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Gale.REST.Http;
using API.Endpoints.Attorney;

namespace API.Endpoints.Attorney

{
    /// <summary>
    /// attorney
    /// </summary>
    [Gale.Security.Oauth.Jwt.Authorize]
    public class AttorneyController : Gale.REST.RestController
    {
        /// <summary>
        /// obtiene la lista de abogados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("List")]
        public IHttpActionResult Get()
        {
            return new Gale.REST.Http.HttpQueryableActionResult<Models.DATAATTORNEY>(this.Request);
        }

        /// <summary>
        /// crea un registro de la tabla usuarios
        /// </summary>
        [HttpPost]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("Create")]
        public IHttpActionResult Post(Models.CREATEATTORNEY parametros)
        {
            return new Services.Post(parametros);
        }

        /// <summary>
        /// modifica un registro de la tabla abogados
        /// </summary>
        [HttpPut]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("Update")]
        public IHttpActionResult Put(Models.CREATEATTORNEY parametros)
        {
            return new Services.Put(parametros);
        }

        /// <summary>
        /// elimina un registro de la tabla abogados
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            return new Services.Delete(id.ToString());
        }
    }

}