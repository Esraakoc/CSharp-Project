using System.Threading.Tasks;

namespace EK.Business.Services.Interfaces
{
    public interface IMailService
    {
        Task SendPasswordResetEmailAsync(string email, string resetToken);
     
    }
}
