using LearnUnitTest.Services.Users;
using LearnUnitTest.Web.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnUnitTest.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.ValidateUser(model.Username, model.Password);
                switch (result)
                {
                    case UserLoginResults.Successful:
                        return RedirectToAction("Index", "Home");

                    case UserLoginResults.NotExist:
                        ModelState.AddModelError("UserName_NotExist", "User not exist");
                        break;

                    case UserLoginResults.WrongPassword:
                        ModelState.AddModelError("Password_Wrong", "Wrong password");
                        break;
                }
            }

            return View(model);
        }
    }
}