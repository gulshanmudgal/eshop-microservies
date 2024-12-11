
namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;
public record GetProductsByCategoryResult(IEnumerable<Product> Products);

public class GetProductByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductByCategoryQueryHandler> logger) : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsByCategoryQueryHandler.Handle called with {query}", request.Category);

        var products = await session.Query<Product>().Where(p => p.Category.Contains(request.Category)).ToListAsync();

        return new GetProductsByCategoryResult(products);
    }
}