public class PasswordValidator
{
    public bool Validate(string password)
    {
        return password.Length >= 6;
    }
}