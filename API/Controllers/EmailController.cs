using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{

  public class EmailSendigParameters
  {
    public List<string> ListToSend { get; set; }
    public string body { get; set; }
    public string guest_id { get; set; }
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
    public IHttpActionResult SendEmail(string to,string body,string guest_id)
    {
      try
      {
        BLL.EmailService.mail(to, body,guest_id);

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

          BLL.EmailService.mail(to, emailSendigParameters.body,emailSendigParameters.guest_id);

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

