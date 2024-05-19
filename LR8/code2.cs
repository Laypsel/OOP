using System;
using System.Collections.Generic;

// Інтерфейс для отримання інформації про запаси товару
public interface IInventory
{
    int GetStock(string product);
}

// Реальна реалізація, яка звертається до складу
public class RealInventory : IInventory
{
    private Dictionary<string, int> productStock;

    public RealInventory()
    {
        // Ініціалізація запасів товару для прикладу
        productStock = new Dictionary<string, int>
        {
            { "Cyberpunk 2077", 100 },
            { "Mario Odessy", 25 },
            { "Dead Island 2", 50 }
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

// Замісник, який кешує інформацію про запаси товару
public class InventoryProxy : IInventory
{
    private RealInventory realInventory;
    private Dictionary<string, int> cache;

    public InventoryProxy()
    {
        realInventory = new RealInventory();
        cache = new Dictionary<string, int>();
    }

    public int GetStock(string product)
    {
        if (cache.ContainsKey(product))
        {
            Console.WriteLine($"Returning cached stock for: {product}");
            return cache[product];
        }
        else
        {
            int stock = realInventory.GetStock(product);
            cache[product] = stock;
            return stock;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення замісника для отримання інформації про запаси товару
        IInventory inventory = new InventoryProxy();

        // Отримання інформації про запаси товару
        Console.WriteLine($"Stock for Cyberpunk 2077: {inventory.GetStock("Cyberpunk 2077")}");
        Console.WriteLine($"Stock for Mario Odessy: {inventory.GetStock("Mario Odessy")}");

        // Повторний запит для перевірки кешування
        Console.WriteLine($"Stock for Cyberpunk 2077 (cached): {inventory.GetStock("Cyberpunk 2077")}");
        Console.WriteLine($"Stock for Mario Odessy (cached): {inventory.GetStock("Mario Odessy")}");

        Console.ReadKey();
    }
}
