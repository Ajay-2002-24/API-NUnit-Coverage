using System;
using System.Collections.Generic;
using CategoryModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll(); // Get all categories
        Category GetById(int id); // Get by ID

        IEnumerable<Category> SearchByName(string name);  // Search by name
        Category Add(Category category); // Add new category
        bool Update(Category category); // Update existing
        bool Delete(int id);  // Remove by ID




    }
}
