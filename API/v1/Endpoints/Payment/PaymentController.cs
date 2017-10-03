using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Gale.REST.Http;
using API.Endpoints.Payment;

namespace API.Endpoints.Payment
{
    /// <summary>
    /// case
    /// </summary>
    [Gale.Security.Oauth.Jwt.Authorize]
    public class PaymentController : Gale.REST.RestController
    {
        /// <summary>
        /// crea un registro de la tabla pago
        /// </summary>
        /// <param name = "parametros" ></param >
        /// <returns></returns>
        [HttpPost]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("Create")]
        public IHttpActionResult Post(Models.CREATEPAYMENT parametros)
        {
            return new Services.Post(parametros);
        }

        /// <summary>
        /// obtiene la lista de pagos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [HierarchicalRoute("List")]
        public IHttpActionResult Get()
        {
            return new Gale.REST.Http.HttpQueryableActionResult<Models.DATAPAYMENT>(this.Request);
        }

        /// <summary>
        /// elimina un registro de pago
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