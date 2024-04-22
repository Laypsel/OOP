using System;

// Базовий клас з алгоритмом оплати і доставки
abstract class OrderProcessTemplate {
    // Шаблонний метод, який виконує весь процес оплати і доставки
    public void ProcessOrder() {
        SelectPaymentMethod();
        ProcessPayment();
        Pack();
        Ship();
        Deliver();
    }

    // Абстрактні методи, які потрібно реалізувати в конкретних підкласах
    protected abstract void SelectPaymentMethod();
    protected abstract void ProcessPayment();
    protected abstract void Pack();
    protected abstract void Ship();
    protected abstract void Deliver();
}

// Конкретний клас з реалізацією алгоритму для онлайн-оплати та електронної доставки
class OnlineOrderProcess : OrderProcessTemplate {
    protected override void SelectPaymentMethod() {
        Console.WriteLine("Selecting online payment method...");
    }

    protected override void ProcessPayment() {
        Console.WriteLine("Processing online payment...");
    }

    protected override void Pack() {
        Console.WriteLine("Packing items...");
    }

    protected override void Ship() {
        Console.WriteLine("Shipping items electronically...");
    }

    protected override void Deliver() {
        Console.WriteLine("Items delivered electronically.");
    }
}

// Конкретний клас з реалізацією алгоритму для оплати при отриманні та фізичної доставки
class CashOnDeliveryProcess : OrderProcessTemplate {
    protected override void SelectPaymentMethod() {
        Console.WriteLine("Selecting cash on delivery payment method...");
    }

    protected override void ProcessPayment() {
        Console.WriteLine("Processing payment upon delivery...");
    }

    protected override void Pack() {
        Console.WriteLine("Packing items...");
    }

    protected override void Ship() {
        Console.WriteLine("Shipping items...");
    }

    protected override void Deliver() {
        Console.WriteLine("Items delivered and payment collected.");
    }
}

// Приклад використання
class Program {
    static void Main(string[] args) {
        Console.WriteLine("Processing online order:");
        OrderProcessTemplate onlineOrder = new OnlineOrderProcess();
        onlineOrder.ProcessOrder();

        Console.WriteLine("\nProcessing cash on delivery order:");
        OrderProcessTemplate codOrder = new CashOnDeliveryProcess();
        codOrder.ProcessOrder();
    }
}
