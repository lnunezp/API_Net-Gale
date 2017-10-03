using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.ClientServices.Providers;
using System.Web.UI;
using API.Endpoints.Payment.Models;

namespace API.Endpoints.Payment.Services
{
    public class Post : Gale.REST.Http.HttpReadActionResult<Models.CREATEPAYMENT>
    {
        /// <summary>
        /// METODO /SERVICIO "PARA CREAR NUEVOS PAGOS"
        /// </summary>
        /// <param name="model"></param>
        public Post(Models.CREATEPAYMENT model) : base(model) { }

        public override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            using (Gale.Db.DataService svc = new Gale.Db.DataService("PA_INS_PAGO"))
            {
                var token = Guid.NewGuid();

                svc.Parameters.Add("TOKEN", this.Model.TOKENCASE);
                svc.Parameters.Add("COMPROBANTE", this.Model.VOUCHER);
                svc.Parameters.Add("MONTOPAGO", this.Model.VALUE);

                token = (Guid)this.ExecuteScalar(svc);
                return Task.FromResult(new HttpResponseMessage()
                {
                    Content = new ObjectContent<Object>(new
                    {
                        token = token
                    },
                    System.Web.Http.GlobalConfiguration.Configuration.Formatters.JsonFormatter),
                    StatusCode = System.Net.HttpStatusCode.Created
                });
            }
        }
    }
}