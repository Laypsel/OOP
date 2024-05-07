using System;

// Клас, що представляє товар
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}

// Інтерфейс стану товару
public interface IProductState
{
    void AddProduct(Product product);
    void EditProduct(Product product);
    void DeleteProduct(int productId);
}

// Конкретний стан для додавання товару
public class AddProductState : IProductState
{
    private ProductCatalog catalog;

    public AddProductState(ProductCatalog catalog)
    {
        this.catalog = catalog;
    }

    public void AddProduct(Product product)
    {
        catalog.Products.Add(product);
        Console.WriteLine($"{product.Name} added to catalog.");
        catalog.State = new ViewProductState(catalog);
    }

    public void EditProduct(Product product)
    {
        Console.WriteLine("Cannot edit product. Add a new product instead.");
    }

    public void DeleteProduct(int productId)
    {
        Console.WriteLine("Cannot delete product. Add a new product instead.");
    }
}

// Конкретний стан для перегляду товару
public class ViewProductState : IProductState
{
    private ProductCatalog catalog;

    public ViewProductState(ProductCatalog catalog)
    {
        this.catalog = catalog;
    }

    public void AddProduct(Product product)
    {
        catalog.State = new AddProductState(catalog);
        catalog.State.AddProduct(product);
    }

    public void EditProduct(Product product)
    {
        Console.WriteLine($"{product.Name} edited.");
    }

    public void DeleteProduct(int productId)
    {
        var product = catalog.Products.Find(p => p.Id == productId);
        if (product != null)
        {
            catalog.Products.Remove(product);
            Console.WriteLine($"{product.Name} deleted from catalog.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
}

// Клас, що представляє каталог товарів
public class ProductCatalog
{
    public List<Product> Products { get; private set; }
    public IProductState State { get; set; }

    public ProductCatalog()
    {
        Products = new List<Product>();
        State = new ViewProductState(this);
    }

    public void AddProduct(Product product)
    {
        State.AddProduct(product);
    }

    public void EditProduct(Product product)
    {
        State.EditProduct(product);
    }

    public void DeleteProduct(int productId)
    {
        State.DeleteProduct(productId);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var catalog = new ProductCatalog();

        // Додавання товару
        catalog.AddProduct(new Product { Id = 1, Name = "Laptop", Price = 999.99 });
        // Спроба редагування товару
        catalog.EditProduct(new Product { Id = 1, Name = "Smartphone", Price = 699.99 });
        // Видалення товару
        catalog.DeleteProduct(1);

        Console.ReadKey();
    }
}
