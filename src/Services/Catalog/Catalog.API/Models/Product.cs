namespace Catalo.API.Models;

/// <summary>
/// Entity representing a product in the catalog.
/// </summary>
public class Product
{
    /// <summary>
    /// Unique identifier for the product.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Product name.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// List of categories for the product.
    /// </summary>
    public List<string> Category { get; set; } = new();

    /// <summary>
    /// Product description.
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Image file name for the product.
    /// </summary>
    public string ImageFile { get; set; } = default!;

    /// <summary>
    /// Price for the product.
    /// </summary>
    public decimal Price { get; set; }
}
