using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam_Management_System.Models
{
    public class Actor
    {
        public int Id { get; set; }

        public string ActorName { get; set; }

        //public int UserId { get; set; }
        public ICollection<User> Users { get; set; }
       
    }
}
