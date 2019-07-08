using System;
using System.Collections.Generic;
using System.Text;
using Asp.Net.Angular.Template.Contract.Common;
using FluentValidation;

namespace Asp.Net.Angular.Template.Contract.Request
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationRequestValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Email).IsRequiredAndMustBeBetween(5, 300);

            RuleFor(x => x.Password).IsRequiredAndMustBeBetween(6, 20);
        }

    }
}
