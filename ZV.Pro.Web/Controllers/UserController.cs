using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ZV.Pro.Business.Interfaces;
using ZV.Pro.Core.Entities;
using Microsoft.EntityFrameworkCore;

public class UserController : Controller


{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }



    [Authorize]
    public IActionResult Index()
    {

        return View();
    }




    [HttpGet]
    public async Task<IActionResult>Login()
    {
        return View();
    }




    [HttpPost]
    public async Task<IActionResult> Login([Bind("UserName, Password")] User user)
    {

        ModelState.AddModelError(string.Empty, "Invalid username or password");

        var luser = _userService.GetUsersByUserName(user.UserName);
        if (luser == null)
        {
            return BadRequest();
        }
        if (luser.Password == user.Password)
        {

            return RedirectToAction("Index", "Home");
        }


        ModelState.AddModelError(string.Empty, "Invalid username or password");
        return View(user);
    }





    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }





    [HttpPost]
    public async Task< IActionResult> Create([Bind(" UserName, Password")] User user)



    {
        try
        {
            if (ModelState.IsValid)
            {

                _userService.Create(user);


                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
        catch (Exception ex)
        {
            return Problem($"Error creating the user: {ex.Message}");
        }

    }



    [Authorize]
    [HttpGet]
    public IActionResult Update(int id)
    {

        User user = _userService.GetById(id);


        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }





    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Update(int id, [Bind("Id, UserName, Password")] User user)
    {
        try
        {
            if (ModelState.IsValid)
            {

                var  existingUser = _userService.GetUsersByUserName(user.UserName);



                if (existingUser == null)
                {
                    return NotFound();
                }

                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;

                _userService.Update(existingUser);

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
        catch (Exception ex)
        {
            return Problem($"Error updating the user: {ex.Message}");
        }
    }



    public IActionResult Delete()
    {
        return View();
    }


    public IActionResult GetAll()
    {
        return View();
    }


    public IActionResult GetById()
    {
        return View();
    }
}

