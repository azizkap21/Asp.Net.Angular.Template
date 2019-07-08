using System;
using System.Collections.Generic;
using System.Text;
using Asp.Net.Angular.Template.DataEntity;

namespace Asp.Net.Angular.Template.Abstraction.Interface
{
    public interface IPasswordHasher : IServiceBase
    {
        string HashPassword(UserAccount userAccount, string password);
        bool VerifyHashedPassword(UserAccount userAccount, string storedPassword, string password);
    }
}
