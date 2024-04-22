using System;
using System.Collections.Generic;

// Інтерфейс команди
interface ICommand {
    void Execute();
}

// Конкретна команда для перегляду інформації про гру
class ViewGameInfoCommand : ICommand {
    private GameInfoReceiver receiver;

    public ViewGameInfoCommand(GameInfoReceiver receiver) {
        this.receiver = receiver;
    }

    public void Execute() {
        receiver.ViewGameInfo();
    }
}

// Отримувач команд
class GameInfoReceiver {
    public void ViewGameInfo() {
        Console.WriteLine("Displaying game information:");
        Console.WriteLine("- Name: The Witcher 3: Wild Hunt");
        Console.WriteLine("- Description: An action role-playing game developed by CD Projekt Red.");
        Console.WriteLine("- Genre: Action RPG");
        Console.WriteLine("- Rating: 9.3/10");
        Console.WriteLine("- Age Restrictions: 18+");
        Console.WriteLine("- Price: $29.99");
    }
}

// Клас, що представляє макрокоманду
class MacroCommand : ICommand {
    private List<ICommand> commands = new List<ICommand>();

    // Додавання окремої команди до макрокоманди
    public void AddCommand(ICommand command) {
        commands.Add(command);
    }

    // Виконання всіх команд у макрокоманді
    public void Execute() {
        foreach (var command in commands) {
            command.Execute();
        }
    }
}

// Приклад використання
class Program {
    static void Main(string[] args) {
        // Створюємо отримувача команд (інформація про гру)
        GameInfoReceiver receiver = new GameInfoReceiver();

        // Створюємо окремі команди для перегляду різних аспектів інформації про гру
        ICommand viewNameCommand = new ViewGameInfoCommand(receiver);
        ICommand viewDescriptionCommand = new ViewGameInfoCommand(receiver);
        ICommand viewGenreCommand = new ViewGameInfoCommand(receiver);
        ICommand viewRatingCommand = new ViewGameInfoCommand(receiver);
        ICommand viewAgeRestrictionsCommand = new ViewGameInfoCommand(receiver);
        ICommand viewPriceCommand = new ViewGameInfoCommand(receiver);

        // Створюємо макрокоманду для перегляду всієї інформації про гру
        MacroCommand viewGameInfoMacroCommand = new MacroCommand();
        viewGameInfoMacroCommand.AddCommand(viewNameCommand);
        viewGameInfoMacroCommand.AddCommand(viewDescriptionCommand);
        viewGameInfoMacroCommand.AddCommand(viewGenreCommand);
        viewGameInfoMacroCommand.AddCommand(viewRatingCommand);
        viewGameInfoMacroCommand.AddCommand(viewAgeRestrictionsCommand);
        viewGameInfoMacroCommand.AddCommand(viewPriceCommand);

        // Виконуємо макрокоманду для перегляду інформації про гру
        viewGameInfoMacroCommand.Execute();
    }
}
