using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace dominio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.EnableSsl = true;
            server.Credentials = new NetworkCredential("45f1a856d2d7c6", "9fa1e497abaf6a");
            server.Port = 2525;
            server.Host = "smtp.mailtrap.io";
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From =  new MailAddress("noresponder@pokedexxweb.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.Body = cuerpo;
            email.IsBodyHtml = true; ;
        }

        public void enviarCorreo()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
