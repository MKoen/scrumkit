using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumKit.Poker.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }

        public int? RoomId { get; set; }

        public Room Room { get; set; }
    }
}
