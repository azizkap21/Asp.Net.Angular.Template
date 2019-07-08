using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Angular.Template.Contract.Response
{
    public class AuthenticationResponse
    {
        public string AccessToken { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public Guid UserAccountId { get; set; }
    }
}
