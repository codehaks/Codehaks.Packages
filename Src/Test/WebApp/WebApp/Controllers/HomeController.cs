using Codehaks.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Index()
        {
            var model = _db.Movies;
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateModel]
        public IActionResult Create(Movie model)
        {
            _db.Entry(model).State = EntityState.Added;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var model = _db.Movies.SingleOrDefault(m => m.Id == id);
            return View(model);
        }
    }
}