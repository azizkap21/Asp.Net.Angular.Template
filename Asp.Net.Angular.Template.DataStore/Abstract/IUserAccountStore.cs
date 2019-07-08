using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Asp.Net.Angular.Template.Contract.Base;
using Asp.Net.Angular.Template.DataEntity;
using JetBrains.Annotations;

namespace Asp.Net.Angular.Template.DataStore.Abstract
{
    public interface IUserAccountStore
    {
        [NotNull]
        [ItemNotNull]
        Task<Result<List<UserAccount>>> GetUsersByEmailAsync(string email);

        [ItemNotNull]
        Task<Result<UserAccount>> UpdateUserAccountAsync(UserAccount userAccount);


        Task<Result> CreateUserAsync(UserAccount userAccount);
    }
}
