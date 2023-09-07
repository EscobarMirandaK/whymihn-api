using API.Entities;
using API.Interface;
using System.Net.Mail;

namespace API.Extensions
{
    public class EmailHelper : IEmailHelper
    {
        private readonly IConfiguration config;

        public EmailHelper(IConfiguration config)
        {
            this.config = config;
        }

        ////private static Logger logger = LogManager.GetCurrentClassLogger();

        public void SendWelcomeEmail(User user)
        {
            string smtpClient = config.GetValue<string>(Email.SMTP_CLIENT),
                   WHYMIHNInfoMailAddress = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_ADDRESS),
                   mailPass = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_PASSWORD);

            string body = "¡Felicidades! El proceso de inscripción ha terminado satisfactoriamente. <br>";
            body += "Ahora puedes enviar todas tus compras por internet a la siguiente dirección:  <br> <br>";

            body = CreateUserInfoEmailBody(user, body);

            body += "Gracias por escogernos. Esperamos que nuestros servicios sean de su agradado.<br>";

            MailMessage mailObj = new MailMessage();
            mailObj.IsBodyHtml = true;
            mailObj.From = new MailAddress(WHYMIHNInfoMailAddress);
            mailObj.To.Add(new MailAddress(user.Email));
            mailObj.Subject = "[WHYMIHN CR] Bienvenido";
            mailObj.Body = body;

            // SMTP Config
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = smtpClient;
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(WHYMIHNInfoMailAddress, mailPass);

            client.Send(mailObj);

