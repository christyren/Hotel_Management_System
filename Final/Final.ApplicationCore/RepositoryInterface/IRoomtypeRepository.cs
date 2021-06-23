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
    public interface IRoomtypeRepository
    {
        Task<Roomtype> UpdateRoomtype(int id, RoomtypeCreateRequestModel roomtype);
        Task<Roomtype> GetByIdAsync(int Id); // return one record under certain class on corresponding Id

        //Creating
        Task<Roomtype> AddAsync(Roomtype entity);

        //Updating
        Task<Roomtype> UpdateAsync(Roomtype entity);

        //Delete
        Task DeleteAsync(Roomtype entity);

        Roomtype GetEntityById(int Id);
        //show all
        Task<IEnumerable<Roomtype>> ListAllAsync(); // return all records under certain class
        Task<IEnumerable<Roomtype>> ListAsync(Expression<Func<Roomtype, bool>> filter);
    }
}
