using System;
using CategoryModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryServices.Data; // Ensure this matches your DbContext namespace

namespace CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryDbContext _context; // DbContext for DB access 

        // Dependency injection: DbContext is provided by the DI system 
        public CategoryService(CategoryDbContext context) 
        {
            _context = context;  
        }
        public IEnumerable<Category> GetAll() => _context.Categories.ToList();     // Get all categories from database  
        public Category GetById(int id) => _context.Categories.Find(id);      // Get specific category by ID from database 

        // Search categories by name in database  
        public IEnumerable<Category> SearchByName(string name) =>
            _context.Categories.Where(c => c.CategoryName.Contains(name)).ToList(); 

        public Category Add(Category category)   // Add new category to database
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }
        public bool Update(Category category)   // Update category in database
        {
            var existing = _context.Categories.Find(category.CategoryID);
            if (existing == null) return false;
            existing.CategoryName = category.CategoryName;
            existing.Description = category.Description;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)    // Delete category from database
        {
            var category = _context.Categories.Find(id);
            if (category == null) return false;
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return true;
        }
    }
} 
