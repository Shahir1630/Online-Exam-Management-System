using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam_Management_System.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        [Required]
        public string Name { get; set; }

        //public string PhotoPath { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }

    }
}
