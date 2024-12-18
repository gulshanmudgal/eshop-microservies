using BuildingBlocks.CQRS;
using Catalo.API.Models;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required.");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required.");
        RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.");
    }
}

public record CreateProductResult(Guid Id);

// internal class CreateProductCommandHandler(IDocumentSession session, IValidator<CreateProductCommand> validator) : ICommandHandler<CreateProductCommand, CreateProductResult>
internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    /// <summary>
    /// Handles the creation of a new product.
    /// </summary>
    /// <param name="command">The command containing the product details.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the product creation.</returns>
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // Add the business logic here
        // Create Product entity from command object
        // Save to database
        // return CreateProductResult result with Id

        // We can use this approach when we have a single validator 
        // var result = await validator.ValidateAsync(command, cancellationToken);
        // var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

        // if (errors.Any())
        // {
        //     throw new ValidationException(errors.FirstOrDefault());
        // }

        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        // Save to Database
        session.Store(product);
        await session.SaveChangesAsync();

        return new CreateProductResult(product.Id);
    }
}
