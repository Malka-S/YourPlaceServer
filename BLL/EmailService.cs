using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public class EmailService
  {

    public static void mail(string to, string body, string guest_id)
    {
      try
      {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("malkaspaintings@gmail.com");
        mail.To.Add(to);
        string URI = "http://localhost:4200/confirm-participation ";
        mail.Body = " \n  :מייל תזכורת לארוע שלכם     " + "<a href=\"" + URI + "guest_id?=" + guest_id + "\">Click here</a>" + body;
        //  + "<a href="#/users/:userId">{{g_id}}</a>'  +body;
        // MailMessage o = new MailMessage("f2@hotmail.com", EMPemail, "KAUH Account Activation", "Hello, " + name + "<br /> Your KAUH Account about to activate click the link below to complete the activation process <br />" +
        //  "<a href=\"" + URI + "?" + myParameters + "\">Click here</a>");

        SmtpServer.Port = 587;
        SmtpServer.Credentials = new System.Net.NetworkCredential("malkaspaintings@gmail.com", "Malkaart332");
        SmtpServer.EnableSsl = true;

        SmtpServer.Send(mail);
      }
      catch (Exception e)
      {
        throw e;
      }
    }

  }
}
