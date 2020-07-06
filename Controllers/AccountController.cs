using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using Online_Exam_Management_System.Data;
using Online_Exam_Management_System.ViewModels;

namespace Online_Exam_Management_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        private readonly IToastNotification _toastNotification;

        public AccountController (DataContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }
        public IActionResult Login ()
        {
            return View ();
        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync (x => x.Email.Equals (model.Email)
                     && x.Password.Equals (model.Password));

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

    }
}
