using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace API.Controllers
{
  [System.Web.Http.RoutePrefix("api/Guest")]

  public class GuestController : ApiController
  {
    [System.Web.Http.HttpGet]

    public IHttpActionResult GetCatagoryList()
    {
      try
      {
        var q = BLL.GuestService.GetCatagoryList();
        if (q != null)
          return Ok(q);
        return NotFound();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [System.Web.Http.HttpGet]
    [System.Web.Http.Route("GetGuestList")]


    public IHttpActionResult GetGuestList()
    {
      try
      {
        var q = BLL.GuestService.GetAllGuests();
        if (q != null)
          return Ok(q);
        return NotFound();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [System.Web.Http.HttpDelete]
    [System.Web.Http.Route("deleteGuestById")]

    public IHttpActionResult deleteGuestById(int id)
    {
      try
      {
        int x = BLL.GuestService.DeleteGuest(id);

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
    [System.Web.Http.Route("GetGuestsByCategory")]

    public IHttpActionResult GetGuestsByCategory(string category)
    {
      try
      {
        var q = BLL.GuestService.GetGuestListByCategory(category);
        if (q != null)
          return Ok(q);
        return NotFound();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [System.Web.Http.Route("GetGuestsById")]

    public IHttpActionResult GetGuestsById(int id)
    {
      try
      {
        var q = BLL.GuestService.GetGuestById(id);
        if (q != null)
          return Ok(q);
        return NotFound();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //add
    [System.Web.Http.HttpPut]
    [System.Web.Http.Route("PutGuest")]

    public IHttpActionResult PutGuest(Common.DTO.GuestDto guest)
    {
      try
      {
        var q = BLL.GuestService.AddGuest(guest);
        //if (q == null)
        //  return NotFound();
        return Ok(q);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [System.Web.Http.HttpPut]
    [System.Web.Http.Route("PutGuestTM")]

    public IHttpActionResult PutGuestTM(Common.DTO.TMDto guest)
    {
      try
      {
        var q = BLL.GuestService.AddGuestTM(guest);
        //if (q == null)
        //  return NotFound();
        return Ok(q);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //update
    [System.Web.Http.HttpPost]

    public IHttpActionResult PostGuest(Common.DTO.GuestDto guest)
    {
      try
      {
        int x = BLL.GuestService.UpdateGuest(guest);

        if (x == 0)
          return NotFound();
        else
          return Ok(x);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