            System.Diagnostics.Debug.WriteLine("[WELCOME] - Email sent to user #" + user.Email);
            ////logger.Info("[WELCOME] - Email sent to user #" + user.IKNumber);
        }

        public void SendUpdateInfoEmail(User user)
        {
            string smtpClient = config.GetValue<string>(Email.SMTP_CLIENT),
                   WHYMIHNInfoMailAddress = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_ADDRESS),
                   mailPass = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_PASSWORD);

            string body = "El proceso de actualización de información ha sido exitoso. <br>";
            body += "Recuerda que debes enviar tus compras a la siguiente dirección:  <br> <br>";

            body = CreateUserInfoEmailBody(user, body);

            body += "Gracias por escogernos. Esperamos que nuestros servicios sean de su agradado.<br>";

            MailMessage mailObj = new MailMessage();
            mailObj.IsBodyHtml = true;
            mailObj.From = new MailAddress(WHYMIHNInfoMailAddress);
            mailObj.To.Add(new MailAddress(user.Email));
            mailObj.Subject = "[WHYMIHN CR] Bienvenido";
            mailObj.Body = body;

            // SMTP Config
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = smtpClient;
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(WHYMIHNInfoMailAddress, mailPass);

            client.Send(mailObj);

            System.Diagnostics.Debug.WriteLine("[UPDATE INFO] - Email sent to user #" + user.Email);
            ////logger.Info("[UPDATE INFO] - Email sent to user #" + user.IKNumber);
        }

        public void SendPasswordResetEmail(string email, string password)
        {
            string smtpClient = config.GetValue<string>(Email.SMTP_CLIENT),
                   WHYMIHNInfoMailAddress = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_ADDRESS),
                   mailPass = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_PASSWORD);

            string body = "Tu contraseña ha sido reestablecida. <br>";
            body += "Tu contraseña temporal es: " + password + " <br> <br>";
            body += "Si necesitas asistencia, nos puedes contactar mediante una llamada al número +506 2101-2917 o mediante un chat de WhatsApp al número <a href='https://wa.me/+50672737654' target='_blank'>+506 7273-7654</a><br><br>";
            body += "¡Gracias por preferirnos!<br>";

            MailMessage mailObj = new MailMessage();
            mailObj.IsBodyHtml = true;
            mailObj.From = new MailAddress(WHYMIHNInfoMailAddress);
            mailObj.To.Add(new MailAddress(email));
            mailObj.Subject = "[WHYMIHN CR] Reestablecer contraseña";
            mailObj.Body = body;

            // SMTP Config
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = smtpClient;
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(WHYMIHNInfoMailAddress, mailPass);

            client.Send(mailObj);

            System.Diagnostics.Debug.WriteLine("[UPDATE INFO] - Email sent to " + email);
            ////logger.Info("[UPDATE INFO] - Email sent to user #" + user.IKNumber);
        }

        public void SendNewRegstrationEmail(User user)
        {
            string smtpClient = config.GetValue<string>(Email.SMTP_CLIENT),
                   WHYMIHNInfoMailAddress = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_ADDRESS),
                   mailPass = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_PASSWORD);

            string body = "¡Enhorabuena! Un nuevo cliente se ha registrado exitosamente. <br><br>";

            body += "<b>Nombre completo:</b> " + user.Name + "<br>";
            body += "<b>Email:</b> " + user.Email + "<br>";
            //body += "<b>Teléfono:</b> " + user.Phone + "<br>";
            //body += "<b>Dirección:</b> " + user.DeliveryAddress + "<br>";

            MailMessage mailObj = new MailMessage();
            mailObj.IsBodyHtml = true;
            mailObj.From = new MailAddress(WHYMIHNInfoMailAddress);
            mailObj.To.Add(new MailAddress(config.GetValue<string>("Email:WHYMIHN_ADMIN_MAIL_ADDRESS")));
            mailObj.Subject = "[CLIENTE] " + user.Name;
            mailObj.Body = body;

            // SMTP Config
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = smtpClient;
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(WHYMIHNInfoMailAddress, mailPass);

            client.Send(mailObj);
        }

        public void SendUpdateInfoEmail(List<User> contacts)
        {
            string smtpClient = config.GetValue<string>(Email.SMTP_CLIENT),
                   WHYMIHNInfoMailAddress = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_ADDRESS),
                   mailPass = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_PASSWORD);

            foreach (User user in contacts)
            {
                // SMTP Config
                using (SmtpClient client = new SmtpClient())
                {
                    client.Port = 587;
                    client.Host = smtpClient;
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(WHYMIHNInfoMailAddress, mailPass);

                    string body = "<br><b>¡Importante!</b><br><b>¡Por favor actualizar sus datos!</b><br><br>";
                    body += "Con el fin de mejorar nuestro sistema de notificaciones y agilizar nuestro servicio de entregas a domicilio, le solicitamos que por favor actualice sus datos ingresando en el siguiente formulario:  <br> <br>";

                    body += "<a href='https://www.WHYMIHNcr.com/Edit?ref=" + user.Email + "' target='_blank'>Click aquí para actualizar sus datos</a><br><br>";

                    body += "Gracias por seguir escogiéndonos. Continuamos mejorando para brindarles siempre el mejor servicio.<br>";

                    body += "<img src='https://www.WHYMIHNcr.com/Assets/images/logo.jpg' alt='Logo' height='317'>";

                    MailMessage mailObj = new MailMessage();
                    mailObj.IsBodyHtml = true;
                    mailObj.From = new MailAddress(WHYMIHNInfoMailAddress);
                    mailObj.To.Add(new MailAddress(user.Email));
                    mailObj.Subject = "[WHYMIHN CR] Actualización de datos";
                    mailObj.Body = body;

                    client.Send(mailObj);
                    System.Diagnostics.Debug.WriteLine("[NEWS] - Email sent to user #" + user.Email);
                    ////logger.Info("[NEWS] - Email sent to user #" + user.IKNumber);
                }
            }
        }

        public void SendTermsAndConditionsEmail(List<User> contacts)
        {
            string smtpClient = config.GetValue<string>(Email.SMTP_CLIENT),
                   WHYMIHNInfoMailAddress = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_ADDRESS),
                   mailPass = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_PASSWORD);

            foreach (User user in contacts)
            {
                // SMTP Config
                using (SmtpClient client = new SmtpClient())
                {
                    client.Port = 587;
                    client.Host = smtpClient;
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(WHYMIHNInfoMailAddress, mailPass);

                    string body = "<br><b>¡Importante!</b><br><b>¡Hemos actualizado nuestros términos y condiciones!</b><br><br>";
                    body += "Con el fin de mejorar nuestro sistema de notificaciones y agilizar nuestro servicio de entregas a domicilio, le solicitamos que por favor acepte los términos y condiciones ingresando en el siguiente formulario:  <br> <br>";

                    body += "<a href='https://www.WHYMIHNcr.com/Edit?ref=" + user.Email + "' target='_blank'>Click aquí para aceptar los términos y condiciones</a><br><br>";

                    body += "­­¡Gracias por la confianza, seguiremos ofreciendo el mejor servicio!<br>";

                    body += "<img src='https://www.WHYMIHNcr.com/Assets/images/logo.jpg' alt='Logo' height='317'>";

                    MailMessage mailObj = new MailMessage();
                    mailObj.IsBodyHtml = true;
                    mailObj.From = new MailAddress(WHYMIHNInfoMailAddress);
                    mailObj.To.Add(new MailAddress(user.Email));
                    mailObj.Subject = "[WHYMIHN CR] Términos y Condiciones";
                    mailObj.Body = body;

                    client.Send(mailObj);
                    System.Diagnostics.Debug.WriteLine("[TERMS] - Email sent to user #" + user.Email);
                    ////logger.Info("[TERMS] - Email sent to user #" + user.IKNumber);
                }
            }
        }

        public void SendDisableUserEmail(string name, string email, string iKNumber)
        {
            string smtpClient = config.GetValue<string>(Email.SMTP_CLIENT),
                   WHYMIHNInfoMailAddress = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_ADDRESS),
                   mailPass = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_PASSWORD);

            // SMTP Config
            using (SmtpClient client = new SmtpClient())
            {
                client.Port = 587;
                client.Host = smtpClient;
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(WHYMIHNInfoMailAddress, mailPass);

                string body = "<br><b>¡Importante!</b><br><b>¡Hemos deshabilitado tu cuenta!</b><br><br>";
                body += "Por favor ponte en contacto con servicio al cliente si tienes alguna duda.<br> <br>";

                body += "<a href='https://www.WHYMIHNcr.com target='_blank'>WHYMIHN</a><br><br>";

                body += "­­¡Gracias por la confianza, seguiremos ofreciendo el mejor servicio!<br>";

                body += "<img src='https://www.WHYMIHNcr.com/Assets/images/logo.jpg' alt='Logo' height='317'>";

                MailMessage mailObj = new MailMessage();
                mailObj.IsBodyHtml = true;
                mailObj.From = new MailAddress(WHYMIHNInfoMailAddress);
                mailObj.To.Add(new MailAddress(email));
                mailObj.Subject = "[WHYMIHN CR] Cuenta deshabilitada.";
                mailObj.Body = body;

                client.Send(mailObj);
                System.Diagnostics.Debug.WriteLine("[INFO] - Email sent to user #" + iKNumber);
                ////logger.Info("[TERMS] - Email sent to user #" + user.IKNumber);
            }
        }

        public void SendEnableUserEmail(string name, string email, string iKNumber)
        {
            string smtpClient = config.GetValue<string>(Email.SMTP_CLIENT),
                   WHYMIHNInfoMailAddress = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_ADDRESS),
                   mailPass = config.GetValue<string>(Email.WHYMIHN_INFO_MAIL_PASSWORD);

            // SMTP Config
            using (SmtpClient client = new SmtpClient())
            {
                client.Port = 587;
                client.Host = smtpClient;
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(WHYMIHNInfoMailAddress, mailPass);

                string body = "<br><b>¡Importante!</b><br><b>¡Hemos habilitado tu cuenta!</b><br><br>";
                body += "Por favor ponte en contacto con servicio al cliente si tienes alguna duda.<br> <br>";

                body += "<a href='https://www.WHYMIHNcr.com target='_blank'>WHYMIHN</a><br><br>";

                body += "­­¡Gracias por la confianza, seguiremos ofreciendo el mejor servicio!<br>";

                body += "<img src='https://www.WHYMIHNcr.com/Assets/images/logo.jpg' alt='Logo' height='317'>";

                MailMessage mailObj = new MailMessage();
                mailObj.IsBodyHtml = true;
                mailObj.From = new MailAddress(WHYMIHNInfoMailAddress);
                mailObj.To.Add(new MailAddress(email));
                mailObj.Subject = "[WHYMIHN CR] Cuenta habilitada.";
                mailObj.Body = body;

                client.Send(mailObj);
                System.Diagnostics.Debug.WriteLine("[INFO] - Email sent to user #" + iKNumber);
                ////logger.Info("[TERMS] - Email sent to user #" + user.IKNumber);
            }
        }

        private static string CreateUserInfoEmailBody(User user, string body)
        {
            ////string paddedClientID = user.IKNumber.ToString();
            ////paddedClientID = paddedClientID.PadLeft(3, '0');

            ////body += "<b>Full name:</b> BIO - " + user.Name + " <br>";
            ////body += "<b>Address line 1:</b> 8455 NW 68TH ST <br>";
            ////body += "<b>Address line 2:</b> Cliente " + paddedClientID + "<br>";
            ////body += "<b>City:</b> DORAL <br>";
            ////body += "<b>State/Province/Region:</b> FLORIDA <br>";
            ////body += "<b>ZIP:</b> 33166 <br>";
            ////body += "<b>Country:</b> United States <br>";
            ////body += "<b>Phone number:</b> 786-615-2467 <br><br>";

            ////body += "<b>Aclaraciones:</b>";
            ////body += "<ul>";
            ////body += "<li>Asegurarse de escribir el nombre tal cual aparece en la información brindada anteriormente.</li>";
            ////body += "<li>El número que aparece en el address line 2 corresponde a su número de cliente.</li>";
            ////body += "<li>Asegurarse de utilizar nombre y dos apellidos.</li>";
            ////body += "</ul>";

            return body;
        }
    }
}
