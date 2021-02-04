//using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web;
using Common.DTO;
using Newtonsoft.Json;

namespace API.Controllers
{


  //הגדרה אחת לתחילת הנתיב
  [System.Web.Http.RoutePrefix("api/Event")]
  public class EventController : ApiController
  {
    public IHttpActionResult GetEvent()
    {
      try
      {
        var q = BLL.EventService.GetAllEvents();
        if (q != null)
          return Ok(q);
        return NotFound();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [RequireHttps]
    [System.Web.Http.HttpGet]
    [System.Web.Http.Route("GetEventType")]
    public IHttpActionResult GetEventType()
    {
      try
      {
        var q = BLL.EventService.GetEventType();
        if (q != null)
          return Ok(q);
        return NotFound();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //Rout עם פרמטרים
    //יש לכלול פרמטרים בהגדרת הנתיב
    [System.Web.Http.HttpGet]
    [System.Web.Http.Route("GetByCode")]
    public IHttpActionResult GetEventByCode(int code)
    {
      var q1 = BLL.EventService.SelectEvents(code);
      if (q1 == null)
        return NotFound();
      return Ok(q1);

    }


    //מחיקה
    //.../api/Event/1016
    [RequireHttps]
    [System.Web.Http.HttpPost]
    [System.Web.Http.Route("UploadJsonFile")]

    public HttpResponseMessage UploadJsonFile()
    {
      HttpResponseMessage response = new HttpResponseMessage();
      var httpRequest = HttpContext.Current.Request;
      if (httpRequest.Files.Count > 0)
      {
        foreach (string file in httpRequest.Files)
        {
          var postedFile = httpRequest.Files[file];
          var filePath = HttpContext.Current.Server.MapPath("~/UploadFile/" + postedFile.FileName);
          postedFile.SaveAs(filePath);
        }
      }
      return response;
    }
    public IHttpActionResult DeleteEventByCode(int code)
    {
      //מה אנחנו צריכות לעשות עכשיחו
      //1.bl שתקרא לפונקציה בwebapi  להוסיף פונקציה ב
      //2.dal שתקרא לפונקציה ב bl להוסיף פונקציה ב
      //3. Dal להוסיף פונקציה ב
      try
      {
        int x = BLL.EventService.DeleteEventByCode(code);

        if (x == 0)
          return NotFound();
        else
          return Ok(x);
      }
      catch (Exception e)
      {
        //שקרא לה תפס אותה וגם הוא זרק אותהbll היא נזרקה ואז הdal במקרה שגיאה ב
        //תפס את השגיאה והוא מעביר את טקסט השגיאה ללקוחbll שהפעיל את הwebapi ה
        //האנגולר יוכל לראות שחזר שגיאה ומה הייתה השגיאה 
        return BadRequest(e.Message);
      }


    }

    [RequireHttps]
    [System.Web.Http.HttpPost]
    [System.Web.Http.Route("PostCategoryiesList")]
    public IHttpActionResult PostCategoryiesList(List<BaseCodeDto> CategoryiesList)
    {
      try
      {
        int x = BLL.EventService.updateCategoryiesList(CategoryiesList);
            if (x == 0)
                return NotFound();
            else
                return Ok(x);
  }
        catch (Exception e)
        {
            //שקרא לה תפס אותה וגם הוא זרק אותהbll היא נזרקה ואז הdal במקרה שגיאה ב
            //תפס את השגיאה והוא מעביר את טקסט השגיאה ללקוחbll שהפעיל את הwebapi ה
            //האנגולר יוכל לראות שחזר שגיאה ומה הייתה השגיאה 
            return BadRequest(e.Message);
}
    }

    [RequireHttps]
    [System.Web.Http.HttpPost]
    [System.Web.Http.Route("PostEvent")]
    public IHttpActionResult PostEvent([FromBody]EventDto request)
    {
      try
      {

        int x = BLL.EventService.UpdateEvent(request);
        if (x == 0)
          return NotFound();
        else
          return Ok(x);
      }
      catch (Exception e)
      {
        //שקרא לה תפס אותה וגם הוא זרק אותהbll היא נזרקה ואז הdal במקרה שגיאה ב
        //תפס את השגיאה והוא מעביר את טקסט השגיאה ללקוחbll שהפעיל את הwebapi ה
        //האנגולר יוכל לראות שחזר שגיאה ומה הייתה השגיאה 
        return BadRequest(e.Message);
      }

    }
    //[RequireHttps]
    //[System.Web.Http.HttpPost]
    //[System.Web.Http.Route("PostEvent")]
    //public HttpResponseMessage Post(EventDto model)
    //{
    //  return Request.CreateResponse<string>(HttpStatusCode.OK, "Value Recieved: " + model.event_date);
    //}
  }
}
