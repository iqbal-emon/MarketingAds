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
    public class CategoryService
    {
        private readonly Marketing _context;

        public CategoryService(Marketing context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetCategory()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task <bool>AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> deleteAsync(int categoryToDelete)
        {
            var categoryTo = await _context.Categories.FindAsync(categoryToDelete);

            if (categoryTo != null)
            {
                // Update the StatusId here
                categoryTo.StatusId = 3;
                _context.Categories.Update(categoryTo);
                // Save changes to the database
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(c=>c.CategoryID == categoryId);
        }
        public async Task <bool>updatedateCategory(Category updateCategory)
        {
            var existingCategory = await _context.Categories.FindAsync(updateCategory.CategoryID);

            if (existingCategory != null)
            {
                existingCategory.CategoryName = updateCategory.CategoryName;
                existingCategory.StatusId = updateCategory.StatusId;
                _context.Categories.Update(existingCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}
