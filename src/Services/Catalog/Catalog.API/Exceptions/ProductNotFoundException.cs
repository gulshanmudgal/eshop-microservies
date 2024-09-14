namespace Catalog.API.Exceptions;

public class ProductNotFoundExceptin : Exception
{
    public ProductNotFoundExceptin() : base("Product not found.")
    {
    }
}