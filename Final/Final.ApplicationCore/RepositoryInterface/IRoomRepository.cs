using Final.ApplicationCore.Entitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Final.ApplicationCore.Model.Request;

namespace Final.ApplicationCore.RepositoryInterface
{
    public interface IRoomRepository
    {
        Task<Room> UpdateRoom(int id,  RoomCreateRequestModel room);
        Task<Room> GetByIdAsync(int Id); // return one record under certain class on corresponding Id

        //Creating
        Task<Room> AddAsync(Room entity);

        //Updating
        Task<Room> UpdateAsync(Room entity);

        //Delete
        Task DeleteAsync(Room entity);

        Room GetEntityById(int Id);
        //show all
        Task<IEnumerable<Room>> ListAllAsync(); // return all records under certain class
        Task<IEnumerable<Room>> ListAsync(Expression<Func<Room, bool>> filter);


    }
}
