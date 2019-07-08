using System;
using System.Net;
using System.Threading.Tasks;
using Asp.Net.Angular.Template.Contract.Base;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Asp.Net.Angular.Template.Web.ResultBuilder
{
  /// <summary>
  /// Class to build api response
  /// </summary>
  public class ActionResultBuilder
  {
    /// <summary>
    /// Exebute the function and get result. 
    /// </summary>
    /// <typeparam name="TContent">Result enity</typeparam>
    /// <param name="func">Function to be executed</param>
    /// <returns>Returns OK if successful, otherwise appropriate status code and error message</returns>
    public static async Task<ActionResult<TContent>> ExecuteAndBuildResult<TContent>(Func<Task<Result<TContent>>> func)
        where TContent : class
    {
      var result = await func.Invoke();

      if (!result.Succeeded)
      {
        return new ContentResult
        {
          StatusCode = (int)result.ApplicationError.ErrorCode < 600 ? (int)result.ApplicationError.ErrorCode : (int)HttpStatusCode.BadRequest,
          Content = JsonConvert.SerializeObject(result.ApplicationError,
            new JsonSerializerSettings
            {
              ContractResolver = new CamelCasePropertyNamesContractResolver()
            }),
          ContentType = "application/json"
        };
      }

      return new OkObjectResult(result.Content);
    }

    /// <summary>
    /// Exebute the function and get result. 
    /// </summary>
    /// <typeparam name="TContent">Result enity</typeparam>
    /// <param name="func">Function to be executed</param>
    /// <returns>Returns OK if successful, otherwise appropriate status code and error message</returns>
    public static async Task<ActionResult> ExecuteAndBuildResult(Func<Task<Result>> func)
    {
      var result = await func.Invoke();

      if (!result.Succeeded)
      {
        return new ContentResult
        {
          StatusCode = (int)result.ApplicationError.ErrorCode < 600 ? (int)result.ApplicationError.ErrorCode : (int)HttpStatusCode.BadRequest,
          Content = JsonConvert.SerializeObject(result.ApplicationError,
            new JsonSerializerSettings
            {
              ContractResolver = new CamelCasePropertyNamesContractResolver()
            }),
          ContentType = "application/json"
        };
      }

      return new OkObjectResult(result);
    }

  }
}
