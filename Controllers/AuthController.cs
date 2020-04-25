using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceBookApi.ViewModels;

namespace SpaceBookApi.Controllers
{
  [Route("auth")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    [HttpPost("signup")]
    public async Task<ActionResult> SignUpUser(NewUser user)
    {
      // validate user data
      // hash the password
      // storing the user data
      // generating a jwt
      return Ok();
    }
  }
}