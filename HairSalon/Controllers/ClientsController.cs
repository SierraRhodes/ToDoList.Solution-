using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly HairSalonContext _db;

    public ClientsController(HairSalonContext db)
    {
      _db = db;
    }
      public ActionResult Index()
{
  List<Client> model = _db.Clients.Include(Client => Client.Stylist).ToList(); 
  ViewBag.PageTitle = "View All Clients";
  return View(model);
}

    public ActionResult Create()
{
  ViewBag.Stylist.Id = new SelectList(_db.Stylists, "Stylist.Id", "Name");
  return View();
}

    [HttpPost]
    public ActionResult Create(Client Client)
    {
      if (Client.StylistId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Clients.Add(Client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
  }
}