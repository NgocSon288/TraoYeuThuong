using App.Models;
using System.Threading.Tasks;

namespace App.Services
{
    public interface ILoginService
    {
        Task<int> Login(LoginViewModel request);
        Task Logout();
        Task<int> Register(RegisterViewModel request);
    }
}