using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace API.Controllers
{
  public class EmailSendigParameters
  {
    public List<string> ListToSend { get; set; }
    public string body { get; set; }
    public int guest_id { get; set; }
    public string subject { get; set; }
    public int eventId { get; set; }
  }

  public class EmailParams
  {
    public int eventId { get; set; }
    public string body { get; set; }
    public string subject { get; set; }
  }
  public class SingleEmailSendigParameters
  {
    public string ToSend { get; set; }
    public string body { get; set; }
    public string guest_id { get; set; }
  }

  [System.Web.Http.RoutePrefix("api/Email")]

  public class EmailController : ApiController
  {

    [System.Web.Http.HttpGet]
    [System.Web.Http.Route("SendEmail")]
    public IHttpActionResult SendEmail(string to, string body, int guest_id, string subject,int eventId)
    {
      try
      {
        BLL.EmailService.mail(to, body, guest_id,  subject,eventId);

        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [System.Web.Http.HttpGet]
    [System.Web.Http.Route("SendEmailToAllGuest")]
    public IHttpActionResult SendEmailToAllGuest(EmailParams emailParams)
    {
      try
      {
        BLL.EmailService.SentAllGuestMail(emailParams.eventId,emailParams.body, emailParams.subject);

        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

   

    [System.Web.Http.HttpGet]
    [System.Web.Http.Route("SendEmailToMany")]
    public IHttpActionResult SendEmailToMany([FromBody] EmailSendigParameters emailSendigParameters)
    {
      //בדיקה
      //List<string> listTo = new List<string>();
      //listTo.Add("malkasvei@gmail.com");
      //listTo.Add("sveifamily@gmail.com");
      try
      {
        foreach (string to in emailSendigParameters.ListToSend)
        {

          BLL.EmailService.mail(to, emailSendigParameters.body, emailSendigParameters.guest_id ,emailSendigParameters.subject,emailSendigParameters.eventId);

        }
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}

