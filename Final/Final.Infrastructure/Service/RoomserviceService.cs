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

    public class RoomserviceService: IRoomserviceService
    {
        private readonly IRoomserviceRepository _roomserviceRepository;

        public RoomserviceService(IRoomserviceRepository roomserviceRepository)
        {
            _roomserviceRepository = roomserviceRepository;

        }
        public async Task<bool> AddRoomservice(RoomserviceCreateRequestModel roomservice)
        {


            var r = new Roomservice
            {
                RoomNo = roomservice.RoomNo,
                SDesc = roomservice.SDesc,
                Amount = roomservice.Amount,
                ServiceDate = roomservice.ServiceDate

            };

        var createdRoomservice = _roomserviceRepository.AddAsync(r);

            if (createdRoomservice != null && createdRoomservice.Id > 0)
            {
                return true;
            }

            return false;
        }

        public async Task DeleteRoomserviceById(int id)
        {
            var res = _roomserviceRepository.GetByIdAsync(id).Result;
            if (res == null)
            {
                Console.WriteLine("not found Room Service with Id:" + id);
            }
            else
            {
                await _roomserviceRepository.DeleteAsync(res);
            }
        }


        public async Task<Roomservice> GetRoomserviceById(int id)
        {
            return await _roomserviceRepository.GetByIdAsync(id);
        }



        public async Task<IEnumerable<Roomservice>> ListAll()
        {
            return await _roomserviceRepository.ListAllAsync();
        }

        public async Task<Roomservice> UpdateRoomservice(int id, RoomserviceCreateRequestModel roomservice)
        {
            return await _roomserviceRepository.UpdateRoomservice(id, roomservice);
        }



        public async Task<IEnumerable<Roomservice>> GetRoomservicesByRoomNo(int RoomNo)
        {
            return await _roomserviceRepository.GetRoomservicesByRoomNo(RoomNo);
        }
    }
}
