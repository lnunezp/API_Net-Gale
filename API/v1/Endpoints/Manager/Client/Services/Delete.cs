using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using Gale.REST.Http;

namespace API.Endpoints.Manager.Client.Services
{
    /// <summary>
    /// eliminar cliente
    /// </summary>
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


            using (Gale.Db.DataService svc = new Gale.Db.DataService("PA_DEL_CLIENTE"))
            {
                svc.Parameters.Add("Token", token);

                this.ExecuteAction(svc);
            }

            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            return Task.FromResult(response);
        }
    }
}