using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;


namespace WeddingPlanner.Controllers;

public class WeddingController : Controller
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

    public WeddingController(ORMContext context)
    {
        _context= context;
    }

    [HttpGet("/weddings/new")]

    public IActionResult New()
    {
        if(!loggedIn)
        {
        return RedirectToAction("Index", "Home");
        }
        return View("Wedding");
    }

    [HttpPost("/weddings/create")]
    public IActionResult Create(Wedding newWedding)
    {
        if (uid == null)
        {
        return RedirectToAction("Index", "Home");
        }

        if (ModelState.IsValid == false)
        {
            return New();
        }
        _context.Weddings.Add(newWedding);
        _context.SaveChanges();

        return RedirectToAction("Dashboard");
    }
    [HttpGet("/weddings")]
    public IActionResult AllWeddings()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "Home");
        }

        List<Wedding> AllWeddings = _context.Weddings.Include(w => w.Planner).ToList();

        return View("Dashboard", AllWeddings);
    }
}