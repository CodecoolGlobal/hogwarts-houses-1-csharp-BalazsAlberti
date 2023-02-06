using System.Collections.Generic;
using System.Linq;
using HogwartsHouses.Data.DAL.Repository;
using HogwartsHouses.Models;

namespace HogwartsHouses.Data.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _roomRepository;
        private readonly IRepository<Student> _studentRepository;

        public RoomService(IRepository<Room> roomRepository, IRepository<Student> studentRepository)
        {
            _roomRepository = roomRepository;
            _studentRepository = studentRepository;
        }

        public IEnumerable<Room> ReadAllRooms()
        {
            return _roomRepository.ReadAll();
        }

        public IEnumerable<Student> ReadAllStudents()
        {
            return _studentRepository.ReadAll().OrderBy(student => student.Id);
        }

        public IEnumerable<Room> ReadAllAvailableRooms()
        {
            return _roomRepository.ReadAll().Where(room => room.IsAvailable());
        }

        public IEnumerable<Room> ReadAllRatFriendlyRooms()
        {
            return _roomRepository.ReadAll().Where(room => room.IsAnyRatInTheRoom());
        }

        public void CreateRoom(Room room)
        {
            _roomRepository.Create(room);
        }

        public Room ReadRoomById(int roomId)
        {
            return _roomRepository.ReadById(roomId);
        }

        public void DeleteRoomById(int roomId)
        {
            _roomRepository.Delete(roomId);
        }

        public void UpdateRoom(Room room)
        {
            _roomRepository.Update(room);
        }

        public void CreateStudentToRoom(Room room, Student student)
        {
            room.Students.Add(student);
            _roomRepository.Update(room);
        }

        public void CreateStudent(Student student)
        {
            _studentRepository.Create(student);
        }

        public Student ReadStudentById(int studentId)
        {
            return _studentRepository.ReadById(studentId);
        }
    }
}
