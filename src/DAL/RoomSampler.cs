using System;
using System.Collections.Generic;
using HogwartsHouses.Models;

namespace HogwartsHouses.DAL
{
    public class RoomSampler
    {
        public HashSet<Room> Rooms { get; private set; }

        public RoomSampler()
        {
            Initialize();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
