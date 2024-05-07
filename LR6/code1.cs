using System;
using System.Collections.Generic;

// Клас, що представляє замовлення
public class Order
{
    public int OrderId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
}

// Інтерфейс інтерпретатора
public interface IOrderInterpreter
{
    void Interpret(List<Order> orders);
}

// Конкретний інтерпретатор для перегляду історії замовлень
public class OrderHistoryInterpreter : IOrderInterpreter
{
    public void Interpret(List<Order> orders)
    {
        Console.WriteLine("Order History:");
        foreach (var order in orders)
        {
            Console.WriteLine($"Order ID: {order.OrderId}, Date: {order.Date}, Description: {order.Description}");
        }
    }
}

// Клас, що представляє історію замовлень
public class OrderHistory
{
    private List<Order> orders = new List<Order>();

    // Додавання замовлення до історії
    public void AddOrder(Order order)
    {
        orders.Add(order);
    }

    // Метод для перегляду історії замовлень
    public void ViewOrderHistory(IOrderInterpreter interpreter)
    {
        interpreter.Interpret(orders);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення історії замовлень
        var orderHistory = new OrderHistory();
        orderHistory.AddOrder(new Order { OrderId = 1, Date = DateTime.Now, Description = "Test order 1" });
        orderHistory.AddOrder(new Order { OrderId = 2, Date = DateTime.Now.AddDays(-1), Description = "Test order 2" });
        orderHistory.AddOrder(new Order { OrderId = 3, Date = DateTime.Now.AddDays(-2), Description = "Test order 3" });

        // Перегляд історії замовлень за допомогою інтерпретатора
        var orderHistoryInterpreter = new OrderHistoryInterpreter();
        orderHistory.ViewOrderHistory(orderHistoryInterpreter);

        Console.ReadKey();
    }
}
