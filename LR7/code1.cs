using System;
using System.Collections.Generic;

// Клас, що представляє запитання або проблему користувача
public class Issue
{
    public string Description { get; set; }
    public DateTime Date { get; set; }

    // Конструктор
    public Issue(string description)
    {
        Description = description;
        Date = DateTime.Now;
    }

    // Метод для створення зберігача для даного стану
    public IssueMemento Save()
    {
        return new IssueMemento(Description, Date);
    }

    // Метод для відновлення стану зберігача
    public void Restore(IssueMemento memento)
    {
        Description = memento.Description;
        Date = memento.Date;
    }

    // Клас, що представляє зберігач для запитань або проблем користувача
    public class IssueMemento
    {
        public string Description { get; private set; }
        public DateTime Date { get; private set; }

        public IssueMemento(string description, DateTime date)
        {
            Description = description;
            Date = date;
        }
    }
}

// Клас, що представляє історію запитань або проблем користувачів
public class IssueHistory
{
    private Stack<Issue.IssueMemento> history = new Stack<Issue.IssueMemento>();

    // Метод для додавання нового запитання або проблеми та зберігання її стану
    public void AddIssue(Issue issue)
    {
        history.Push(issue.Save());
    }

    // Метод для відновлення останнього стану запитання або проблеми
    public void Undo()
    {
        if (history.Count > 0)
        {
            var memento = history.Pop();
            Console.WriteLine("Undoing last action...");
            Console.WriteLine($"Restored issue: {memento.Description}, Date: {memento.Date}");
        }
        else
        {
            Console.WriteLine("Nothing to undo.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення історії запитань або проблем користувачів
        var issueHistory = new IssueHistory();

        // Додавання нових запитань або проблем
        issueHistory.AddIssue(new Issue("Problem with login page"));
        issueHistory.AddIssue(new Issue("Cannot access dashboard"));

        // Відновлення останнього стану
        issueHistory.Undo(); // Undo: Cannot access dashboard
        issueHistory.Undo(); // Undo: Problem with login page
        issueHistory.Undo(); // Nothing to undo

        Console.ReadKey();
    }
}
