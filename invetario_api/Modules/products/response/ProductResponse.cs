
using invetario_api.Modules.categories.response;
using invetario_api.Modules.images.response;
using invetario_api.Modules.products.entity;
using invetario_api.Modules.unit.response;
using System.ComponentModel.DataAnnotations;

namespace invetario_api.Modules.products.response
{
    public class ProductResponse
    {
        public int productId { get; set; }
        public string codeInternal { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public CategorySingleResponse category { get; set; }

        public UnitSingleResponse unit { get; set; }

        public float priceBuy { get; set; }
        public float priceSell { get; set; }
        public int minStock { get; set; }
        public bool status { get; set; }
        public ImageResponse image { get; set; }

        public static ProductResponse fromEntity(entity.Product product)
        {
            return new ProductResponse
            {
                productId = product.productId,
                codeInternal = product.codeInternal,
                code = product.code,
                name = product.name,
                description = product.description,
                category = CategorySingleResponse.fromEntity(product.category),
                unit = UnitSingleResponse.fromEntity(product.unit),
                priceBuy = product.priceBuy,
                priceSell = product.priceSell,
                minStock = product.minStock,
                status = product.status,
                image = ImageResponse.FromEntity(product.image)
            };
        }

        public static List<ProductResponse> fromEntityList(List<Product> products)
        {
            return products.Select(p => fromEntity(p)).ToList();
        }
    }
}
