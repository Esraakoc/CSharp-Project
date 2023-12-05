using System;
using System.Collections.Generic;

public class UserManager
{
    private List<User> users = new List<User>();
    private EmailValidator emailValidator = new EmailValidator();
    private PasswordValidator passwordValidator = new PasswordValidator();

    public User GetUserByEmail(string email)
    {
        return users.Find(user => user.Email == email);
    }

    public bool Register(string firstName, string lastName, string email, string password)
    {
        if (!emailValidator.Validate(email))
        {
            Console.WriteLine("Email format is incorrect.");
            return false;
        }

        if (!passwordValidator.Validate(password))
        {
            Console.WriteLine("Password is too weak. It should be at least 6 characters long.");
            return false;
        }

        if (GetUserByEmail(email) != null)
        {
            Console.WriteLine("A user with this email already exists.");
            return false;
        }

        if (firstName.Length < 2 || lastName.Length < 2)
        {
            Console.WriteLine("First name and last name should be at least 2 characters long.");
            return false;
        }

        User user = new User(firstName, lastName, email, password);
        users.Add(user);

        Console.WriteLine("User registered successfully. Verification email has been sent.");
        return true;
    }

    public User Login(string email, string password)
    {
        User user = GetUserByEmail(email);

        if (user != null && user.Password == password)
        {
            Console.WriteLine("Login successful.");
            return user;
        }

        Console.WriteLine("Login failed. Please check your email and password.");
        return null;
    }

    public void SendVerificationEmail(User user)
    {
        Console.WriteLine("Verification email sent to " + user.Email);
    }
}