using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

public class UserController : Controller
{
    private ORMContext _context;

        private int? uid
    {
        get
        {
        return HttpContext.Session.GetInt32("UserId");
        }
    }
    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }

    public UserController(ORMContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public IActionResult LoginRegister()
    {
        return View("LoginRegistration");
    }
}