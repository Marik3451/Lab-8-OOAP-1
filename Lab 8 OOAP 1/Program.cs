using System;
using System.Collections.Generic;

public interface IChatMediator
{
    void SendMessage(User user, string message);
}

public class ChatMediator : IChatMediator
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void SendMessage(User user, string message)
    {
        foreach (var u in users)
        {
            if (u != user)
            {
                u.Receive(message);
            }
        }
    }
}

public class User
{
    private string name;
    private IChatMediator chatMediator;

    public User(string name, IChatMediator chatMediator)
    {
        this.name = name;
        this.chatMediator = chatMediator;
    }

    public void Send(string message)
    {
        Console.WriteLine($"{name} відправляє повідомлення: {message}");
        chatMediator.SendMessage(this, message);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"{name} отримує повідомлення: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ChatMediator chatMediator = new ChatMediator();

        User user1 = new User("Петро", chatMediator);
        User user2 = new User("Марія", chatMediator);
        User user3 = new User("Іван", chatMediator);

        chatMediator.AddUser(user1);
        chatMediator.AddUser(user2);
        chatMediator.AddUser(user3);

        user1.Send("Привіт всім!");
        user2.Send("Привіт, Петро!");
        user3.Send("1488");
    }
}
