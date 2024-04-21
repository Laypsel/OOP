using System;
using System.Collections.Generic;

// Клас, що представляє товар
class Product {
    public string Name { get; set; }
    public double Price { get; set; }
}

// Контекст стратегії
class ShoppingCart {
    private List<Product> products = new List<Product>();
    private IAddToCartStrategy addToCartStrategy;

    // Встановлення стратегії
    public void SetAddToCartStrategy(IAddToCartStrategy strategy) {
        addToCartStrategy = strategy;
    }

    // Додавання товару до кошика
    public void AddProductToCart(Product product) {
        addToCartStrategy.AddToCart(products, product);
        Console.WriteLine($"Product '{product.Name}' added to cart.");
    }

    // Виведення товарів у кошику
    public void DisplayCartItems() {
        Console.WriteLine("Items in the shopping cart:");
        foreach (var product in products) {
            Console.WriteLine($"- {product.Name}: ${product.Price}");
        }
    }
}

// Інтерфейс стратегії
interface IAddToCartStrategy {
    void AddToCart(List<Product> products, Product product);
}

// Конкретні стратегії додавання товару до кошика
class NormalAddToCartStrategy : IAddToCartStrategy {
    public void AddToCart(List<Product> products, Product product) {
        products.Add(product);
    }
}

class DiscountedAddToCartStrategy : IAddToCartStrategy {
    public void AddToCart(List<Product> products, Product product) {
        product.Price *= 0.9; // Знижка 10%
        products.Add(product);
    }
}

// Приклад використання
class Program {
    static void Main(string[] args) {
        ShoppingCart cart = new ShoppingCart();

        // Вибираємо стратегію додавання товару до кошика (знижка або без)
        cart.SetAddToCartStrategy(new NormalAddToCartStrategy());
        // cart.SetAddToCartStrategy(new DiscountedAddToCartStrategy());

        // Додаємо товари до кошика
        Product product1 = new Product { Name = "Game 1", Price = 50 };
        cart.AddProductToCart(product1);

        Product product2 = new Product { Name = "Game 2", Price = 60 };
        cart.AddProductToCart(product2);

        // Виводимо вміст кошика
        cart.DisplayCartItems();
    }
}