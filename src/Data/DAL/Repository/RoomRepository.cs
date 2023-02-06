using System;
using System.Collections.Generic;
using System.Linq;
using HogwartsHouses.Data.DAL.Sampler;
using HogwartsHouses.Models;

namespace HogwartsHouses.Data.DAL.Repository
{
    public class RoomRepository : IRepository<Room>
    {
        private readonly RoomSampler _roomSampler;
        public RoomRepository(RoomSampler roomSampler)
        {
            _roomSampler = roomSampler;
        }
        public IEnumerable<Room> ReadAll()
        {
            return _roomSampler.Rooms;
        }

        public void Create(Room entity)
        {
            _roomSampler.Rooms.Add(entity);
        }

        public Room ReadById(int id)
        {
            return _roomSampler.Rooms.FirstOrDefault(r => r.Id == id);
        }

        public void Delete(int id)
        {
           var room = _roomSampler.Rooms.FirstOrDefault(r => r.Id == id);
           _roomSampler.Rooms.Remove(room);
        }

        public void Update(Room entity)
        {
            var updateRoom = ReadById(entity.Id);
            updateRoom.RequiredRenovation = entity.RequiredRenovation;
            if (updateRoom.Students.Count < updateRoom.MaxRoomSize )
            {
                foreach (var entityStudent in entity.Students)
                {
                    updateRoom.Students.Add(entityStudent);
                }
            }
        }
    }
}
