using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using amazen_server.Models;
using amazen_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amazen_server.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class ProfileController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly KeepsService _ks;
    public ProfileController(ProfilesService ps, KeepsService ks)
    {
      _ps = ps;
      _ks = ks;
    }

    [HttpGet]
    [Authorize]

    public async Task<ActionResult<ProfileController>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{profileId}/keeps")]

    public async Task<ActionResult<ProfileController>> GetKeepsByProfileId(string profileId)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ks.GetKeepsByProfileId(profileId, userInfo.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}