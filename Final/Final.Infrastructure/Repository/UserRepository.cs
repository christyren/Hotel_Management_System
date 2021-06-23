using Final.ApplicationCore.Entitity;
using Final.ApplicationCore.Model.Request;
using Final.ApplicationCore.RepositoryInterface;
using Final.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Final.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly FinalDbContext _dbContext;
        public UserRepository(FinalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddAsync(User entity)
        {
            _dbContext.Set<User>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public User GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmail(string email)
        {

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public Task<IEnumerable<User>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> ListAsync(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(int id, UserRegisterRequestModel User)
        {
            throw new NotImplementedException();
        }
    }
}
