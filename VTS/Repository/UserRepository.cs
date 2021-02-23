using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTS.DBContexts;
using VTS.Models;

namespace VTS.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUser();
        Task<bool> AddUsers(User user);
        Task<bool> UpdateUsers(User user);
    }
    public class UserRepository : IUserRepository
    {
        private readonly VTSTestContext _dbContext;

        public UserRepository(VTSTestContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<User> GetUser()
        {
            return _dbContext.User.ToList();
        }
        public async Task<bool> AddUsers(User input)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var user = _dbContext.User.FirstOrDefault(x => x.UserID == input.UserID);
                    if (user == null)
                    {
                        User us = new User
                        {
                            UserID = input.UserID,
                            Name = input.Name,
                            MobNo = input.MobNo,
                            Organization = input.Organization,
                            Address = input.Address,
                            EmailId = input.EmailId,
                            Location = input.Location,
                            photopath = input.photopath
                        };
                        await _dbContext.User.AddRangeAsync(us);
                    }
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return true;

        }
        public async Task<bool> UpdateUsers(User input)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var users = _dbContext.User.FirstOrDefault(x => x.UserID == input.UserID);
                    if (users != null)
                    {
                        User us = new User
                        {
                            UserID = input.UserID,
                            Name = input.Name,
                            MobNo = input.MobNo,
                            Organization = input.Organization,
                            Address = input.Address,
                            EmailId = input.EmailId,
                            Location = input.Location,
                            photopath = input.photopath
                        };
                    }
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return true;

        }
    }
}
