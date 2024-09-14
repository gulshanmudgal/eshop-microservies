
namespace Catalog.API.Products.GetProducts;

public record GetProductResult(IEnumerable<Product> Products);
public record GetProductsQuery() : IQuery<GetProductResult>;

public class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger) : IQueryHandler<GetProductsQuery, GetProductResult>
{
    /// <summary>
    /// Handles the GetProductsQuery and returns a list of products.
    /// </summary>
    /// <param name="query">The query object containing the parameters for retrieving products.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a GetProductResult object with the list of products.</returns>
    public async Task<GetProductResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsQueryHandler.Handle called with {query}", query);

        var products = await session.Query<Product>().ToListAsync(cancellationToken);
        return new GetProductResult(products);
    }
}