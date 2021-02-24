using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTSAPI.DBContexts;
using VTSAPI.Models;

namespace VTSAPI.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int user);
        void InsertUser(User user);
        void DeleteUser(int userId);
        void UpdateUser(User user);
        void Save();
    }
    public class UserRepository:IUserRepository
    {
        private readonly UserContext _dbContext;
        public UserRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<User> GetUsers()
        {
            return _dbContext.User.ToList();
        }
        public User GetUserByID(int productId)
        {
            return _dbContext.User.Find(productId);
        }
        public void InsertUser(User user)
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
        public void DeleteUser(int userId)
        {
            var user = _dbContext.User.Find(userId);
            _dbContext.User.Remove(user);
            Save();
        }
    }
}
