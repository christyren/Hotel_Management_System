using Final.ApplicationCore.Entitity;
using Final.ApplicationCore.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.ApplicationCore.ServiceInterface
{
    public interface IRoomtypeService
    {
        Task<Roomtype> GetRoomtypeById(int id);
        Task<Roomtype> UpdateRoomtype(int id, RoomtypeCreateRequestModel roomtype);
        Task DeleteRoomtypeById(int id);
        Task<bool> AddRoomtype(RoomtypeCreateRequestModel roomtype);
        Task<IEnumerable<Roomtype>> ListAll();
    }
}
