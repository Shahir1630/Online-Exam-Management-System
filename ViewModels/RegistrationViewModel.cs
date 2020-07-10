using Microsoft.AspNetCore.Mvc;
using Online_Exam_Management_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam_Management_System.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller:"Account")]
        public string Email { get; set; }

        public string Password { get; set; }
        
        [Required]
        public int Actor { get; set; }

        ///Gender, Image, all poperty ar required except image
        /// public IFormFile Photo { get; set; }
    }
}
