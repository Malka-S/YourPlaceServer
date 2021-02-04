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
    [RequireHttps]
    [System.Web.Http.HttpGet]
    [System.Web.Http.Route("GetCatagoryList")]
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
    //add
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
    //update
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
