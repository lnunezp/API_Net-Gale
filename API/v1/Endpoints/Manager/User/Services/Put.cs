using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.ClientServices.Providers;
using System.Web.UI;
using API.Endpoints.Manager.User.Models;

namespace API.Endpoints.Manager.User.Services
{
    public class Put: Gale.REST.Http.HttpCreateActionResult<Models.CREATEUSER>
    {
        public Put(Models.CREATEUSER model) : base(model) { }

        public override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            using (Gale.Db.DataService svc = new Gale.Db.DataService("PA_UPD_USUARIO"))
            {
                var token = Guid.NewGuid();

                svc.Parameters.Add("NAME", this.Model.NAME);
                svc.Parameters.Add("LASTNAME", this.Model.LASTNAME);
                svc.Parameters.Add("USERNAME", this.Model.USERNAME);
                svc.Parameters.Add("PASSWORD", Gale.Security.Cryptography.MD5.GenerateHash(this.Model.PASSWORD));
                svc.Parameters.Add("MAIL", this.Model.MAIL);
                svc.Parameters.Add("TOKEN", this.Model.TOKEN);

                token = (Guid)this.ExecuteScalar(svc);
                return Task.FromResult(new HttpResponseMessage() {
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