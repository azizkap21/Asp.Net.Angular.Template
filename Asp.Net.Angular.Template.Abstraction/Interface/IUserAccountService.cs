using System;
using System.Threading.Tasks;
using Asp.Net.Angular.Template.Contract.Base;
using Asp.Net.Angular.Template.Contract.Response;

namespace Asp.Net.Angular.Template.Abstraction.Interface
{
    public interface IUserAccountService
    {
        Task<Result<AuthenticationResponse>> AuthenticateUser(string email, string password);
    } 
}
