using System;

// Абстрактний клас ігри
abstract class Game
{
    public abstract void Play();
}

// Конкретні реалізації ігор
class PCGame : Game
{
    public override void Play()
    {
        Console.WriteLine("Playing PC game");
    }
}

class XboxGame : Game
{
    public override void Play()
    {
        Console.WriteLine("Playing Xbox game");
    }
}

class PlayStationGame : Game
{
    public override void Play()
    {
        Console.WriteLine("Playing PlayStation game");
    }
}

// Абстрактний клас платформи
abstract class Platform
{
    public abstract void Run();
}

// Конкретні реалізації платформ
class PCPlatform : Platform
{
    public override void Run()
    {
        Console.WriteLine("Running on PC");
    }
}

class XboxPlatform : Platform
{
    public override void Run()
    {
        Console.WriteLine("Running on Xbox");
    }
}

class PlayStationPlatform : Platform
{
    public override void Run()
    {
        Console.WriteLine("Running on PlayStation");
    }
}

// Абстрактна фабрика для створення сімейств ігор та платформ
abstract class GameFactory
{
    public abstract Game CreateGame();
    public abstract Platform CreatePlatform();
}

// Конкретні фабрики
class PCGameFactory : GameFactory
{
    public override Game CreateGame()
    {
        return new PCGame();
    }

    public override Platform CreatePlatform()
    {
        return new PCPlatform();
    }
}

class XboxGameFactory : GameFactory
{
    public override Game CreateGame()
    {
        return new XboxGame();
    }

    public override Platform CreatePlatform()
    {
        return new XboxPlatform();
    }
}

class PlayStationGameFactory : GameFactory
{
    public override Game CreateGame()
    {
        return new PlayStationGame();
    }

    public override Platform CreatePlatform()
    {
        return new PlayStationPlatform();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Використання абстрактної фабрики
        GameFactory pcFactory = new PCGameFactory();
        Game pcGame = pcFactory.CreateGame();
        Platform pcPlatform = pcFactory.CreatePlatform();
        pcGame.Play();
        pcPlatform.Run();

        GameFactory xboxFactory = new XboxGameFactory();
        Game xboxGame = xboxFactory.CreateGame();
        Platform xboxPlatform = xboxFactory.CreatePlatform();
        xboxGame.Play();
        xboxPlatform.Run();

        GameFactory playStationFactory = new PlayStationGameFactory();
        Game playStationGame = playStationFactory.CreateGame();
        Platform playStationPlatform = playStationFactory.CreatePlatform();
        playStationGame.Play();
        playStationPlatform.Run();
    }
}
