using System;
using System.Collections.Generic;

// Клас для представлення гри
class Game
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Platform { get; set; }
    public int AgeRating { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine($"Platform: {Platform}");
        Console.WriteLine($"Age Rating: {AgeRating}");
        Console.WriteLine();
    }
}

// Будівельник гри
interface IGameBuilder
{
    void BuildTitle();
    void BuildGenre();
    void BuildPlatform();
    void BuildAgeRating();
    Game GetGame();
}

// Конкретний будівельник гри
class ConcreteGameBuilder : IGameBuilder
{
    private Game game = new Game();

    public void BuildTitle()
    {
        game.Title = "Default Title";
    }

    public void BuildGenre()
    {
        game.Genre = "Default Genre";
    }

    public void BuildPlatform()
    {
        game.Platform = "Default Platform";
    }

    public void BuildAgeRating()
    {
        game.AgeRating = 0;
    }

    public Game GetGame()
    {
        return game;
    }
}

// Директор для будівельника гри
class GameDirector
{
    private IGameBuilder builder;

    public GameDirector(IGameBuilder builder)
    {
        this.builder = builder;
    }

    public void ConstructGame()
    {
        builder.BuildTitle();
        builder.BuildGenre();
        builder.BuildPlatform();
        builder.BuildAgeRating();
    }
}

// Клас для керування грою
class GameManager
{
    private List<Game> games = new List<Game>();

    public void AddGame(Game game)
    {
        games.Add(game);
    }

    public void DisplayGameInfo(string title)
    {
        Game foundGame = games.Find(g => g.Title == title);
        if (foundGame != null)
        {
            foundGame.DisplayInfo();
        }
        else
        {
            Console.WriteLine("Game not found.");
        }
    }

    public List<Game> FilterGamesByGenre(string genre)
    {
        return games.FindAll(g => g.Genre == genre);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення будівельника гри
        IGameBuilder builder = new ConcreteGameBuilder();
        // Створення директора
        GameDirector director = new GameDirector(builder);
        // Побудова гри
        director.ConstructGame();
        // Отримання гри
        Game game = builder.GetGame();

        // Створення менеджера гри
        GameManager manager = new GameManager();
        // Додавання гри до менеджера
        manager.AddGame(game);

        // Перегляд інформації про гру
        manager.DisplayGameInfo(game.Title);

        // Фільтрація ігор за жанром
        string genreFilter = "Default Genre";
        List<Game> filteredGames = manager.FilterGamesByGenre(genreFilter);
        Console.WriteLine($"Games with genre '{genreFilter}':");
        foreach (var g in filteredGames)
        {
            g.DisplayInfo();
        }
    }
}
