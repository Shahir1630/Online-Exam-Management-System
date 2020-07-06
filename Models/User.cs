﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam_Management_System.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string Name { get; set; }
    }
}
