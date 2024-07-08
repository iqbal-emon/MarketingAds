using MarketingAds.Data;
using MarketingAds.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MarketingAdsLibrary.Services
{
    public class AuthService
    {
        private readonly Marketing _context;

        public AuthService(Marketing context)
        {
            _context = context;
        }
        public async Task CreateAccount(User user)
        {
            var password = HashPassword(user.PasswordHash);
            user.PasswordHash = password;
            user.UserRole = "Buyer";
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<User> LogIn(User User)
        {

            var password = HashPassword(User.PasswordHash);
            User.PasswordHash = password;


            var user = await _context.Users.FirstOrDefaultAsync(u =>
                    (u.Username == User.Username || u.Email == User.Email) &&
                    u.PasswordHash == User.PasswordHash);

            return user;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return password = Convert.ToBase64String(hashedBytes);
            }
        }

    }
}
