using Final.ApplicationCore.Entitity;
using Final.ApplicationCore.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.ApplicationCore.ServiceInterface
{
    public interface IRoomserviceService
    {
        Task<Roomservice> GetRoomserviceById(int id);
        Task<Roomservice> UpdateRoomservice(int id, RoomserviceCreateRequestModel roomservice);
        Task DeleteRoomserviceById(int id);
        Task<bool> AddRoomservice(RoomserviceCreateRequestModel roomservice);
        Task<IEnumerable<Roomservice>> ListAll();
        Task<IEnumerable<Roomservice>> GetRoomservicesByRoomNo(int RoomNo);


    }
}
