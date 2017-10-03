using Gale.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace API.Endpoints.Mantenedores.Contratos.Services
{
    public class Get : Gale.REST.Http.HttpBaseActionResult
    {

        Models.CONTRATOS_NIVEL contratosNivel;

        public Get(Models.CONTRATOS_NIVEL parametros)
        {
            this.contratosNivel = parametros;
        }

        public override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(
           System.Threading.CancellationToken cancellationToken)
        {
            using (Gale.Db.DataService svc = new Gale.Db.DataService("PA_MAE_CONTRATOS_NIVEL"))
            {
                svc.Parameters.Add("tokenNivel", this.contratosNivel.tokenNivel);
                svc.Parameters.Add("tokenEmpresa", this.contratosNivel.tokenEmpresa);
                Gale.Db.EntityRepository rep = this.ExecuteQuery(svc);

                Gale.Db.EntityTable<Models.CONTRATOS_NIVEL_LISTA> respuesta = rep.GetModel<Models.CONTRATOS_NIVEL_LISTA>();
                |
                HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new ObjectContent<Object>(respuesta, System.Web.Http.GlobalConfiguration.Configuration.Formatters.JsonFormatter)
                };

                return Task.FromResult(response);
            }
        }

    }
}