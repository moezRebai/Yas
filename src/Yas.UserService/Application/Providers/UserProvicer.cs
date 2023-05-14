using Yas.UserService.Application.Interfaces;
using Yas.UserService.Domain;

namespace Yas.UserService.Application.Providers
{
    public class UserProvicer : IUserProvider
    {
        IList<User> _users;
        
        public UserProvicer()
        {
            _users= new List<User>()
            {
                new User("Moez", 34, "21 RUE DES CARNETS, 92140 CLAMART", DateTime.Today),
                new User("Hela", 34, "21 RUE DES CARNETS, 92140 CLAMART", DateTime.Today),
                new User("Yasmine", 2, "21 RUE DES CARNETS, 92140 CLAMART", DateTime.Today),
            };
        }

        public Task<bool> DeleteAsync(string name)
        {

            return Task.FromResult(_users.Remove(_users.FirstOrDefault(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await Task.FromResult(_users.FirstOrDefault(u 
                => u.Name.Equals(username, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}
