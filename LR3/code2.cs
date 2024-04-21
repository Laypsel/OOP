using System;
using System.Collections.Generic;

// Інтерфейс спостерігача
interface IObserver {
    void Update(string order);
}

// Конкретний спостерігач
class Admin : IObserver {
    private string name;

    public Admin(string name) {
        this.name = name;
    }

    // Оновлення стану замовлення
    public void Update(string order) {
        Console.WriteLine($"Admin {name}: Order status changed to {order}");
    }
}

// Інтерфейс спостеріганого
interface ISubject {
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string order);
}

// Конкретний спостеріганий об'єкт
class OrderManager : ISubject {
    private List<IObserver> observers = new List<IObserver>();
    private string orderStatus;

    // Прикріплення спостерігача
    public void Attach(IObserver observer) {
        observers.Add(observer);
    }

    // Відкріплення спостерігача
    public void Detach(IObserver observer) {
        observers.Remove(observer);
    }

    // Оновлення статусу замовлення та сповіщення спостерігачів
    public void Notify(string order) {
        orderStatus = order;
        foreach (var observer in observers) {
            observer.Update(orderStatus);
        }
    }

    // Змінити статус замовлення
    public void ChangeOrderStatus(string newStatus) {
        Notify(newStatus);
    }
}

// Приклад використання
class Program {
    static void Main(string[] args) {
        // Створюємо спостерігачів (адміністраторів)
        Admin admin1 = new Admin("Admin 1");
        Admin admin2 = new Admin("Admin 2");

        // Створюємо спостеріганий об'єкт (менеджер замовлень)
        OrderManager orderManager = new OrderManager();

        // Приєднуємо спостерігачів до спостеріганого об'єкта
        orderManager.Attach(admin1);
        orderManager.Attach(admin2);

        // Змінюємо статус замовлення та сповіщаємо адміністраторів
        orderManager.ChangeOrderStatus("Processing");
        orderManager.ChangeOrderStatus("Shipped");
    }
}