using System.Collections.Generic;

namespace ScrumKit.Poker.Models
{
    public class Room : BaseModel
    {
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
