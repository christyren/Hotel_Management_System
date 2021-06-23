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
    public interface IRoomserviceRepository
    {
        Task<Roomservice> UpdateRoomservice(int id, RoomserviceCreateRequestModel roomservice);
        Task<Roomservice> GetByIdAsync(int Id); // return one record under certain class on corresponding Id

        //Creating
        Task<Roomservice> AddAsync(Roomservice entity);

        //Updating
        Task<Roomservice> UpdateAsync(Roomservice entity);

        //Delete
        Task DeleteAsync(Roomservice entity);

        Roomservice GetEntityById(int Id);
        //show all
        Task<IEnumerable<Roomservice>> ListAllAsync(); // return all records under certain class
        Task<IEnumerable<Roomservice>> ListAsync(Expression<Func<Roomservice, bool>> filter);
        Task<IEnumerable<Roomservice>> GetRoomservicesByRoomNo(int RoomNo);
    }
}
