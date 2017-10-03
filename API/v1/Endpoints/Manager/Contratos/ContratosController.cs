using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Gale.REST.Http;
using API.Endpoints.Mantenedores.Contratos.Models;

namespace API.Endpoints.Mantenedores.Contratos
{
    /// <summary>
    /// mantenedor de contratos
    /// </summary>
    [Gale.Security.Oauth.Jwt.Authorize]
    public class ContratosController : Gale.REST.RestController
    {
        /// <summary>
        /// obtiene el contenido de la tabla contratos
        /// </summary>
        /// <returns>Retorna una lista de registros genericos a partir de la tabla Contratos</returns>
        [HttpGet]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        public IHttpActionResult Get()
        {
            return new Gale.REST.Http.HttpQueryableActionResult<Models.CONTRATOS_LISTA>(this.Request);
        }

        /// <summary>
        /// inserta un registro en la tabla contratos
        /// </summary>
        /// <returns>Retorno el token del registro insertado</returns>
        [HttpPost]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        public IHttpActionResult Post(Models.CONTRATOS parametros)
        {
            return new Services.Post(parametros);
        }

       

        /// <summary>
        /// modifica un registro de la tabla contratos
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        [HttpPut]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        public IHttpActionResult Put(Models.CONTRATOS parametros)
        {
            return new Services.Put(parametros);
        }

        /// <summary>
        /// modifica un registro de la tabla contratos
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        [HttpGet]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("ContratosNivel")]
        public IHttpActionResult GetContratosNivel(Guid tokenNivel,Guid tokenEmpresa)
        {
            CONTRATOS_NIVEL parametros = new CONTRATOS_NIVEL();
            parametros.tokenNivel = tokenNivel;
            parametros.tokenEmpresa = tokenEmpresa;
            return new Services.Get(parametros);
        }


    }
}