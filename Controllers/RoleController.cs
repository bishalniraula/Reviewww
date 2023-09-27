using AuthProject.Data;
using AuthProject.Interface;
using AuthProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;

namespace AuthProject.Controllers
{
    [Authorize(Roles = "Admin")]

    public class RoleController : Controller
    {
        private readonly IRole _role;
        //for testing 
        private readonly AppDbContext _cotext;

        public RoleController(IRole role, AppDbContext context)
        {
            _cotext = _cotext;
            _role = role;
        }

        public async Task<IActionResult> Index()
        {
            List<Role> abc = new List<Role>();
            abc = await _role.GetAllRole();

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
            var abc= _cotext.roles.Where(x => x.Id == id).FirstOrDefault();
           
            if (abc != null)
            {
                return RedirectToAction("Index");

            }
            return View();
            
            
        }

    }
}
