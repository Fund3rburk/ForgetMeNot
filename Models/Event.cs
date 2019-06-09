using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ForgetMeNot.Models
{

    public class Event
    {

        public int ID { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }

        public string Name { get; set; }
        public string Relationship { get; set; }

        public EventType Type { get; set;}

        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        public DateTime Date { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        
        public string Likes { get; set; }
    }

    public enum EventType
    {
       [Display(Name = "Select Event Type")]
        Default = 0,
        Birthday = 1,
        Anniversary = 2,
        Wedding = 3
    }
}
