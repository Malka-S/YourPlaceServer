using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
  public class EmailService
  {


    public static void mailwithpic(int event_id)
    {
      try
      {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("malkaspaintings@gmail.com");
        List<string> guestMail =GuestDal.GetGuestMail(event_id);
        var httpRequest = HttpContext.Current.Request;

        foreach (var item in guestMail)
        {
          mail.To.Add(item);
          mail.Body = " \n  :מייל תזכורת לארוע שלכם    ";
          Attachment attachment;
          attachment = new Attachment(EventDal.GetInvatation(event_id));
          var filePath = HttpContext.Current.Server.MapPath("~/UploadFile/" + attachment);

          mail.Attachments.Add(attachment);
          SmtpServer.Port = 587;
          SmtpServer.Credentials = new System.Net.NetworkCredential("malkaspaintings@gmail.com", "Malkaart332");
          SmtpServer.EnableSsl = true;

          SmtpServer.Send(mail);
        }
      }
      catch (Exception e)
      {
        throw e;
      }
    }


    public static void mail(string to, string body)
    {
      try
      {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("malkaspaintings@gmail.com");
        mail.To.Add(to);

        mail.Body = " \n  :מייל תזכורת לארוע שלכם    " + body;

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

