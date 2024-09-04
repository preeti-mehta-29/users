using UserService.Models;

namespace UserService.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);        
        void AddUser(User user);
        void UpdateUser(User user);

    }
}
