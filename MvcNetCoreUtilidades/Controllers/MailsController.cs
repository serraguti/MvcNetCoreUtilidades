using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace MvcNetCoreUtilidades.Controllers
{
    public class MailsController : Controller
    {
        //NECESITAMOS EL FICHERO DE CONFIGURATION
        private IConfiguration configuration;

        public MailsController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var smtpClient = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("alumnotajamar2024@outlook.com", "qdxcusrujjksgdhm")
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress("alumnotajamar2024@outlook.com"),
                Subject = "Test Email",
                Body = "This is a test email sent using System.Net.Mail with OAuth2.",
                IsBodyHtml = true
            };
            mailMessage.To.Add("alumnotajamar2024@outlook.com");
            // Step 3: Send the email
            await smtpClient.SendMailAsync(mailMessage);
            return View();
        }

        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> 
            SendMail(string to, string asunto
            , string mensaje)
        {
            MailMessage mail = new MailMessage();
            //DEBEMOS INDICAR EL FROM, ES DECIR, DE QUE CUENTA VIENE
            //EL CORREO (LA NUESTRA DE APPSETTINGS.JSON)
            string user = this.configuration.GetValue<string>
                ("MailSettings:Credentials:User");
            mail.From = new MailAddress(user);
            //LOS DESTINATARIOS SON UNA COLECCION
            mail.To.Add(to);
            mail.Subject = asunto;
            mail.Body = mensaje;
            //<h1>hola</h1>
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;
            string password = this.configuration.GetValue<string>
                ("MailSettings:Credentials:Password");
            string host = this.configuration.GetValue<string>
                ("MailSettings:Server:Host");
            int port = this.configuration.GetValue<int>
                ("MailSettings:Server:Port");
            bool ssl = this.configuration.GetValue<bool>
                ("MailSettings:Server:Ssl");
            bool defaultCredentials = this.configuration.GetValue<bool>
                ("MailSettings:Server:DefaultCredentials");
            //CREAMOS LA CLASE SERVIDOR SMTP
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.EnableSsl = true;
            
            //CREAMOS LAS CREDENCIALES PARA EL MAIL
            NetworkCredential credentials =
                new NetworkCredential(user, password);
            smtpClient.Credentials = credentials;
            smtpClient.UseDefaultCredentials = false;
            await smtpClient.SendMailAsync(mail);
            ViewData["MENSAJE"] = "Mail enviado correctamente??";
            return View();
        }
    }
}
