using System;
using System.ComponentModel.DataAnnotations;

namespace Asp.Net.Angular.Template.DataEntity
{
    public class UserAccount : EntityBase, IEntityFields
    {
        [Key]
        public Guid UserAccountId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string ContactNo { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Role { get; set; }
        public bool TemporaryPassword { get; set; }
        public string VerificationLink { get; set; }
        public bool EmailVerified { get; set; }
        public bool IsLocked { get; set; }
        public int LoginFailedCount { get; set; }

        public Guid Identity { get => UserAccountId; set => UserAccountId = value; }
    }
}
