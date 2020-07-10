using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Online_Exam_Management_System.Data;
using Online_Exam_Management_System.Models;
using Online_Exam_Management_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Online_Exam_Management_System.Services
{
    public class UserServices : IUser
    {
        private readonly DataContext _context;

        public UserServices (DataContext context)
        {
            _context = context;
        }
        public User AddUser (User newUser)
        {
            _context.Users.Add (newUser);
            _context.SaveChanges ();
            return newUser;
        }

        public User DeleteUser (int Id)
        {
            var user = _context.Users.Find (Id);
            if(user != null)
            {
                _context.Users.Remove (user);
                _context.SaveChanges ();
            }
            return user;
        }

        public List<User> GetAllUser ()
        {
            return _context.Users.Include (x => x.Actor).ToList ();
        }

        public User GetUser (int Id)
        {
            return _context.Users.Find (Id);
        }

        public User GetByUserEmail (string Email)
        {
            return _context.Users.FirstOrDefault (x => x.Email.Equals (Email));
        }

        public User UpdateUser (User userChange)
        {
            var user = _context.Users.Attach (userChange);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges ();
            return userChange;
        }

        public User CheckValidUser (string Email, string Password)
        {
            return _context.Users.FirstOrDefault (x => x.Email.Equals (Email)
                     && x.Password.Equals (Password));
        }

        public List<Actor> GetAllActor ()
        {
            return _context.Actors.ToList ();
        }

        public Actor GetActor (int Id)
        {
            return _context.Actors.Find (Id);
        }
    }
}
