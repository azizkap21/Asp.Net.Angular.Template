using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net.Angular.Template.Abstraction.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net.Angular.Template.Web.Controllers.Api
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserAccountController : ControllerBase
  {
    private IUserAccountService _userAccountService;

    /// <summary>
    /// Controller constructor
    /// </summary>
    /// <param name="userAccountService">User Account Service</param>
    public UserAccountController(IUserAccountService userAccountService)
    {
      _userAccountService = userAccountService;
    }

  }
}
