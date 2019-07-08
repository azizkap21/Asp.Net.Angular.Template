using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Asp.Net.Angular.Template.Contract.Base;
using Asp.Net.Angular.Template.DataEntity;
using Asp.Net.Angular.Template.DataStore.Abstract;

namespace Asp.Net.Angular.Template.DataStore.Concrete
{
    public class SqlUserAccountStore : IUserAccountStore
    {

        public async Task<Result> CreateUserAsync(UserAccount userAccount)
        {
            return Result.Success;
        }
        public Task<Result<List<UserAccount>>> GetUsersByEmailAsync(string email) => throw new NotImplementedException();
        public Task<Result<UserAccount>> UpdateUserAccountAsync(UserAccount userAccount) => throw new NotImplementedException();
    }
}
