namespace Catalog.API.Products.GetProducts;

public record GetProductsResposnse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var result = await sender.Send(new GetProductsQuery());
            var response = result.Adapt<GetProductsResposnse>();
            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<GetProductsResposnse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Get Products")
        .WithDescription("Get Products")
        .WithTags("Products");
    }
}