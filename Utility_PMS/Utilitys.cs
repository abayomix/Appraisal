using System.Net;
using System.Net.Mail;
using Utility_PMS.Model;

namespace Utility_PMS
{
    public class Utilitys
    {


        public void SendEmail (Email Email)
        {
         


            using(MailMessage Message = new MailMessage("adejare.abayo@gmail.com", Email.To)) // your Email
            {
                Message.Subject=Email.Subject;
                Message.Body = Email.MEssage;
                Message.IsBodyHtml = false;

                using (SmtpClient mysmtp=new SmtpClient())
                {
                    mysmtp.Host = "smtp.gmail.com";
                    mysmtp.EnableSsl = true;
                    NetworkCredential Ncred = new NetworkCredential("adejare.abayo@gmail.com", @"qgcuhluxpurjdsdv");// add Email and pass key
                    mysmtp.UseDefaultCredentials = false;
                    mysmtp.Credentials = Ncred;
                    mysmtp.Port = 587;
                    mysmtp.Send(Message);
                  

                 }
                


    
            }



          
        }



    }
}