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
        public async Task<User> CreateAccount(User user)
        {
            var password = HashPassword(user.PasswordHash);
            user.PasswordHash = password;
            user.UserRole = "Buyer";
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<User> LogIn(User newUser)
        {

            var password = HashPassword(newUser.PasswordHash);
            newUser.PasswordHash = password;


            var user = await _context.Users.FirstOrDefaultAsync(u =>
                    ( u.Email == newUser.Email) &&
                    u.PasswordHash == newUser.PasswordHash&& u.StatusId==1);

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
