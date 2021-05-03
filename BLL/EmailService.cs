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
    

    public static void SentAllGuestC(int eventId,string body,string subject)
    {
      List<Common.DTO.GuestDto> guestsList = GuestService.GetGuestListByEventId(eventId);
      foreach (var guest in guestsList)
      {
        mailCustom(guest.guest_email, body,  subject, eventId);
      }
    }
    public static void SentAllGuestInvitation(int eventId, string body)
    {
      List<Common.DTO.GuestDto> guestsList = GuestService.GetGuestListByEventId(eventId);
      foreach (var guest in guestsList)
      {
        mailInvetation(guest.guest_email, body, guest.guest_id, eventId);
      }
    }
    public static void SentGuestConfirmedMail(int eventId,string body,string subject)
    {
      List<Common.DTO.GuestDto> guestsList = GuestService.GetGuestConfirmed();
      foreach (var guest in guestsList)
      {
        mailCustom(guest.guest_email, body, subject, eventId);
      }
    }
    public static void SentGuestNotConfirmedMail(int eventId, string body, string subject)
    {
      List<Common.DTO.GuestDto> guestsList = GuestService.GetGuestNotConfirmed();
      foreach (var guest in guestsList)
      {
        mailCustom(guest.guest_email, body, subject, eventId);
      }
    }
    public static void mailCustom(string to, string body,string subject,int event_id)
    {
      try
      {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("malkaspaintings@gmail.com");
        mail.To.Add(to);
        Attachment attachment;
        attachment = new Attachment(DAL.EventDal.GetInvatation(event_id));
        //var filePath = HttpContext.Current.Server.MapPath("~/UploadFile/" + attachment);
        mail.Attachments.Add(attachment);
        mail.Subject = subject;

        mail.Body = "Thank you for using servise of YPURPLACE" + "<br>"+ body;
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
    public static void mailInvetation(string to, string body, int guest_id, int event_id)
    {
      try
      {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("malkaspaintings@gmail.com");
        mail.To.Add(to);
        mail.Subject = "הזמנה ל" + DAL.EventDal.GetNameOfEvent(event_id);

        Attachment attachment;
        attachment = new Attachment(DAL.EventDal.GetInvatation(event_id));
        //var filePath = HttpContext.Current.Server.MapPath("~/UploadFile/" + attachment);
        mail.Attachments.Add(attachment);
        string URI = "http://localhost:4200/confirm-participation";
        mail.Body = " \n  :מייל תזכורת לארוע שלכם     " + "<a href=\"" + URI + "?guest_id=" + guest_id + "\">Click here</a>" +
          "Thank you for using servise of YPURPLACE" + "<br>" + body;
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
