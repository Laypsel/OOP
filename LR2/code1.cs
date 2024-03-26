using System;

// Абстрактний клас для продукту
abstract class Product : ICloneable
{
    public string Name { get; set; }
    public double Price { get; set; }

    public abstract void Info();

    public object Clone()
    {
        // Використовуємо поверхневе копіювання (shallow copy)
        return this.MemberwiseClone();
    }
}

// Конкретна реалізація продукту "гра"
class Game : Product
{
    public string Platform { get; set; }

    public override void Info()
    {
        Console.WriteLine($"Game: {Name}, Platform: {Platform}, Price: {Price}$");
    }
}

// Конкретна реалізація продукту "платформа"
class Platform : Product
{
    public string Type { get; set; }

    public override void Info()
    {
        Console.WriteLine($"Platform: {Name}, Type: {Type}, Price: {Price}$");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створюємо оригінальний об'єкт "гра"
        Game originalGame = new Game { Name = "Cyberpunk 2077", Platform = "PC", Price = 59.99 };

        // Клонуємо оригінальний об'єкт "гра"
        Game clonedGame = (Game)originalGame.Clone();
        clonedGame.Name = "Assassin's Creed Valhalla";

        // Виводимо інформацію про оригінальний та клонований об'єкти "гра"
        Console.WriteLine("Original Game:");
        originalGame.Info();
        Console.WriteLine("\nCloned Game:");
        clonedGame.Info();

        // Створюємо оригінальний об'єкт "платформа"
        Platform originalPlatform = new Platform { Name = "PlayStation 5", Type = "Console", Price = 499.99 };

        // Клонуємо оригінальний об'єкт "платформа"
        Platform clonedPlatform = (Platform)originalPlatform.Clone();
        clonedPlatform.Name = "Xbox Series X";

        // Виводимо інформацію про оригінальний та клонований об'єкти "платформа"
        Console.WriteLine("\nOriginal Platform:");
        originalPlatform.Info();
        Console.WriteLine("\nCloned Platform:");
        clonedPlatform.Info();
    }
}
