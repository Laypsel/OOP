using System;
using System.Collections.Generic;

// Інтерфейс реалізації для перевірки наявності товару
public interface IInventoryImplementation
{
    int GetStock(string product);
}

// Конкретна реалізація для перевірки наявності товару в реальному складі
public class RealInventoryImplementation : IInventoryImplementation
{
    private Dictionary<string, int> productStock;

    public RealInventoryImplementation()
    {
        // Ініціалізація запасів товару для прикладу
        productStock = new Dictionary<string, int>
        {
            { "Cyberpunk 2077", 100 },
            { "Mario Odessy", 0 },
            { "Dead Island 2", 75 }
        };
    }

    public int GetStock(string product)
    {
        Console.WriteLine($"Checking stock in RealInventory for: {product}");
        if (productStock.ContainsKey(product))
        {
            return productStock[product];
        }
        else
        {
            return 0; // Якщо продукт не знайдено, повертаємо 0
        }
    }
}

// Абстракція для перевірки наявності товару
public abstract class Inventory
{
    protected IInventoryImplementation implementation;

    protected Inventory(IInventoryImplementation implementation)
    {
        this.implementation = implementation;
    }

    public abstract void CheckStock(string product);
}

// Конкретна абстракція для відображення результатів перевірки наявності товару
public class InventoryChecker : Inventory
{
    public InventoryChecker(IInventoryImplementation implementation) : base(implementation) { }

    public override void CheckStock(string product)
    {
        int stock = implementation.GetStock(product);
        if (stock > 0)
        {
            Console.WriteLine($"Stock for {product}: {stock}");
        }
        else
        {
            Console.WriteLine($"{product} is out of stock.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення реалізації для реального складу
        IInventoryImplementation realInventory = new RealInventoryImplementation();

        // Створення абстракції з використанням конкретної реалізації
        Inventory inventory = new InventoryChecker(realInventory);

        // Перевірка наявності товару
        inventory.CheckStock("Cyberpunk 2077");
        inventory.CheckStock("Mario Odessy");
        inventory.CheckStock("Dead Island 2");

        Console.ReadKey();
    }
}
