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


        public ProductService(Marketing context)
        {
            _context = context;
            
        }

        public async Task<List<Listing>> GetProduct()
        {
            return await _context.Listings.Include(l => l.Images).Include(l => l.Category)
        .Include(l => l.Location).ToListAsync();
        }
        public async Task<List<Listing>> getProductRecent()
        {
            return await _context.Listings
                .Include(l => l.Images)
                .Include(l => l.Category)
                .Include(l => l.Location)
                .OrderByDescending(l => l.PostedDate) 
                .Take(12) 
                .ToListAsync(); 
        }



        public async Task<Listing> GetProductDetails(int ListingId)
        {
            return await _context.Listings
                .Include(l => l.Images)
                .Include(l => l.Category)
                .Include(l => l.Location).
                Include(l=>l.User)
                .FirstOrDefaultAsync(l => l.ListingID == ListingId);
        }

        

        public async Task<Listing?> AddProduct(Listing listing, string imagePath)
        {

            try
            {
                if (listing.Images == null || !listing.Images.Any())
                {

                    listing.Images = new List<Image>
            {
                  new Image { ImageURL = imagePath } 
            };
                }

                _context.Listings.Add(listing);
                await _context.SaveChangesAsync();

                return listing;
            }
            catch (Exception ex) {
                return null;
            }
        }
        public void DeleteImageFromServer(string imageName)
        {
            string uploadsFolderPath = GenerateUploadsFolderPath();
            var imagePath = Path.Combine(uploadsFolderPath, imageName);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
            else
            {
                throw new ArgumentException("Image not found or unable to delete.");
            }
        }

        public async Task<string> SaveImageToServer(IFormFile imageFile)
        {
            string uploadsFolderPath = GenerateUploadsFolderPath();
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
                var relativePath = Path.Combine("uploads", Path.GetFileName(uploadsFolderPath), imageName);
                return relativePath;
            }
            else
            {
                return null;
            }
        }

        public string GenerateUploadsFolderPath()
        {
            // Path to the uploads directory within wwwroot
            var uploadsRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            // Generate a dynamic folder path based on the current date
            var uploadsFolderName = DateTime.Now.ToString("yyyyMMdd");
            return Path.Combine(uploadsRootPath, uploadsFolderName);
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

        public async Task<Listing> UpdateProduct(Listing updateProduct)
        {
            var existingProduct = await _context.Listings.FindAsync(updateProduct.ListingID);

            if (existingProduct != null)
            {
                existingProduct.Title = updateProduct.Title;
                existingProduct.Description = updateProduct.Description;
                existingProduct.Price = updateProduct.Price;
                existingProduct.CategoryID = updateProduct.CategoryID;
                existingProduct.LocationID = updateProduct.LocationID;
                existingProduct.Condition = updateProduct.Condition;
                existingProduct.StatusId = updateProduct.StatusId;
                _context.Listings.Update(existingProduct);
                await _context.SaveChangesAsync();
                return existingProduct;
            }
            return null;
        }
    }
}
