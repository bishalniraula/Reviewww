using AuthProject.Data;
using AuthProject.Migrations;
using AuthProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthProject.Controllers
{
    [Authorize(Roles="Admin")]
   
    public class RoleController : Controller
    {
        private readonly AppDbContext _context;
        public RoleController(AppDbContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            IEnumerable<Role> role = _context.roles;
            return View(role);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Role role) 
        { 
            if(ModelState.IsValid)
            {
                _context.roles.Add(role);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(role);
        }
        public IActionResult Edit (int ? id)
        {
            Role role = _context.roles.Find(id);
            return View(role);
        }
        [HttpPost]
        public IActionResult Edit (Role role)
        {
            if(ModelState.IsValid)
            {
                _context.roles.Add(role);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

    }
}
