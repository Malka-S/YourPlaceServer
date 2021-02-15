using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
//using System.Web.Mvc;

namespace API.Controllers
{
  [System.Web.Http.RoutePrefix("api/User")]

  public class UserLoginController : ApiController
  {
    [RequireHttps]
    [System.Web.Http.HttpGet]
    [System.Web.Http.Route("Login")]

    public IHttpActionResult Login(string userEmail, string password)
    {
      try
      {
        var q = BLL.UserService.GetUserByEmail(userEmail,password);
        if (q == true)
          return Ok(q);
        return NotFound();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    public IHttpActionResult GetUser()
    {
      try
      {
        var q = BLL.UserService.GetAllUsers();
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
    [System.Web.Http.HttpPut]
    [System.Web.Http.Route("PutUser")]
    public IHttpActionResult PutUser(Common.DTO.UserDto user)
    {
      try
      {
        var q = BLL.UserService.AddUser(user);
        //if (q == null)
        //  return NotFound();
        return Ok(q);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
    
}
