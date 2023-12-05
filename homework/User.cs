public class User
{
    private string firstName;
    private string lastName;
    private string email;
    private string password;

    public User(string firstName, string lastName, string email, string password)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.password = password;
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string Password
    {
        get { return password; }
        set { password = value; }
    }
}