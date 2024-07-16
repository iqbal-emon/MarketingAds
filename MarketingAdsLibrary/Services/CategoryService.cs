using MarketingAds.Data;
using MarketingAds.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MarketingAdsLibrary.Services
{
    public class CategoryService
    {
        private readonly Marketing _context;

        public CategoryService(Marketing context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetCategory()
        {
            return await _context.Categories.Include(c=>c.Listings).ToListAsync();
        }
        public async Task<List<CategoryListingSummary>> GetListingBasedCategoryCount()
        {
            var query = from c in _context.Categories
                        join l in _context.Listings on c.CategoryID equals l.CategoryID into listingGroup
                        from lg in listingGroup.DefaultIfEmpty()
                        join i in _context.Images on lg.CategoryID equals i.CategoryID into imageGroup
                        from ig in imageGroup.DefaultIfEmpty()
                        group new { lg, ig } by new { c.CategoryID, c.CategoryName } into g
                        select new CategoryListingSummary
                        {
                            CategoryID = g.Key.CategoryID,
                            CategoryName = g.Key.CategoryName,
                            ListingCount = g.Count(x => x.lg != null),
                            ImageUrl = g.Select(x => x.ig.ImageURL).FirstOrDefault()  // Retrieves the first ImageUrl found for the Category
                        };

            var result = await query.ToListAsync();

            return result;
        }













        public async Task<List<Listing>> GetListingBasedCategory(int CategoryId)
        {
            return await _context.Listings.Where(l => l.CategoryID == CategoryId).Include(l=>l.Category).Include(l=>l.Location).Include(l=>l.Images).ToListAsync();
                
  }








        public async Task <Category>AddCategory(Category category,string imagePath)
        {
            Image image = new();
            image.StatusId = 1;
            image.ImageURL = imagePath;
            image.CategoryID = _context.Categories.Count()+1;
            _context.Images.Add(image);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category> deleteAsync(int categoryToDelete)
        {
            var categoryTo = await _context.Categories.FindAsync(categoryToDelete);

            if (categoryTo != null)
            {
                // Update the StatusId here
                categoryTo.StatusId = 3;
                _context.Categories.Update(categoryTo);
                // Save changes to the database
                await _context.SaveChangesAsync();

                return categoryTo;
            }

            return null;
        }
        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(c=>c.CategoryID == categoryId);
        }
        public async Task <Category>updatedateCategory(Category updateCategory)
        {
            var existingCategory = await _context.Categories.FindAsync(updateCategory.CategoryID);

            if (existingCategory != null)
            {
                existingCategory.CategoryName = updateCategory.CategoryName;
                existingCategory.StatusId = updateCategory.StatusId;
                _context.Categories.Update(existingCategory);
                await _context.SaveChangesAsync();
                return existingCategory;
            }
            return null;
        }


    }
}
