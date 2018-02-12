using System.Threading.Tasks;
using DatingApp.api.Models;

namespace DatingApp.api.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> LoginAsync(string username, string password);
         Task<bool> UserExistsAsync(string username);
    }
}