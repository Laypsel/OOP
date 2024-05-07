using System;
using System.Collections;
using System.Collections.Generic;

// Клас, що представляє ігру
public class Game
{
    public string Name { get; set; }
    public string Genre { get; set; }
    public int AgeRating { get; set; }
    public string Platform { get; set; }
    public string Franchise { get; set; }
    public float Rating { get; set; }
}

// Інтерфейс фільтра
public interface IFilter
{
    bool Matches(Game game);
}

// Конкретний фільтр за жанром
public class GenreFilter : IFilter
{
    private string genre;

    public GenreFilter(string genre)
    {
        this.genre = genre;
    }

    public bool Matches(Game game)
    {
        return game.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase);
    }
}

// Конкретний фільтр за віковим обмеженням
public class AgeRatingFilter : IFilter
{
    private int ageRating;

    public AgeRatingFilter(int ageRating)
    {
        this.ageRating = ageRating;
    }

    public bool Matches(Game game)
    {
        return game.AgeRating <= ageRating;
    }
}

// Колекція ігор з ітератором для фільтрації
public class GameCollection : IEnumerable<Game>
{
    private List<Game> games = new List<Game>();

    public void AddGame(Game game)
    {
        games.Add(game);
    }

    public IEnumerator<Game> GetEnumerator()
    {
        return new GameIterator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Ітератор для фільтрації
    private class GameIterator : IEnumerator<Game>
    {
        private GameCollection collection;
        private int currentIndex = -1;
        private List<IFilter> filters = new List<IFilter>();

        public GameIterator(GameCollection collection)
        {
            this.collection = collection;
        }

        public Game Current => collection.games[currentIndex];

        object IEnumerator.Current => Current;

        public void Dispose() {}

        public bool MoveNext()
        {
            while (++currentIndex < collection.games.Count)
            {
                if (PassesFilters(collection.games[currentIndex]))
                    return true;
            }
            return false;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        // Перевіряє, чи ігра відповідає усім фільтрам
        private bool PassesFilters(Game game)
        {
            foreach (var filter in filters)
            {
                if (!filter.Matches(game))
                    return false;
            }
            return true;
        }

        // Додати фільтр
        public void AddFilter(IFilter filter)
        {
            filters.Add(filter);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення колекції ігор
        var gameCollection = new GameCollection();
        gameCollection.AddGame(new Game { Name = "The Witcher 3", Genre = "RPG", AgeRating = 18, Platform = "PC", Franchise = "The Witcher", Rating = 9.7f });
        gameCollection.AddGame(new Game { Name = "Super Mario Odyssey", Genre = "Platformer", AgeRating = 3, Platform = "Nintendo Switch", Franchise = "Mario", Rating = 9.5f });
        gameCollection.AddGame(new Game { Name = "Grand Theft Auto V", Genre = "Action", AgeRating = 18, Platform = "PlayStation", Franchise = "GTA", Rating = 9.6f });

        // Додавання фільтрів
        var iterator = (GameCollection.GameIterator)gameCollection.GetEnumerator();
        iterator.AddFilter(new GenreFilter("RPG"));
        iterator.AddFilter(new AgeRatingFilter(16));

        // Вивід відфільтрованих ігор
        Console.WriteLine("Filtered Games:");
        while (iterator.MoveNext())
        {
            var game = iterator.Current;
            Console.WriteLine($"Name: {game.Name}, Genre: {game.Genre}, Age Rating: {game.AgeRating}, Platform: {game.Platform}, Franchise: {game.Franchise}, Rating: {game.Rating}");
        }
    }
}