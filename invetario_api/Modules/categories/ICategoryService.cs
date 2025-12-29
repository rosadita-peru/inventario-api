using invetario_api.Modules.categories.dto;
using invetario_api.Modules.categories.entity;
using invetario_api.utils;

namespace invetario_api.Modules.categories
{
    public interface ICategoryService
    {
        public Task<List<Category>> getCategories();

        public Task<Category?> getCategoryById(int categoryId);

        public Task<Category> createCategory(CategoryDto data);

        public Task<Category?> updateCategory(int categoryId, UpdateCategoryDto data);

        public Task<Category?> deleteCategory(int categoryId);
    }
}
