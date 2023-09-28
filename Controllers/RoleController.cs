using AuthProject.Data;
using AuthProject.Interface;
using AuthProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using System.Data;

namespace AuthProject.Controllers
{
    [Authorize(Roles = "Admin")]

    public class RoleController : Controller
    {
        private readonly IRole _role;
        //for testing 
        private readonly AppDbContext _context;

        public RoleController(IRole role, AppDbContext context)
        {
            _context = context;
            _role = role;
        }

        public async Task<IActionResult> Index()
        {
            List<Role> abc = new List<Role>();
            abc = await _role.GetAllRole();
            int count = _context.Database.ExecuteSqlRaw("EXEC CountRole");
            ViewBag.Count = count;
            return View(abc);

        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(Role role)
        {
            if (await _role.insertupdate(role))
            {
                return RedirectToAction("Index");
            }
            return View(role);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            Role role = await _role.GetRoleById(id);
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Role role)
        {
            if (await _role.insertupdate(role))
            {

                return RedirectToAction("Index");
            }
            return View(role);
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var abc= _context.roles.Where(x => x.Id == id).FirstOrDefault();
           
            if (abc != null)
            {
                return RedirectToAction("Index");

            }
            return View();
            
            
        }
        [HttpPost]
        public async Task<IActionResult> Index(string Email)
        {
            if (Email != null)
            {


                List<Role> roles = new List<Role>();

                SqlParameter emailParameter = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                emailParameter.Value = Email;



                roles = await _context.roles.FromSqlRaw("EXEC Sp_SearchRole @Email", emailParameter).ToListAsync();
                if (roles.Count != 0)
                {
                    return View(roles);
                }
            }
            TempData["User Not Found"] = "Not Found";
            return RedirectToAction("Index");
        }
    }
}
