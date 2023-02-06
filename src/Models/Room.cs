using System;
using System.Collections.Generic;
using System.Linq;
using HogwartsHouses.Models.Types;

namespace HogwartsHouses.Models
{
    [System.Serializable]
    public class Room
    {
        public int Id { get; set; }
        public bool RequiredRenovation { get; set; }
        public HashSet<Student> Students { get; set; }
        public readonly int MaxRoomSize = 4;

        public Room()
        {
            RequiredRenovation = false;
            Students = new HashSet<Student>();
        }

        public int GetRoomCapacity()
        {
            return Students.Count;
        }
        public bool IsAvailable()
        {
            if (Students.Count >= MaxRoomSize)
            {
                return false;
            }
            return true;
        }

        public bool IsAnyRatInTheRoom()
        {
            int bannedPetCounter = 0;
            foreach (var student in Students)
            {
                if (student.Pet == PetType.Cat || student.Pet == PetType.Owl)
                {
                    bannedPetCounter += 1;
                }
            }
            if (bannedPetCounter > 0)
            {
                return false;
            }
            return true;
        }
    }
}
