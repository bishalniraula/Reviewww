using AuthProject.Data;
using AuthProject.Interface;
using AuthProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AuthProject.Controllers
{
    

    public class StudentController : Controller
    {
        private readonly IStudent _student;
        
        public StudentController(IStudent student)
        {
            _student = student;
          
        }
       
        public async Task<IActionResult> Index()
        {
            List<Student> student = await _student.GetAllUser();
            return View(student);

        }
        [Authorize(Roles = "Admin,User")]

        public async Task<IActionResult> Create(int id)
        {

           
            var student = await _student.GetStudentById(id);
            if (student == null)
            {
                if (id == 0)
                {
                    return View();
                }
                else
                {
                    TempData["NotExist"] = $"There is not student from the id={id}";
                    return RedirectToAction("Index");

                }

            }

            return View(student);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {


                if (await _student.InsertUpdate(student))
                {
                    return RedirectToAction("Index");
                }

            }

            TempData["NotExist"] = $"Already Existed or Invalid Input";
            return View(student);
        }
        //public async Task<IActionResult> Delete(int? id)
        //{

        //    Student student = await _student.ShowStudentById(id);

        //    return View(student);

        //}
        //[HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {

            if (await _student.DeleteStudent(id))
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<IActionResult> Detail(int? id)
        {
            Student stu = await _student.Detail(id);
            return View(stu);
        }
        
       
    }

}

