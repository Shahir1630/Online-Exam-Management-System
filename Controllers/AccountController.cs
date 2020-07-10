using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NToastNotify;
using Online_Exam_Management_System.Data;
using Online_Exam_Management_System.Models;
using Online_Exam_Management_System.Services.Interfaces;
using Online_Exam_Management_System.ViewModels;

namespace Online_Exam_Management_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUser _userRepo;
        private readonly IToastNotification _toastNotification;

        public AccountController (IUser user, IToastNotification toastNotification)
        {
            _userRepo = user;
            _toastNotification = toastNotification;
        }
        public IActionResult Index ()
        {
            return View (_userRepo.GetAllUser());
        }
        
        public IActionResult Edit (int Id)
        {
            var user = _userRepo.GetUser(Id);
            if(user == null)
            {
                _toastNotification.AddErrorToastMessage ("User Not Found");
                return View (nameof (ForgetPassword));
            }

            var name = user.Name.Split (' ');

            var updateUser = new EditUserViewModel ()
            {
                Id = user.Id,
                FirstName = name[0],
                LastName = name[1],
                Email = user.Email,
                Password = user.Password,
                Actor = user.ActorId,
            };
            ViewBag.ActorId = new SelectList (_userRepo.GetAllActor (), "Id", "ActorName");
            return View (updateUser);
        }

        /// <summary>
        /// edit e email edit nah korle post kaj kore nah karon email already exit bole
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Edit (EditUserViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = _userRepo.GetUser (model.Id);
                user.Name = $"{model.FirstName} {model.LastName}";
                user.Email = model.Email;
                user.Password = model.Password;
                user.ActorId = model.Actor;

                _userRepo.UpdateUser (user);
                _toastNotification.AddSuccessToastMessage ("User Edited Successfully.");
                return RedirectToAction ("Index");
            }
            return View (model);
        }

        public IActionResult Details (int Id)
        {
            var user = _userRepo.GetUser (Id);
            if (user == null)
            {
                _toastNotification.AddErrorToastMessage ("User Not Found");
                return View (nameof(ForgetPassword));
            }
            user.Actor = _userRepo.GetActor (user.ActorId);
            return View (user);
        }



        public IActionResult Delete (int Id)
        {
            var user = _userRepo.GetUser (Id);
            if (user == null)
            {
                //_toastNotification.AddErrorToastMessage ("User Not Found");
                return View (nameof(ForgetPassword));
            }
            _userRepo.DeleteUser (Id);
            //_toastNotification.AddSuccessToastMessage ("User Delete Successfully.");
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Login ()
        {
            return View ();
        }

        [HttpPost]
        public IActionResult Login (LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepo.CheckValidUser (model.Email, model.Password);

                if (user == null)
                {
                    _toastNotification.AddErrorToastMessage ("Invlid User Input. Try Again.");
                    return View (model);
                }

                _toastNotification.AddSuccessToastMessage ("Login Successfull.");
                return RedirectToAction ("Index", "Home");
            }
            return View (model);
        }

        public IActionResult ForgetPassword ()
        {
            return View ();
        }
        public IActionResult Registration ()
        {
            ViewBag.ActorId = new SelectList (_userRepo.GetAllActor(), "Id", "ActorName");
            return View ();
        }

        [HttpPost]
        public IActionResult Registration (RegistrationViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new User ()
                {
                    Name = $"{model.FirstName} {model.LastName}",
                    Email = model.Email,
                    Password = model.Password,
                    ActorId = model.Actor
                };

                _userRepo.AddUser (user);
                _toastNotification.AddSuccessToastMessage ("Successfully Created.");
                return RedirectToAction (nameof (Index));
            }
            return View ();
        }

        [AcceptVerbs("Get","Post")]
        public IActionResult IsEmailInUse (string Email)
        {
            var user = _userRepo.GetByUserEmail (Email);

            if(user != null)
            {
                return Json ($"Email {Email} is already in use");
            }
            return Json (true);
        }

    }
}
