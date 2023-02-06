using System.Linq;
using HogwartsHouses.Data.Services;
using HogwartsHouses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsHouses.Controllers
{
    [ApiController]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("rooms")]
        public ActionResult GetAllRooms()
        {
            var rooms = _roomService.ReadAllRooms();
            if (rooms != null)
            {
                return StatusCode(StatusCodes.Status200OK, rooms);
            }
            return StatusCode(StatusCodes.Status404NotFound, $"No rooms found!");
        }

        [HttpPost("rooms")]
        public ActionResult AddRoom([FromBody]Room room)
        {
            var rooms = _roomService.ReadAllRooms();
            if (!rooms.Any(r=>r.Id == room.Id))
            {
                _roomService.CreateRoom(room);
                return StatusCode(StatusCodes.Status201Created, room);

            }
            if (room.Id == 0)
            {
                return StatusCode(StatusCodes.Status405MethodNotAllowed);
            }
            return StatusCode(StatusCodes.Status406NotAcceptable, "Room already exists!");
        }

        [HttpGet("rooms/{id}")]
        public ActionResult GetRoomById(int id)
        { 
            var room = _roomService.ReadRoomById(id);
            if (room != null)
            {
                return StatusCode(StatusCodes.Status200OK, room);
            }
            return StatusCode(StatusCodes.Status404NotFound,$"Room by {id} doesn't exist!");
        }

        [HttpDelete("rooms/{id}")]
        public ActionResult DeleteRoomById(int id)
        {
            var room = _roomService.ReadRoomById(id);
            if (room != null)
            {
                _roomService.DeleteRoomById(id);
                return StatusCode(StatusCodes.Status202Accepted, $"{id}. room deleted");
            }
            return StatusCode(StatusCodes.Status404NotFound, $"Room by id: {id} doesn't exist!");
        }

        [HttpPut("rooms/{id}")]
        public ActionResult UpdateRoomById(int id, [FromBody] Room updateRoom)
        {
            var room = _roomService.ReadRoomById(id);
            if (room != null)
            {
                if (room.Students.Count < room.MaxRoomSize)
                {
                    updateRoom.Id = room.Id;
                    _roomService.UpdateRoom(updateRoom);
                    return StatusCode(StatusCodes.Status200OK, updateRoom);
                }
                return StatusCode(StatusCodes.Status304NotModified);
            }
            return StatusCode(StatusCodes.Status304NotModified, $"Room by {id} not found!");
        }

        [HttpGet("students")]
        public ActionResult GetAllStudents()
        {
            var students =  _roomService.ReadAllStudents();
            if (students != null)
            {
                return StatusCode(StatusCodes.Status200OK, students);
            }
            return StatusCode(StatusCodes.Status404NotFound, $"No students found!");
        }

        [HttpPut("/students/{roomId}/{studentId}")]
        public ActionResult AddStudentToRoom(int roomId, int studentId)
        {
            var student = _roomService.ReadStudentById(studentId);
            var room = _roomService.ReadRoomById(roomId);
            if (room != null && student != null && !_roomService.ReadAllAvailableRooms().Any(r=>r.Students.Any(s=>s.Name == student.Name && room.Students.Count < room.MaxRoomSize)))
            {
                _roomService.CreateStudentToRoom(room, student);
                return StatusCode(StatusCodes.Status200OK, room);
            }
            return StatusCode(StatusCodes.Status304NotModified, $"Room by {roomId} or Student by {studentId} cannot be found!");
        }

        [HttpPost("/students")]
        public ActionResult AddStudent([FromBody] Student student)
        {
            var students = _roomService.ReadAllStudents();
            var rooms = _roomService.ReadAllAvailableRooms();
            if (!students.Any(s=>s.Name == student.Name) && !rooms.Any(room => room.Students.Any(s=>s.Name == student.Name)))
            {
                _roomService.CreateStudent(student);
                return StatusCode(StatusCodes.Status201Created, student);
            }
            return StatusCode(StatusCodes.Status406NotAcceptable, "Student already exists!");
        }

        [HttpGet("/rooms/available")]
        public ActionResult GetAllAvailableRooms()
        {
            var availableRooms = _roomService.ReadAllAvailableRooms();
            if (availableRooms != null)
            {
                return StatusCode(StatusCodes.Status200OK, availableRooms);
            }
            return StatusCode(StatusCodes.Status404NotFound, "No available rooms found!");
        }

        [HttpGet("rooms/rat-owners")]
        public ActionResult GetAllRatFriendlyRooms()
        {
            var rooms = _roomService.ReadAllRatFriendlyRooms();
            if (rooms != null)
            {
                return StatusCode(StatusCodes.Status200OK, rooms);
            }
            return StatusCode(StatusCodes.Status404NotFound, "No rat-friendly rooms found!");
        }
    }
}
