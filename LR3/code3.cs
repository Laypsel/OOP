using System;

// Інтерфейс команди
interface ICommand {
    void Execute();
}

// Конкретна команда для оформлення замовлення
class PlaceOrderCommand : ICommand {
    private OrderReceiver receiver;

    public PlaceOrderCommand(OrderReceiver receiver) {
        this.receiver = receiver;
    }

    public void Execute() {
        receiver.PlaceOrder();
    }
}

// Конкретна команда для скасування замовлення
class CancelOrderCommand : ICommand {
    private OrderReceiver receiver;

    public CancelOrderCommand(OrderReceiver receiver) {
        this.receiver = receiver;
    }

    public void Execute() {
        receiver.CancelOrder();
    }
}

// Отримувач команд
class OrderReceiver {
    public void PlaceOrder() {
        Console.WriteLine("Order placed successfully.");
    }

    public void CancelOrder() {
        Console.WriteLine("Order cancelled successfully.");
    }
}

// Інвокер команд
class OrderInvoker {
    private ICommand command;

    public void SetCommand(ICommand command) {
        this.command = command;
    }

    public void ExecuteCommand() {
        command.Execute();
    }
}

// Приклад використання
class Program {
    static void Main(string[] args) {
        // Створюємо отримувача команд (менеджер замовлень)
        OrderReceiver receiver = new OrderReceiver();

        // Створюємо команди для оформлення та скасування замовлення
        ICommand placeOrderCommand = new PlaceOrderCommand(receiver);
        ICommand cancelOrderCommand = new CancelOrderCommand(receiver);

        // Створюємо інвокера команд
        OrderInvoker invoker = new OrderInvoker();

        // Встановлюємо команду для виконання та виконуємо її
        invoker.SetCommand(placeOrderCommand);
        invoker.ExecuteCommand();

        // Встановлюємо іншу команду та виконуємо її
        invoker.SetCommand(cancelOrderCommand);
        invoker.ExecuteCommand();
    }
}