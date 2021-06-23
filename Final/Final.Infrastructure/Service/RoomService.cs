using Final.ApplicationCore.Entitity;
using Final.ApplicationCore.Exceptions;
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
    public class RoomService:IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;

        }

        public async Task<bool> AddRoom(RoomCreateRequestModel room)
        {


            var r = new Room
            {
                RTCode = room.RTCode,
                Status = room.Status,

            };
            var createdRoom = _roomRepository.AddAsync(r);

            if (createdRoom != null && createdRoom.Id > 0)
            {
                return true;
            }

            return false;
        }

        public async Task DeleteRoomById(int id)
        {
            var res = _roomRepository.GetByIdAsync(id).Result;
            if (res == null)
            {
                Console.WriteLine("not found Room with Id:" + id);
            }
            else
            {
                await _roomRepository.DeleteAsync(res);
            }
        }



        public async Task<Room> GetRoomById(int id)
        {
            return await _roomRepository.GetByIdAsync(id);
        }



        public async Task<IEnumerable<Room>> ListAll()
        {
            return await _roomRepository.ListAllAsync();
        }

        public async Task<Room> UpdateRoom(int id, RoomCreateRequestModel room)
        {
            return await _roomRepository.UpdateRoom(id, room);
        }


    }
}
