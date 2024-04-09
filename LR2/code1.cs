using System;
using System.Collections.Generic;

// Прототип гри
abstract class GamePrototype
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Platform { get; set; }
    public int AgeRating { get; set; }

    public abstract GamePrototype Clone();
}

// Конкретна реалізація прототипу гри
class Game : GamePrototype
{
    public override GamePrototype Clone()
    {
        return (GamePrototype)this.MemberwiseClone();
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine($"Platform: {Platform}");
        Console.WriteLine($"Age Rating: {AgeRating}");
        Console.WriteLine();
    }
}

// Клас для керування грою
class GameManager
{
    private Dictionary<string, GamePrototype> games = new Dictionary<string, GamePrototype>();

    public void AddGame(string key, GamePrototype game)
    {
        games.Add(key, game);
    }

    public GamePrototype GetGame(string key)
    {
        if (games.ContainsKey(key))
            return games[key].Clone();
        else
            return null;
    }

    public void DisplayGameInfo(string key)
    {
        if (games.ContainsKey(key))
            ((Game)games[key]).DisplayInfo();
        else
            Console.WriteLine("Game not found.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створюємо менеджер гри
        GameManager manager = new GameManager();

        // Додаємо деякі ігри
        manager.AddGame("game1", new Game { Title = "The Witcher 3", Genre = "RPG", Platform = "PC, PS4, Xbox One", AgeRating = 18 });
        manager.AddGame("game2", new Game { Title = "Super Mario Odyssey", Genre = "Platformer", Platform = "Nintendo Switch", AgeRating = 7 });
        manager.AddGame("game3", new Game { Title = "Grand Theft Auto V", Genre = "Action", Platform = "PC, PS4, Xbox One", AgeRating = 18 });

        // Пошук ігри за назвою
        string searchKey = "game1";
        GamePrototype foundGame = manager.GetGame(searchKey);
        if (foundGame != null)
        {
            Console.WriteLine($"Game found with key '{searchKey}':");
            ((Game)foundGame).DisplayInfo();
        }
        else
        {
            Console.WriteLine($"Game with key '{searchKey}' not found.");
        }

        // Фільтрація ігор за жанром
        string genreFilter = "Action";
        Console.WriteLine($"Games with genre '{genreFilter}':");
        foreach (var game in manager.games.Values)
        {
            if (((Game)game).Genre == genreFilter)
                ((Game)game).DisplayInfo();
        }
    }
}
