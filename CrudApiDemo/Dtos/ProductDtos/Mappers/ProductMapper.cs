using CrudApiDemo.Models;

namespace CrudApiDemo.Dtos.ProductDtos.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public static List<ProductDto> ToProductDtoList(this List<Product> products)
        {
            return products.Select(p => p.ToProductDto()).ToList();
        }

        public static Product ToProductEntity(this CreateProductDto dto)
        {
            return new Product
            {
                Name = dto.Name,
                Price = dto.Price
            };
        }
    }
}
