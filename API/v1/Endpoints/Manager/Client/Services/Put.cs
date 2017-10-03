using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.ClientServices.Providers;
using System.Web.UI;
using API.Endpoints.Manager.Client.Models;

namespace API.Endpoints.Manager.Client.Services
{
    public class Put : Gale.REST.Http.HttpCreateActionResult<Models.CREATECLIENT>
    {
        public Put(Models.CREATECLIENT model) : base(model) { }

        public override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            using (Gale.Db.DataService svc = new Gale.Db.DataService("PA_UPD_CLIENTE"))
            {
                var token = Guid.NewGuid();

                svc.Parameters.Add("TOKEN", this.Model.TOKEN);
                svc.Parameters.Add("NAME", this.Model.NAME);
                svc.Parameters.Add("LASTNAME", this.Model.LASTNAME);
                svc.Parameters.Add("EMAIL", this.Model.EMAIL);
                svc.Parameters.Add("MOBILE", this.Model.MOBILE);
                svc.Parameters.Add("PHONE", this.Model.PHONE);
                svc.Parameters.Add("RUT", this.Model.RUT);
                svc.Parameters.Add("DV", this.Model.DV);

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