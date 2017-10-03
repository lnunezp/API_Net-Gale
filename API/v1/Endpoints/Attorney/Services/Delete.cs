using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using Gale.REST.Http;

namespace API.Endpoints.Attorney.Services
{
    public class Delete : Gale.REST.Http.HttpDeleteActionResult
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="token"></param>
        public Delete(string token) : base(token) { }

        public override Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(string token, System.Threading.CancellationToken cancellationToken)
        {
            Gale.Exception.RestException.Guard(() => token == null, "BODY_EMPTY", API.Resources.Errors.ResourceManager);


            using (Gale.Db.DataService svc = new Gale.Db.DataService("PA_DEL_ABOGADO"))
            {
                var tokenResponse = Guid.NewGuid();

                svc.Parameters.Add("Token", token);

                tokenResponse = (Guid)this.ExecuteScalar(svc);
                return Task.FromResult(new HttpResponseMessage()
                {
                    Content = new ObjectContent<Object>(new
                    {
                        tokenResponse = tokenResponse
                    },
                    System.Web.Http.GlobalConfiguration.Configuration.Formatters.JsonFormatter),
                    StatusCode = System.Net.HttpStatusCode.Created
                });
            }
        }
    }
}