using MediatR;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, string Category, string Description, string ImageFile, decimal Price) : IRequest<CreateProductResponse>;

public record CreateProductResponse(Guid Id);

internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    public Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Add the business logic here
        throw new NotImplementedException();
    }
}
