using AuthProject.Data;
using AuthProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;


namespace AuthProject.Controllers
{
    public class XyzController:Controller
    {

        private readonly AppDbContext _context;
        public XyzController (AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> students = _context.students;
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
