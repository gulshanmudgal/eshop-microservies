using BuildingBlocks.Exceptions;

namespace Catalog.API.Exceptions;

public class ProductNotFoundExceptin : NotFoundException
{
    public ProductNotFoundExceptin(Guid Id) : base("product", Id)
    {
    }
}