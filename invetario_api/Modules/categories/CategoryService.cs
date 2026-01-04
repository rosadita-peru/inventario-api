using invetario_api.database;
using invetario_api.Exceptions;
using invetario_api.Modules.categories.dto;
using invetario_api.Modules.categories.entity;
using invetario_api.utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace invetario_api.Modules.categories
{
    public class CategoryService : ICategoryService
    {
        private Database _db;

        public CategoryService(Database db) { 
            _db = db;
        }

        public async Task<List<Category>> getCategories()
        {
            var categories = await _db.categories.ToListAsync();


            return categories;
        }

        public async Task<Category> createCategory(CategoryDto data)
        {   

            var newCategory = new Category();
            newCategory.name = data.name;
            newCategory.description = data.description;

            await _db.categories.AddAsync(newCategory);
            await _db.SaveChangesAsync();

            return newCategory;
        }

        public async Task<Category?> deleteCategory(int categoryId)
        {
            var category = await _db.categories.FindAsync(categoryId);

            if (category == null) {
                throw new HttpException(404, "Category not found");
            }

            category.status = false;

            await _db.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> getCategoryById(int categoryId)
        {
            var findCategory = await _db.categories.FindAsync(categoryId);

            if (findCategory == null)
            {
                throw new HttpException(404, "Category not found");
            }

            return findCategory;
        }

        public async Task<Category?> updateCategory(int categoryId, UpdateCategoryDto data)
        {
            var findCategory = await _db.categories.FindAsync(categoryId);

            if (findCategory == null)
            {
                throw new HttpException(404, "Category not found");
            }

            findCategory.name = data.name;
            findCategory.description = data.description;
            findCategory.status = (bool)data.status!;

            await _db.SaveChangesAsync();

            return findCategory;
        }
    }
}
