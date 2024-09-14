namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product Product);

public class GetProductyIdQueryHandler(IDocumentSession session, ILogger<GetProductyIdQueryHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsQueryHandler.Handle called with {query}", query.Id);


        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundExceptin();
        }

        return new GetProductByIdResult(product);
    }
}