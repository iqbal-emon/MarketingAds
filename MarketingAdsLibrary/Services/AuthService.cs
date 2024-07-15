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
        public async Task<User> UpdateAccount(User? user)
        {
            var existingUser = await _context.Users.FindAsync(user?.UserID);
            if (existingUser != null)
            {
                existingUser.Address = user?.Address;
                existingUser.Email = user?.Email;
                existingUser.Phone = user?.Phone;
                existingUser.Username= user?.Username;
                existingUser.PasswordHash = HashPassword(user?.PasswordHash);
                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }











        public async Task<User> LogIn(User newUser)
        {

            var password = HashPassword(newUser.PasswordHash);
            newUser.PasswordHash = password;


            var user = await _context.Users.FirstOrDefaultAsync(u =>
                    ( u.Username == newUser.Username) &&
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
