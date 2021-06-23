using Final.ApplicationCore.Entitity;
using Final.ApplicationCore.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Final.ApplicationCore.RepositoryInterface
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);

        //CRUD
        Task<User> UpdateUser(int id, UserRegisterRequestModel User);
        Task<User> GetByIdAsync(int Id); // return one record under certain class on corresponding Id

        //Creating
        Task<User> AddAsync(User entity);

        //Updating
        Task<User> UpdateAsync(User entity);

        //Delete
        Task DeleteAsync(User entity);

        User GetEntityById(int Id);
        //show all
        Task<IEnumerable<User>> ListAllAsync(); // return all records under certain class
        Task<IEnumerable<User>> ListAsync(Expression<Func<User, bool>> filter);
    }
}
