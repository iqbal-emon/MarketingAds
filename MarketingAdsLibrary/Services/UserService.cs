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
    public class UserService
    {
        private readonly Marketing _context;

        public UserService(Marketing context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.Where(u=>u.UserRole!="Admin").ToListAsync();
        }

        public async Task<bool> StatusChanged(int roleId,int statusId)
        {
            var existingUser = await _context.Users.FindAsync(roleId);
            if (existingUser != null)
            {
                existingUser.StatusId = statusId;
                _context.Users.Update(existingUser);
                 await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }


        
    }
}
