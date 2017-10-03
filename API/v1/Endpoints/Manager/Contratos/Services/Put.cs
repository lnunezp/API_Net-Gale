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
    public class Put : Gale.REST.Http.HttpCreateActionResult<Models.CONTRATOS>
    {
        public Put(Models.CONTRATOS model) : base(model) { }
        public override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            using (Gale.Db.DataService svc = new Gale.Db.DataService("PA_SGR_MOD_Contratos"))
            {
                svc.Parameters.Add("token", this.Model.token);
                svc.Parameters.Add("tokenNivel", this.Model.tokenNivelOrranizacional);
                svc.Parameters.Add("tokenEmpresa", this.Model.tokenEmpresa);
                svc.Parameters.Add("nombre", this.Model.nombre);
                svc.Parameters.Add("descripcion", this.Model.descripcion);
                svc.Parameters.Add("codigoContrato", this.Model.codigo);

                this.ExecuteScalar(svc);

                return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK));
            }
        }
    }
}