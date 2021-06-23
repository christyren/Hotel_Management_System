using Final.ApplicationCore.Entitity;
using Final.ApplicationCore.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.ApplicationCore.ServiceInterface
{
    public interface IRoomService
    {
        Task<Room> GetRoomById(int id);
        Task<Room> UpdateRoom(int id, RoomCreateRequestModel room);
        Task DeleteRoomById(int id);
        Task<bool> AddRoom(RoomCreateRequestModel room);
        Task<IEnumerable<Room>> ListAll();

    }
}
