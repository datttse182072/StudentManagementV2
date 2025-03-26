using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Helper
{
    public static class CurrentAccount
    {
        public static int AccountId { get; set; }

        public static string Username { get; set; } = null!;

        public static string PasswordHash { get; set; } = null!;

        public static string Role { get; set; } = null!;

        public static void SetAccount(int accountId, string username, string passwordHash, string role)
        {
            AccountId = accountId;
            Username = username;
            PasswordHash = passwordHash;
            Role = role;
        }

        public static void Clear()
        {
            AccountId = 0; 
            Username = null!;
            PasswordHash = null!; 
            Role = null!; 
        }
    }
}
