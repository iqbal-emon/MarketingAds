using MarketingAds.Data;
using MarketingAds.Models;
using Microsoft.EntityFrameworkCore;


namespace MarketingAdsLibrary.Services
{
    public class LocationService
    {
        private readonly Marketing _context;

        public LocationService(Marketing context)
        {
            _context = context;
        }

        public async Task<List<Location>> GetLocation()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<bool> AddLocation(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int locationToDelete)
        {
            var location = await _context.Locations.FindAsync(locationToDelete);

            if (location != null)
            {
                // Update the StatusId here
                location.StatusId = 3;
                _context.Locations.Update(location);
                // Save changes to the database
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<Location> GetLocationById(int locationId)
        {
            return await _context.Locations.FirstOrDefaultAsync(l => l.LocationID == locationId);
        }

        public async Task<bool> UpdateLocation(Location updateLocation)
        {
            var existingLocation = await _context.Locations.FindAsync(updateLocation.LocationID);

            if (existingLocation != null)
            {
                existingLocation.LocationName = updateLocation.LocationName;
                existingLocation.StatusId = updateLocation.StatusId;
                _context.Locations.Update(existingLocation);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }

}
