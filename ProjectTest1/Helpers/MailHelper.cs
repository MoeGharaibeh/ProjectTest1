using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProjectTest1.Helpers
{
    public class MailHelper
    {
        public void SendMail(string email, string name , string managerName )
        {
            try
            {
   

                var message = new MailMessage();
                message.Subject = "A New Work Has Published";
                message.Body = $"Dear {name},<br/><br/>A new Project has been created by {managerName} , please check your Account and Taskes";
                message.IsBodyHtml = true;
                message.From = new MailAddress("gharaiebehpms@gmail.com");
                message.To.Add(email);
                var smptClient = new SmtpClient();
                smptClient.Host = "smtp.gmail.com";
                smptClient.Port = 587;
                smptClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smptClient.UseDefaultCredentials = false;
                smptClient.Credentials = new NetworkCredential("gharaiebehpms@gmail.com", "Test@123");
                smptClient.EnableSsl = true;
                smptClient.Send(message);

            }
            catch (Exception)
            {

                throw;
            }
      
        }

        public void SendMailForATask(string email, string name, string managerName , string title )
        {
            try
            {


                var message = new MailMessage();
                message.Subject = "A New Work Has Published";
                message.Body = $"Dear {name},<br/><br/>A new Task has been added by {managerName} the task title is {title} , please check your Account";
                message.IsBodyHtml = true;
                message.From = new MailAddress("gharaiebehpms@gmail.com");
                message.To.Add(email);
                var smptClient = new SmtpClient();
                smptClient.Host = "smtp.gmail.com";
                smptClient.Port = 587;
                smptClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smptClient.UseDefaultCredentials = false;
                smptClient.Credentials = new NetworkCredential("gharaiebehpms@gmail.com", "Test@123");
                smptClient.EnableSsl = true;
                smptClient.Send(message);

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
