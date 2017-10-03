using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace API.Specifics.Mail
{
    /// <summary>
    /// Envia correos
    /// </summary>
    public static class Send
    {
        /// Envía correos
        public static void Mail(String Subject, Gale.Db.EntityTable<API.Endpoints.BPM.Transition.Models.Mail> to)
        {
            to.ForEach(o =>
            {
                MailMessage message = new MailMessage()
                {
                    IsBodyHtml = true,
                    From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["Mail:Account"]),
                    Subject = Subject,
                    Body = o.body
                };

                message.To.Add(new MailAddress(o.userMail));
                
                SmtpClient client = new SmtpClient();                
                client.Send(message);
            });
        }

    }
}