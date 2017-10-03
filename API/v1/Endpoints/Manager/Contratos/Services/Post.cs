using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.ClientServices.Providers;
using System.Web.UI;
using API.Endpoints.Mantenedores.Contratos.Models;

namespace API.Endpoints.Mantenedores.Contratos.Services
{
    public class Post : Gale.REST.Http.HttpReadActionResult<Models.CONTRATOS>
    {
        /// <summary>
        /// METODO /SERVICIO "PARA CREAR NUEVOS CONTRATOS"
        /// </summary>
        /// <param name="model"></param>
        /// 
        public Post(Models.CONTRATOS model) : base(model) { }
        public override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            using (Gale.Db.DataService svc = new Gale.Db.DataService("PA_SGR_INS_Contratos"))
            {
                var token = Guid.NewGuid();

                svc.Parameters.Add("tokenNivel", this.Model.tokenNivelOrranizacional);
                svc.Parameters.Add("tokenEmpresa", this.Model.tokenEmpresa);
                svc.Parameters.Add("nombre", this.Model.nombre);
                svc.Parameters.Add("descripcion", this.Model.descripcion);
                svc.Parameters.Add("codigoContrato", this.Model.codigo);
                token = (Guid) this.ExecuteScalar(svc);
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