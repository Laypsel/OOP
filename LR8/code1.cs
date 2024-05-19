using System;

// Підсистема 1: Управління запасами
public class InventorySystem
{
    public void UpdateInventory(string product, int quantity)
    {
        Console.WriteLine($"Inventory updated: {product}, Quantity: {quantity}");
    }

    public int CheckInventory(string product)
    {
        // Тут можна було б звернутися до бази даних або іншої системи для перевірки запасів
        Console.WriteLine($"Checking inventory for: {product}");
        return 100; // Повертаємо фіксоване значення для прикладу
    }
}

// Підсистема 2: Управління замовленнями
public class OrderSystem
{
    public void CreateOrder(string product, int quantity)
    {
        Console.WriteLine($"Order created: {product}, Quantity: {quantity}");
    }

    public void CancelOrder(string product, int quantity)
    {
        Console.WriteLine($"Order cancelled: {product}, Quantity: {quantity}");
    }
}

// Підсистема 3: Управління доставкою
public class ShippingSystem
{
    public void ShipProduct(string product, int quantity)
    {
        Console.WriteLine($"Product shipped: {product}, Quantity: {quantity}");
    }
}

// Фасад для синхронізації зі складом
public class WarehouseFacade
{
    private InventorySystem inventorySystem;
    private OrderSystem orderSystem;
    private ShippingSystem shippingSystem;

    public WarehouseFacade()
    {
        inventorySystem = new InventorySystem();
        orderSystem = new OrderSystem();
        shippingSystem = new ShippingSystem();
    }

    public void SyncProduct(string product, int quantity)
    {
        Console.WriteLine($"Synchronizing product: {product}, Quantity: {quantity}");
        int inventory = inventorySystem.CheckInventory(product);
        
        if (inventory >= quantity)
        {
            orderSystem.CreateOrder(product, quantity);
            inventorySystem.UpdateInventory(product, -quantity);
            shippingSystem.ShipProduct(product, quantity);
        }
        else
        {
            Console.WriteLine($"Not enough inventory for: {product}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення фасаду для синхронізації зі складом
        var warehouseFacade = new WarehouseFacade();

        // Синхронізація продукту
        warehouseFacade.SyncProduct("Dead Island 2", 1250);

        Console.ReadKey();
    }
}
