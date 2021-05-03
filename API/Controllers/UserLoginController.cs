using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;

namespace API.Controllers
{
  [System.Web.Http.RoutePrefix("api/UserLogin")]

  public class UserLoginController : ApiController
  {
    [HttpGet]
    [System.Web.Http.Route("Login")]

    public bool Login(string userEmail, string password)
    {
      try
      {
        var q = BLL.UserService.Login(userEmail,password);
        if (q)
          return q;
        return false;
      }
      catch 
      {
        return false;
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
    [HttpPut]

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
