using System.Collections.Generic;
using HogwartsHouses.Models;

namespace HogwartsHouses.Data.Services
{
    public interface IRoomService
    {
        IEnumerable<Room> ReadAllRooms();
        IEnumerable<Student> ReadAllStudents();
        IEnumerable<Room> ReadAllAvailableRooms();
        IEnumerable<Room> ReadAllRatFriendlyRooms();
        void CreateRoom(Room room);
        Room ReadRoomById(int roomId);
        void DeleteRoomById(int roomId);
        void UpdateRoom(Room room);
        void CreateStudentToRoom(Room room, Student student);
        void CreateStudent(Student student);
        Student ReadStudentById(int studentId);
    }
}
