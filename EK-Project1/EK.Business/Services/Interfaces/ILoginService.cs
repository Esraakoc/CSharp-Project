using EK.Business.Dto;
using EK.Entities.Models;
using System.Threading.Tasks;

namespace EK.Business.Services.Interfaces
{
    public interface ILoginService
    {
        Task<EkUser?> LoginAsync(LoginDto loginDto);
    } 
}
 