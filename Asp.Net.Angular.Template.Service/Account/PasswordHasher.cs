using System;
using System.Collections.Generic;
using System.Text;
using Asp.Net.Angular.Template.Abstraction.Interface;
using Asp.Net.Angular.Template.DataEntity;

namespace Asp.Net.Angular.Template.Service.Account
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(UserAccount userAccount, string password)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var passwordSalt = Convert.ToBase64String(hmac.Key);
                var passwordHashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                var passwordHash = Convert.ToBase64String(passwordHashBytes);

                userAccount.PasswordSalt = passwordSalt;
                userAccount.Password = passwordHash;
                return passwordHash;
            }

        }

        public bool VerifyHashedPassword(UserAccount userAccount, string storedPassword, string password)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            //if (userAccount.Password.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            //if (userAccount.PasswordSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(Convert.FromBase64String(userAccount.PasswordSalt)))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                var passwordHash = Convert.ToBase64String(computedHash);

                return passwordHash == storedPassword;
            }
        }
    }
}
