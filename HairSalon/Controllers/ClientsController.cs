using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly ToDoListContext _db;

    public ClientsController(ToDoListContext db)
    {
      _db = db;
    }
  }
}