using System;

// Класи для моделювання користувачів
public abstract class User {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public abstract void DisplayUserInfo();
}

public class Guest : User {
    public override void DisplayUserInfo() {
        Console.WriteLine("Guest: " + Name);
    }
}

public class RegisteredUser : User {
    public override void DisplayUserInfo() {
        Console.WriteLine("Registered User: " + Name);
    }
}

public class Administrator : User {
    public override void DisplayUserInfo() {
        Console.WriteLine("Administrator: " + Name);
    }
}

// Абстрактна фабрика для створення користувачів
public interface IUserFactory {
    User CreateUser();
}

// Конкретні фабрики для створення користувачів різних типів
public class GuestFactory : IUserFactory {
    public User CreateUser() {
        return new Guest();
    }
}

public class RegisteredUserFactory : IUserFactory {
    public User CreateUser() {
        return new RegisteredUser();
    }
}

public class AdminFactory : IUserFactory {
    public User CreateUser() {
        return new Administrator();
    }
}

// Main class
class Program {
    static void Main(string[] args) {
        // Використання абстрактної фабрики для створення об'єктів користувачів
        IUserFactory guestFactory = new GuestFactory();
        User guest = guestFactory.CreateUser();
        guest.Name = "Guest Name";
        guest.DisplayUserInfo();

        IUserFactory registeredUserFactory = new RegisteredUserFactory();
        User registeredUser = registeredUserFactory.CreateUser();
        registeredUser.Name = "Registered User Name";
        registeredUser.DisplayUserInfo();

        IUserFactory adminFactory = new AdminFactory();
        User admin = adminFactory.CreateUser();
        admin.Name = "Admin Name";
        admin.DisplayUserInfo();
    }
}