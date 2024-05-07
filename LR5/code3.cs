using System;

// Клас, що представляє замовлення
public class Order
{
    public int OrderId { get; set; }
    public string Description { get; set; }
    public bool IsProcessed { get; set; }
}

// Абстрактний обробник замовлення
public abstract class OrderHandler
{
    protected OrderHandler successor;

    public void SetSuccessor(OrderHandler successor)
    {
        this.successor = successor;
    }

    public abstract void ProcessOrder(Order order);
}

// Конкретний обробник для перевірки замовлення
public class OrderValidationHandler : OrderHandler
{
    public override void ProcessOrder(Order order)
    {
        // Виконати перевірку замовлення
        Console.WriteLine($"Validating order {order.OrderId}");

        if (order.Description.Length > 5)
        {
            Console.WriteLine("Order is valid. Passing to next handler.");
            successor?.ProcessOrder(order);
        }
        else
        {
            Console.WriteLine("Invalid order. Processing stopped.");
        }
    }
}

// Конкретний обробник для обробки замовлення
public class OrderProcessingHandler : OrderHandler
{
    public override void ProcessOrder(Order order)
    {
        // Виконати обробку замовлення
        Console.WriteLine($"Processing order {order.OrderId}");

        order.IsProcessed = true;
        Console.WriteLine("Order processed successfully.");
    }
}

// Клас, що представляє систему управління замовленнями
public class OrderManager
{
    private OrderHandler orderHandler;

    public OrderManager()
    {
        // Конфігурація ланцюжка обов'язків
        orderHandler = new OrderValidationHandler();
        var processingHandler = new OrderProcessingHandler();
        orderHandler.SetSuccessor(processingHandler);
    }

    public void ProcessOrder(Order order)
    {
        orderHandler.ProcessOrder(order);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення системи управління замовленнями
        var orderManager = new OrderManager();

        // Створення тестового замовлення
        var order = new Order { OrderId = 1, Description = "Test order" };

        // Обробка замовлення
        orderManager.ProcessOrder(order);

        Console.ReadKey();
    }
}
