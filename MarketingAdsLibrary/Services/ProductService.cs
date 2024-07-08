using MarketingAds.Data;
using MarketingAds.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingAdsLibrary.Services
{
    public class ProductService
    {
        private readonly Marketing _context;


        public ProductService(Marketing context) // Modify constructor to inject IWebHostEnvironment
        {
            _context = context;
            
        }

        public async Task<List<Listing>> GetProduct()
        {
            return await _context.Listings.Include(l => l.Images).ToListAsync();
        }

        public async Task<bool> AddProduct(Listing listing, IFormFile imageFile)
        {
            if (listing.Images == null || !listing.Images.Any())
            {
                var uploadsFolderPath = GenerateUploadsFolderPath(); // Generate dynamic folder path
                listing.Images = new List<Image>
        {
            await SaveImageToServer(imageFile, uploadsFolderPath)
        };
            }

            _context.Listings.Add(listing);
            await _context.SaveChangesAsync();

            return true;
        }

        private async Task<Image> SaveImageToServer(IFormFile imageFile, string uploadsFolderPath)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var imageName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var imagePath = Path.Combine(uploadsFolderPath, imageName);

                using (var stream = System.IO.File.Create(imagePath))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // Return relative URL instead of local path
                var relativePath = Path.Combine("uploads", imageName); // Example relative path
                return new Image { ImageURL = relativePath };
            }
            else
            {
                return null;
            }
        }

        private string GenerateUploadsFolderPath()
        {
            // Generate a dynamic folder path based on current date, GUID, etc.
            var uploadsFolderName = $"uploads_{DateTime.Now:yyyyMMdd}";
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads", uploadsFolderName); // Example path, adjust as per your project structure
        }


        public async Task<bool> DeleteAsync(int productToDelete)
        {
            var product = await _context.Listings.FindAsync(productToDelete);

            if (product != null)
            {
                product.StatusId = 3;
                _context.Listings.Update(product);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<Listing> GetProductById(int listingID)
        {
            return await _context.Listings.FirstOrDefaultAsync(l => l.ListingID == listingID);
        }

        public async Task<bool> UpdateProduct(Listing updateProduct)
        {
            var existingProduct = await _context.Listings.FindAsync(updateProduct.ListingID);

            if (existingProduct != null)
            {
                existingProduct.Title = updateProduct.Title;
                existingProduct.Description = updateProduct.Description;
                existingProduct.Price = updateProduct.Price;
                existingProduct.CategoryID = updateProduct.CategoryID;
                existingProduct.Location = updateProduct.Location;
                existingProduct.Condition = updateProduct.Condition;
                existingProduct.StatusId = updateProduct.StatusId;
                _context.Listings.Update(existingProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
