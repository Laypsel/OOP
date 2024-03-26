using System;

// Абстрактний клас для продукту
abstract class Product
{
    public string Name { get; set; }
    public double Price { get; set; }

    public abstract void Info();
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

// Абстрактний клас будівельника
abstract class Builder
{
    public abstract void SetName(string name);
    public abstract void SetPrice(double price);
    public abstract void BuildProduct();
    public abstract Product GetResult();
}

// Конкретний будівельник для продукту "гра"
class GameBuilder : Builder
{
    private Game _game = new Game();

    public override void SetName(string name)
    {
        _game.Name = name;
    }

    public override void SetPrice(double price)
    {
        _game.Price = price;
    }

    public override void BuildProduct()
    {
        // Додаткові дії для побудови продукту "гра", наприклад, вибір платформи
        _game.Platform = "PC";
    }

    public override Product GetResult()
    {
        return _game;
    }
}

// Конкретний будівельник для продукту "платформа"
class PlatformBuilder : Builder
{
    private Platform _platform = new Platform();

    public override void SetName(string name)
    {
        _platform.Name = name;
    }

    public override void SetPrice(double price)
    {
        _platform.Price = price;
    }

    public override void BuildProduct()
    {
        // Додаткові дії для побудови продукту "платформа", наприклад, вибір типу
        _platform.Type = "Console";
    }

    public override Product GetResult()
    {
        return _platform;
    }
}

// Директор, який використовує будівельника
class Director
{
    private Builder _builder;

    public Director(Builder builder)
    {
        _builder = builder;
    }

    public void Construct(string name, double price)
    {
        _builder.SetName(name);
        _builder.SetPrice(price);
        _builder.BuildProduct();
    }

    public Product GetResult()
    {
        return _builder.GetResult();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створюємо директора
        Director director = new Director(new GameBuilder());

        // Конструюємо продукт "гра"
        director.Construct("Cyberpunk 2077", 59.99);
        Product game = director.GetResult();

        // Виводимо інформацію про продукт "гра"
        game.Info();

        // Змінюємо будівельника для побудови продукту "платформа"
        director = new Director(new PlatformBuilder());

        // Конструюємо продукт "платформа"
        director.Construct("PlayStation 5", 499.99);
        Product platform = director.GetResult();

        // Виводимо інформацію про продукт "платформа"
        platform.Info();
    }
}
