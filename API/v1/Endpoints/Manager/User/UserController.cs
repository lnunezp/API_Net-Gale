using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Gale.REST.Http;
using API.Endpoints.Manager.User;

namespace API.Endpoints.Manager.User
{
    /// <summary>
    /// user
    /// </summary>
    [Gale.Security.Oauth.Jwt.Authorize]
    public class UserController : Gale.REST.RestController
    {
        /// <summary>
        /// obtiene la lista de usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("List")]
        public IHttpActionResult Get()
        {
            return new Gale.REST.Http.HttpQueryableActionResult<Models.DATAUSER>(this.Request);
        }

        /// <summary>
        /// crea un registro de la tabla usuarios
        /// </summary>
        [HttpPost]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("Create")]
        public IHttpActionResult Post(Models.CREATEUSER parametros)
        {
            return new Services.Post(parametros);
        }

        /// <summary>
        /// modifica un registro de la tabla usuarios
        /// </summary>
        [HttpPut]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("Update")]
        public IHttpActionResult Put(Models.CREATEUSER parametros)
        {
            return new Services.Put(parametros);
        }

        /// <summary>
        /// elimina un registro de la tabla usuario
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