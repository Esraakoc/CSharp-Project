public class EmailValidator
{
    private const string EMAIL_REGEX = "^[A-Za-z0-9+.-]+@gmail.com$";

    public bool Validate(string email)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(email, EMAIL_REGEX);
    }
}