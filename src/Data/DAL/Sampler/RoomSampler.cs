using System.Collections.Generic;
using HogwartsHouses.Models;
using HogwartsHouses.Models.Types;

namespace HogwartsHouses.Data.DAL.Sampler
{
    public class RoomSampler
    {
        public HashSet<Room> Rooms { get; set; }
        public HashSet<Student> Students { get; set; }

        public RoomSampler()
        {
            Initialize();
        }

        public void Initialize()
        {
            #region Students
            var bathilda = new Student("Bathilda", HouseType.Hufflepuff, PetType.Rat,0);
            var phineas = new Student("Phineas", HouseType.Hufflepuff, PetType.None,1);
            var sirius = new Student("Sirius", HouseType.Hufflepuff, PetType.Rat,2);
            var amelia = new Student("Amelia Bones", HouseType.Hufflepuff, PetType.Cat,3);
            var hermione = new Student("Hermione Granger", HouseType.Gryffindor, PetType.Cat,4);
            var draco = new Student("Draco Malfoy", HouseType.Slytherin, PetType.Owl,5);
            var susan = new Student("Susan Bones", HouseType.Gryffindor, PetType.Rat,6);
            #endregion

            #region Rooms
            var room100 = new Room()
            {
                Id = 0
            };
            var room101 = new Room()
            {
                Id = 1
            };
            var room102 = new Room()
            {
                Id = 2,
                Students =
                {
                    bathilda,
                    phineas,
                    sirius,
                    amelia
                }
            };
            var room103 = new Room()
            {
                Id = 3,
                Students =
                {
                    susan
                }
            };
            #endregion

            Rooms = new HashSet<Room>()
            {
                room100,
                room101,
                room102,
                room103
            };

            Students = new HashSet<Student>()
            {
                hermione,
                draco,
                bathilda,
                phineas,
                sirius,
                amelia,
                susan
            };
        }
    }
}
