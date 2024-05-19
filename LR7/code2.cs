using System;
using System.Collections.Generic;

// Базовий клас для елементів, які будуть відвідуватися
public interface IVisitable
{
    void Accept(IVisitor visitor);
}

// Конкретний клас для гри
public class Game : IVisitable
{
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }

    public Game(string title, DateTime releaseDate)
    {
        Title = title;
        ReleaseDate = releaseDate;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Конкретний клас для акції
public class Promotion : IVisitable
{
    public string Description { get; set; }
    public DateTime ValidUntil { get; set; }

    public Promotion(string description, DateTime validUntil)
    {
        Description = description;
        ValidUntil = validUntil;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Інтерфейс відвідувача
public interface IVisitor
{
    void Visit(Game game);
    void Visit(Promotion promotion);
}

// Конкретний відвідувач для формування розсилок
public class NewsletterVisitor : IVisitor
{
    public void Visit(Game game)
    {
        Console.WriteLine($"New Game Release: {game.Title}, Release Date: {game.ReleaseDate.ToShortDateString()}");
    }

    public void Visit(Promotion promotion)
    {
        Console.WriteLine($"New Promotion: {promotion.Description}, Valid Until: {promotion.ValidUntil.ToShortDateString()}");
    }
}

// Клас для керування розсилками
public class Newsletter
{
    private List<IVisitable> items = new List<IVisitable>();

    public void AddItem(IVisitable item)
    {
        items.Add(item);
    }

    public void Generate(IVisitor visitor)
    {
        foreach (var item in items)
        {
            item.Accept(visitor);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення об'єктів для гри та акції
        var game = new Game("Cyberpunk 2077", new DateTime(2023, 12, 10));
        var promotion = new Promotion("50% off on all RPGs", new DateTime(2023, 12, 31));

        // Створення розсилки
        var newsletter = new Newsletter();
        newsletter.AddItem(game);
        newsletter.AddItem(promotion);

        // Формування розсилки з використанням відвідувача
        var newsletterVisitor = new NewsletterVisitor();
        newsletter.Generate(newsletterVisitor);

        Console.ReadKey();
    }
}
