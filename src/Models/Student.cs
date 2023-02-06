using HogwartsHouses.Models.Types;
using System.Text.Json.Serialization;

namespace HogwartsHouses.Models
{
    [System.Serializable]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public HouseType House { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetType Pet { get; set; }

        public Student(string name, HouseType house, PetType pet,int id)
        {
            Name = name;
            House = house;
            Pet = pet;
            Id = id;
        }
    }
}
