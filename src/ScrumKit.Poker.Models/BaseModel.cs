using System;
using System.ComponentModel.DataAnnotations;

namespace ScrumKit.Poker.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string UserCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string UserModified { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string UserDeleted { get; set; }

        public bool IsDeleted { get; set; }
    }
}
