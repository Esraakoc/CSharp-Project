
class Program
{
    static void Main(string[] args)
    {
        UserManager userManager = new UserManager();

        userManager.Register("Sena", "Kara", "senakara@gmail.com", "123456"); // success
        userManager.Register("Beyza", "Gürel", "gbeyza@gmail.com", "12345");
        userManager.Register("Sena", "kara", "senakara@gmail.com", "123456");
        userManager.Login("senakara@gmail.com", "123456");
    }
}