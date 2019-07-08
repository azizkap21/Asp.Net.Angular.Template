using Asp.Net.Angular.Template.Contract.Common;
using FluentValidation;
using System;

namespace Asp.Net.Angular.Template.Contract.Request
{
    public class UserAccountRequest
    {
        public Guid UserAccountId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }

    public class UserAccountRequestValidator : AbstractValidator<UserAccountRequest>
    {
        public UserAccountRequestValidator()
        {
            RuleFor(x => x.Name).IsRequiredAndMustBeBetween(2, 100);
            RuleFor(x => x.Password).IsRequiredAndMustBeBetween(6, 20);
            RuleFor(x => x.ConfirmPassword).Equal(p => p.Password).WithMessage("'Confirm Password' and 'Password' does not match");
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
