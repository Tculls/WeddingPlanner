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
        return View("CreateWedding");
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
        newWedding.UserId = (int)uid;
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
    [HttpGet("/weddings/{WeddingId}")]
    public IActionResult OneWedding(int WeddingId)
    {
        if (uid == null)
        {
            return RedirectToAction("LoginRegister", "User");
        }
        Wedding? weddings = _context.Weddings.Include(wed => wed.Planner).Include(wedd => wedd.Attendees).ThenInclude(guest => guest.Attendee).FirstOrDefault(weddi => weddi.WeddingId == WeddingId);

        if (weddings == null)
        {
            return RedirectToAction("Dashboard", "Wedding");
        }
        return View("OneWedding", weddings);
    }

    [HttpPost("/weddings/{WeddingId}/attend")]
    public IActionResult GoToWedding(int WeddingId)
    {
        if (uid == null)
        {
            return RedirectToAction("LoginRegister", "User");
        }

        Association? RSVPcheck = _context.Associations.FirstOrDefault(attend => attend.UserId == uid && attend.WeddingId == WeddingId );

        if (RSVPcheck == null)
        {
            Association newAttend = new Association()
            {
            WeddingId = WeddingId,
            UserId = (int)uid
            };
            
        _context.Associations.Add(newAttend);
        }
        else
        {
            _context.Associations.Remove(RSVPcheck);
        }
        _context.SaveChanges();
        return RedirectToAction("Dashboard", "Wedding");
    }
}

