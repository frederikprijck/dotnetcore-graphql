using System.ComponentModel.DataAnnotations;

namespace Codacious.GraphQL.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public RoomStatus Status { get; set; }

        public bool HasWifi { get; set; }

        public Room()
        {

        }
        public Room(int number, string name, RoomStatus status, bool hasWifi)
        {
            Number = number;
            Name = name;
            Status = status;
            HasWifi = hasWifi;
        }
    }
}
