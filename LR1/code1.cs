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

// Фабричний метод для створення користувачів
public abstract class UserFactory {
    public abstract User CreateUser();
}

public class GuestFactory : UserFactory {
    public override User CreateUser() {
        return new Guest();
    }
}

public class RegisteredUserFactory : UserFactory {
    public override User CreateUser() {
        return new RegisteredUser();
    }
}

public class AdminFactory : UserFactory {
    public override User CreateUser() {
        return new Administrator();
    }
}

// Main class
class Program {
    static void Main(string[] args) {
        // Використання фабричного методу для створення об'єктів користувачів
        UserFactory guestFactory = new GuestFactory();
        User guest = guestFactory.CreateUser();
        guest.Name = "Guest Name";
        guest.DisplayUserInfo();

        UserFactory registeredUserFactory = new RegisteredUserFactory();
        User registeredUser = registeredUserFactory.CreateUser();
        registeredUser.Name = "Registered User Name";
        registeredUser.DisplayUserInfo();

        UserFactory adminFactory = new AdminFactory();
        User admin = adminFactory.CreateUser();
        admin.Name = "Admin Name";
        admin.DisplayUserInfo();
    }
}