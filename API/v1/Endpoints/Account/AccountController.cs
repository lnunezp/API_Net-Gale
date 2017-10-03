using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using API.Endpoints.Account.Models;
using API.Helper;

namespace API.Endpoints.Account
{
    /// <summary>
    /// account manager
    /// </summary>
    public class AccountController : Gale.REST.RestController
    {
        /// <summary>
        /// valida usuario y password... si esta ok devuelve jwt
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        [HttpPost]
        [HierarchicalRoute("Login")]
        public IHttpActionResult Login(Models.USER auth)
        {
            Gale.Exception.RestException.Guard(() => String.IsNullOrEmpty(auth.user), "EMPTY_BODY", "Ingrese Nombre de Usuario");
            Gale.Exception.RestException.Guard(() => String.IsNullOrEmpty(auth.password), "EMAIL_REQUIRED", "Ingrese Clave");

            return new Services.Post(auth);
        }
    }
}
