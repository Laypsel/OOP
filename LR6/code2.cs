using System;

// Клас, що представляє користувача
public class User
{
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Address { get; private set; }
    private Mediator mediator;

    public User(string username, string password, string address, Mediator mediator)
    {
        Username = username;
        Password = password;
        Address = address;
        this.mediator = mediator;
    }

    // Метод для зміни адреси
    public void ChangeAddress(string newAddress)
    {
        Address = newAddress;
        mediator.Notify(this, "AddressChanged");
    }

    // Метод для зміни паролю
    public void ChangePassword(string newPassword)
    {
        Password = newPassword;
        mediator.Notify(this, "PasswordChanged");
    }
}

// Абстрактний клас посередника
public abstract class Mediator
{
    public abstract void Notify(User user, string action);
}

// Конкретний клас посередника для зміни особистих даних
public class PersonalDataMediator : Mediator
{
    public override void Notify(User user, string action)
    {
        switch (action)
        {
            case "AddressChanged":
                Console.WriteLine($"User {user.Username} changed address to: {user.Address}");
                break;
            case "PasswordChanged":
                Console.WriteLine($"User {user.Username} changed password");
                break;
            default:
                break;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення посередника для зміни особистих даних
        var personalDataMediator = new PersonalDataMediator();

        // Створення користувача
        var user = new User("john_doe", "123456", "Old Address", personalDataMediator);

        // Зміна адреси
        user.ChangeAddress("New Address");

        // Зміна паролю
        user.ChangePassword("654321");

        Console.ReadKey();
    }
}
