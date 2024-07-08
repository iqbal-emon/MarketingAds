using MarketingAds.Data;
using MarketingAds.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarketingAdsLibrary.Services
{
    public class StatusService
    {
        private readonly Marketing _context;

        public StatusService(Marketing context)
        {
            _context = context;
        }
        public async Task<List<Status>> GetStatus()
        {
            return await _context.Status.ToListAsync();
        }
        public async Task <bool>AddStatus(Status status)
        {
            _context.Status.Add(status);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> deleteAsync(int statusId)
        {
            var statusToDelete = await _context.Status.FindAsync(statusId);

            if (statusToDelete != null)
            {
                _context.Status.Remove(statusToDelete);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
        public async Task<Status> GetStatusById(int statusId)
        {
            return await _context.Status.FirstOrDefaultAsync(r => r.Id == statusId);
        }
        public async Task <bool>updatedateStatus(Status updateStatus)
        {
            var existingStatus = await _context.Status.FindAsync(updateStatus.Id);

            if (existingStatus != null)
            {
                existingStatus.Name = updateStatus.Name;
                existingStatus.ShorForm = updateStatus.ShorForm;
                _context.Status.Update(existingStatus);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
