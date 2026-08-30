//using CrudApiDemo.Dtos.ProductDtos;
//using CrudApiDemo.Dtos.ProductDtos.Mappers;
//using CrudApiDemo.Interfaces.IService;
//using CrudApiDemo.Models;

//namespace CrudApiDemo.Extensions.Endpoints
//{
//    public static class ProductsEndpoints
//    {
//        public static void MapProductEndpoints(this IEndpointRouteBuilder app)
//        {
//            app.MapGet("/getAllProducts", (ICrudService<Product> service) =>
//            {
//                return Results.Ok(service.GetAll().ToProductDtoList());
//            });

//            app.MapGet("/getProduct/{id}", (int id, ICrudService<Product> service) =>
//            {
//                var product = service.GetById(id);
//                return product is null
//                    ? Results.NotFound(new { message = "Invalid product ID." })
//                    : Results.Ok(product.ToProductDto());
//            });

//            app.MapPost("/addNewProduct", (CreateProductDto newProductDto, ICrudService<Product> service) =>
//            {
//                var newProduct = newProductDto.ToProductEntity();
//                var success = service.Add(newProduct);

//                return success
//                    ? Results.Created($"/getProduct/{newProduct.Id}", new { message = "Product added successfully." })
//                    : Results.BadRequest(new { message = "Product could not be added." });
//            });

//            app.MapDelete("/deleteProduct/{id}", (int id, ICrudService<Product> service) =>
//            {
//                return service.Delete(id)
//                    ? Results.Ok(new { message = "Product deleted successfully." })
//                    : Results.NotFound(new { message = "Invalid product ID." });
//            });

//            app.MapPatch("/updateProductName/{id}", (int id, string newName, IProductService service) =>
//            {
//                return service.UpdateName(id, newName)
//                    ? Results.Ok(new { message = "Product name updated successfully." })
//                    : Results.NotFound(new { message = "Invalid product ID." });
//            });

//            app.MapPatch("/updateProductPrice/{id}", (int id, decimal newPrice, IProductService service) =>
//            {
//                return service.UpdatePrice(id, newPrice)
//                    ? Results.Ok(new { message = "Product price updated successfully." })
//                    : Results.NotFound(new { message = "Invalid product ID." });
//            });
//        }


//    }
//}
