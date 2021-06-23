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
    public class RoomController : ControllerBase
    {

        private readonly IRoomService _roomService;
        private readonly IRoomserviceService _roomserviceService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        //[Authorize]
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> ListAllRoom()
        {
            var rooms = await _roomService.ListAll();
            if (!rooms.Any())
            {
                return NotFound(" No rooms are found. Please add rooms first.");
            }
            return Ok(rooms);
        }
        //[Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddRoom(RoomCreateRequestModel room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check data");

            }
            var createdroom = await _roomService.AddRoom(room);
            return Ok(createdroom);

        }
        //[Authorize]
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound("Not found target room with id:" + id);
            }
            return Ok(room);
        }

        //[Authorize]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var client = await _roomService.GetRoomById(id);
            await _roomService.DeleteRoomById(id);
            return Ok();
        }
        //[Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateRoom(int id, RoomCreateRequestModel room)
        {
            await _roomService.UpdateRoom(id, room);
            return Ok();

        }



    }
}
