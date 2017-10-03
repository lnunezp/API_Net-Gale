using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.ClientServices.Providers;
using System.Web.UI;
using API.Endpoints.Account.Models;
using System.Data.SqlClient;
using System.Drawing;
using Gale.Db;

namespace API.Endpoints.Account.Services
{
    public class Post : Gale.REST.Http.HttpReadActionResult<Models.USER>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="credentials"></param>
        public Post(Models.USER credentials) : base(credentials)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            Models.USER entidad = this.Model;

            //INICIO VALIDACION DB
            using (Gale.Db.DataService svc = new DataService("PA_MAE_SEL_AutenticarUsuario"))
            {
                svc.Parameters.Add("USUA_NombreUsuario", entidad.user);
                svc.Parameters.Add("USUA_Password", Gale.Security.Cryptography.MD5.GenerateHash(entidad.password));
                //svc.Parameters.Add("USUA_Contrasena", entidad.password);

                Gale.Db.EntityRepository resp = this.ExecuteQuery(svc);

                Models.CURRENTUSER user = resp.GetModel<Models.CURRENTUSER>(0).FirstOrDefault();

                Gale.Exception.RestException.Guard(() => user == null, "USERNAME_OR_PASSWORD_INCORRECT", API.Resources.Errors.ResourceManager);

                List<System.Security.Claims.Claim> claims = new List<System.Security.Claims.Claim>();

                claims.Add(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.PrimarySid, user.TOKEN.ToString()));
                claims.Add(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.NOMBRE + ' ' + user.APELLIDO));
                claims.Add(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, user.MAIL));

                int Timeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Gale:Security:TokenTmeout"]);
                return Task.FromResult(new HttpResponseMessage()
                {
                    Content = new ObjectContent<Gale.Security.Oauth.Jwt.Wrapper>(
                        Gale.Security.Oauth.Jwt.Manager.CreateToken(claims, DateTime.Now.AddMinutes(Timeout)),
                        System.Web.Http.GlobalConfiguration.Configuration.Formatters.JsonFormatter),
                    StatusCode = System.Net.HttpStatusCode.OK
                });
            }
        }
    }
}