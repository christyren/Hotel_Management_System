using Final.ApplicationCore.Entitity;
using Final.ApplicationCore.Model.Request;
using Final.ApplicationCore.RepositoryInterface;
using Final.ApplicationCore.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Infrastructure.Service
{
    public class RoomtypeService: IRoomtypeService
    {
        private readonly IRoomtypeRepository _roomtypeRepository;

        public RoomtypeService(IRoomtypeRepository roomtypeRepository)
        {
            _roomtypeRepository = roomtypeRepository;

        }

        public async Task<bool> AddRoomtype(RoomtypeCreateRequestModel roomtype)
        {


            var r = new Roomtype
            {
                RTDesc = roomtype.RTDesc,
                Rent = roomtype.Rent,

            };
            var createdRoom = _roomtypeRepository.AddAsync(r);

            if (createdRoom != null && createdRoom.Id > 0)
            {
                return true;
            }

            return false;
        }

        public async Task DeleteRoomtypeById(int id)
        {
            var res = _roomtypeRepository.GetByIdAsync(id).Result;
            if (res == null)
            {
                Console.WriteLine("not found Room with Id:" + id);
            }
            else
            {
                await _roomtypeRepository.DeleteAsync(res);
            }
        }

        public async Task<Roomtype> GetRoomById(int id)
        {
            return await _roomtypeRepository.GetByIdAsync(id);
        }

        public async Task<Roomtype> GetRoomtypeById(int id)
        {
            return await _roomtypeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Roomtype>> ListAll()
        {
            return await _roomtypeRepository.ListAllAsync();
        }

        public async Task<Roomtype> UpdateRoom(int id, RoomtypeCreateRequestModel roomtype)
        {
            return await _roomtypeRepository.UpdateRoomtype(id, roomtype);
        }

        public async Task<Roomtype> UpdateRoomtype(int id, RoomtypeCreateRequestModel roomtype)
        {
            return await _roomtypeRepository.UpdateRoomtype(id, roomtype);
        }
    }
}
