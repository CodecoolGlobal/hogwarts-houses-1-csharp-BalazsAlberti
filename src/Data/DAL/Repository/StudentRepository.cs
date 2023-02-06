using System.Collections.Generic;
using System.Linq;
using HogwartsHouses.Data.DAL.Sampler;
using HogwartsHouses.Models;

namespace HogwartsHouses.Data.DAL.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly RoomSampler _roomSampler;

        public StudentRepository(RoomSampler roomSampler)
        {
            _roomSampler = roomSampler;
        }
        public IEnumerable<Student> ReadAll()
        {
            return _roomSampler.Students;
        }

        public void Create(Student entity)
        {
            entity.Id = ReadLatestStudentId() + 1;
            _roomSampler.Students.Add(entity);
        }

        public Student ReadById(int id)
        {
            return _roomSampler.Students.FirstOrDefault(student => student.Id == id);
        }

        public void Delete(int id)
        {
            var student = _roomSampler.Students.FirstOrDefault(r => r.Id == id);
            _roomSampler.Students.Remove(student);
            _roomSampler.Rooms.Select(room => room.Students.Remove(student));
        }

        public void Update(Student entity)
        {
            var student = _roomSampler.Students.FirstOrDefault(student => student.Id == entity.Id);
            student.House = entity.House;
            student.Name = entity.Name;
            student.Pet = entity.Pet;
        }

        public int ReadLatestStudentId()
        {
            return ReadAll().OrderBy(student => student.Id).Last().Id;
        }
    }
}
