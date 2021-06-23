using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.ApplicationCore.Model.Request;
using Final.ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomserviceController : ControllerBase
    {

        private readonly IRoomserviceService _roomerviceService;
        public RoomserviceController(IRoomserviceService roomserviceService)
        {
            _roomerviceService = roomserviceService;
        }

        //[Authorize]
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> ListAllRoomservice()
        {
            var roomservices = await _roomerviceService.ListAll();
            if (!roomservices.Any())
            {
                return NotFound(" No room services are found. Please add room services first.");
            }
            return Ok(roomservices);
        }
        //[Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddRoomservice(RoomserviceCreateRequestModel roomservice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check data");

            }
            var createdroomservice = await _roomerviceService.AddRoomservice(roomservice);
            return Ok(createdroomservice);

        }
        //[Authorize]
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetRoomserviceById(int id)
        {
            var roomservice = await _roomerviceService.GetRoomserviceById(id);
            if (roomservice == null)
            {
                return NotFound("Not found target room service with id:" + id);
            }
            return Ok(roomservice);
        }

        //[Authorize]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteRoomservice(int id)
        {
            var client = await _roomerviceService.GetRoomserviceById(id);
            await _roomerviceService.DeleteRoomserviceById(id);
            return Ok();
        }
        //[Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateRoomservice(int id, RoomserviceCreateRequestModel roomservice)
        {
            await _roomerviceService.UpdateRoomservice(id, roomservice);
            return Ok();

        }

        //[Authorize]
        [HttpGet("RoomservicesByRoomNo")]
        public async Task<IActionResult> GetRoomservicesByRoomNoFinal(int RoomNo)
        {
            var roomservice = await _roomerviceService.GetRoomservicesByRoomNo(RoomNo);
            return Ok(roomservice);

        }
    }
}
