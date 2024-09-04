using Microsoft.EntityFrameworkCore;
using UserService.DBContext;
using UserService.Models;

namespace UserService.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _dbContext;

        public UserRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public void DeleteProduct(int id)
        //{
        //    var product = _dbContext.Users.Find(productId);
        //    _dbContext.Products.Remove(product);
        //    Save();
        //}

        public User GetUserById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void AddUser(User user)
        {
            _dbContext.Add(user);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            Save();
        }
    }
}