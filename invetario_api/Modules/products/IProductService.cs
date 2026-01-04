using invetario_api.Modules.products.dto;
using invetario_api.Modules.products.response;

namespace invetario_api.Modules.products
{
    public interface IProductService
    {
        Task<List<ProductResponse>> getProducts();

        Task<ProductResponse?> getProductById(int productId);

        Task<ProductResponse?> createProduct(ProductDto product);

        Task<ProductResponse?> updateProduct(int productId, UpdateProductDto product);

        Task<ProductResponse?> deleteProduct(int productId);
    }
}
