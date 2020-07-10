using Online_Exam_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam_Management_System.Services.Interfaces
{
    public interface IUser
    {
        /// <summary>
        /// Bacis Repositor for user 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        
        User GetUser (int Id);
        List<User> GetAllUser ();
        User UpdateUser (User userChange);
        User AddUser (User newUser);
        User DeleteUser (int Id);
       
        /// <summary>
        /// Need For Account Controller 
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Passwrd"></param>
        /// <returns></returns>

        User CheckValidUser (string Email, string Password);
        User GetByUserEmail (string Email);
        List<Actor> GetAllActor ();

        Actor GetActor (int Id);
    }
}
