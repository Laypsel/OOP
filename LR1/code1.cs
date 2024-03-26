using System;

// Базовий клас ігри
public abstract class Game
{
    public abstract void Play();
}

// Конкретна реалізація гри на платформі PC
public class PCGame : Game
{
    public override void Play()
    {
        Console.WriteLine("Playing the game on PC.");
    }
}

// Конкретна реалізація гри на платформі Xbox
public class XboxGame : Game
{
    public override void Play()
    {
        Console.WriteLine("Playing the game on Xbox.");
    }
}

// Конкретна реалізація гри на платформі PlayStation
public class PlayStationGame : Game
{
    public override void Play()
    {
        Console.WriteLine("Playing the game on PlayStation.");
    }
}

// Фабричний метод для створення обєктів типу "гра"
public abstract class GameFactory
{
    public abstract Game CreateGame();
}

// Фабрика для створення ігор для PC
public class PCGameFactory : GameFactory
{
    public override Game CreateGame()
    {
        return new PCGame();
    }
}

// Фабрика для створення ігор для Xbox
public class XboxGameFactory : GameFactory
{
    public override Game CreateGame()
    {
        return new XboxGame();
    }
}

// Фабрика для створення ігор для PlayStation

public class PlayStationGameFactory : GameFactory
{
    public override Game CreateGame()
    {
        return new PlayStationGame();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Вибираємо платформу для гри
        string platform = "PC"; // Можна змінити на "Xbox" або "PlayStation"

        // Створюємо відповідну фабрику ігор
        GameFactory gameFactory = null;
        switch (platform)
        {
            case "PC":
                gameFactory = new PCGameFactory();
                break;
            case "Xbox":
                gameFactory = new XboxGameFactory();
                break;
            case "PlayStation":
                gameFactory = new PlayStationGameFactory();
                break;
            default:
                throw new ArgumentException("Invalid platform");
        }

        // Створюємо гру відповідно до вибраної платформи
        Game game = gameFactory.CreateGame();

        // Граємо в гру
        game.Play();
    }
}
