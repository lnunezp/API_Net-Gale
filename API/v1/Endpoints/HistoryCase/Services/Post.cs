﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.ClientServices.Providers;
using System.Web.UI;
using API.Endpoints.HistoryCase.Models;

namespace API.Endpoints.HistoryCase.Services
{
    public class Post : Gale.REST.Http.HttpReadActionResult<Models.CREATEHISTORYCASE>
    {
        /// <summary>
        /// METODO /SERVICIO "PARA CREAR NUEVOS ANTECEDENTES"
        /// </summary>
        /// <param name="model"></param>
        public Post(Models.CREATEHISTORYCASE model) : base(model) { }
        public override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            using (Gale.Db.DataService svc = new Gale.Db.DataService("PA_INS_ANTECEDENTES_CASO"))
            {
                var token = Guid.NewGuid();

                svc.Parameters.Add("DESCRIPCION", this.Model.DESCRIPTION);
                svc.Parameters.Add("TOKEN", this.Model.CASETOKEN);

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