using Yas.UserService.Domain;

namespace Yas.UserService.Application.Interfaces
{
    public interface IUserProvider
    {
        Task<User> GetUserAsync(string username);
        Task<IEnumerable<User>> GetAllAsync();
        Task<bool> DeleteAsync(string name);
    }
}
