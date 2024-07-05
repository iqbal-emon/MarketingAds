using MarketingAds.Data;
using MarketingAds.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
           _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<User> LogIn(User User)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u =>
                    (u.Username == User.Username || u.Email == User.Email) &&
                    u.PasswordHash == User.PasswordHash);

            return user;
        }
       
    }
}
