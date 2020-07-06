﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Exam_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam_Management_System.Data
{
    public static class SeedData
    {
        public static void SeedLoginData( this ModelBuilder modelBinder)
        {
            modelBinder.Entity<User> ().HasData(
                new User () { Id = 1, Name = "Riaz", Email="riaz@gmail.com", Password="12345"},
                new User () { Id = 2, Name = "Shahir", Email="16303019@gmail.com", Password="12345"},
                new User () { Id = 3, Name = "Topu", Email="16303039@gmail.com", Password="12345"}
                );
        }
    }
}
