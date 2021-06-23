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
    public class RoomtypeController : ControllerBase
    {
        // GET: /<controller>/
        private readonly IRoomtypeService _roomtypeService;
        public RoomtypeController(IRoomtypeService roomtypeService)
        {
            _roomtypeService = roomtypeService;
        }

        //[Authorize]
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> ListAllRoomtype()
        {
            var roomtypes = await _roomtypeService.ListAll();
            if (!roomtypes.Any())
            {
                return NotFound(" No roomtypes are found. Please add roomtypes first.");
            }
            return Ok(roomtypes);
        }
        //[Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddRoomtype(RoomtypeCreateRequestModel roomtype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check data");

            }
            var createdroomtype = await _roomtypeService.AddRoomtype(roomtype);
            return Ok(createdroomtype);

        }
        //[Authorize]
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetRoomtypeById(int id)
        {
            var roomtype = await _roomtypeService.GetRoomtypeById(id);
            if (roomtype == null)
            {
                return NotFound("Not found target roomtype with id:" + id);
            }
            return Ok(roomtype);
        }

        //[Authorize]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteRoomtype(int id)
        {
            var client = await _roomtypeService.GetRoomtypeById(id);
            await _roomtypeService.DeleteRoomtypeById(id);
            return Ok();
        }
        //[Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateRoomtype(int id, RoomtypeCreateRequestModel roomtype)
        {
            await _roomtypeService.UpdateRoomtype(id, roomtype);
            return Ok();

        }
    }
}
