using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AlgoController : ApiController
  {
    [System.Web.Http.HttpGet]
    [System.Web.Http.Route("GetSeatingArangemant")]
    public IHttpActionResult GetSeatingArangemant()
    {
      try
      {
        BLL.algo.CreateArrPerCategory();

        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
