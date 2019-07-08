using System;

namespace Asp.Net.Angular.Template.Contract.Response
{
    public class UserAccountResponse
    {
        public Guid UserAccountId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Role { get; set; }
        public bool TemporaryPassword { get; set; }
        public string VerificationLink { get; set; }
        public bool EmailVerified { get; set; }
        public bool IsLocked { get; set; }
        public bool IsDeleted { get; set; }
        public int LoginFailedCount { get; set; }
    }
}
