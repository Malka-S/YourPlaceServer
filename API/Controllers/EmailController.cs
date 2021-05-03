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
    [System.Web.Http.Route("SendEmailC")]
    public IHttpActionResult SendEmailC(string to, string body, string subject,int eventId)
    {
      try
      {
        BLL.EmailService.mailCustom(to, body,  subject,eventId);

        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [System.Web.Http.Route("SendEmailInv")]
    public IHttpActionResult SendEmailInv(string to, string body, int g_id, int eventId)
    {
      try
      {
        BLL.EmailService.mailInvetation(to, body, g_id, eventId);

        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [System.Web.Http.HttpGet]
    [System.Web.Http.Route("SendEmailToAllGuestInv")]
    public IHttpActionResult SendEmailToAllGuestInv(EmailParams emailParams)
    {
      try
      {
        BLL.EmailService.SentAllGuestInvitation(emailParams.eventId, emailParams.subject);

        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [System.Web.Http.Route("SendEmailToAllGuestC")]
    public IHttpActionResult SendEmailToAllGuestC(EmailParams emailParams)
    {
      try
      {
        BLL.EmailService.SentAllGuestC(emailParams.eventId, emailParams.body, emailParams.subject);

        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [System.Web.Http.HttpGet]
    [System.Web.Http.Route("SendInvitationTOne")]
    public IHttpActionResult SendInvitationTOne(EmailParams emailParams)
    {
      try
      {
        BLL.EmailService.mailInvetation("malkasvei@gmail.com", emailParams.body,4,5);

        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //[System.Web.Http.Route("SendEmailToMany")]
    //public IHttpActionResult SendEmailToMany([FromBody] EmailSendigParameters emailSendigParameters)
    //{
    //  //בדיקה
    //  //List<string> listTo = new List<string>();
    //  //listTo.Add("malkasvei@gmail.com");
    //  //listTo.Add("sveifamily@gmail.com");
    //  try
    //  {
    //    foreach (string to in emailSendigParameters.ListToSend)
    //    {

    //      BLL.EmailService.mail(to, emailSendigParameters.body, emailSendigParameters.guest_id ,emailSendigParameters.subject,emailSendigParameters.eventId);

    //    }
    //    return Ok();
    //  }
    //  catch (Exception e)
    //  {
    //    return BadRequest(e.Message);
    //  }
    //}

  }
}

