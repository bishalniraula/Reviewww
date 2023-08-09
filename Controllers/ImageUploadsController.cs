//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using AuthProject.Data;
//using AuthProject.Models;
//using System.Drawing;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.Extensions.Hosting;

//namespace AuthProject.Controllers
//{
//    public class ImageUploadsController : Controller
//    {
//        private readonly AppDbContext _context;
//        private readonly IWebHostEnvironment _hostEnvironment;


//        public ImageUploadsController(AppDbContext context, IWebHostEnvironment hostEnvironment)
//        {
//            _context = context;
//            _hostEnvironment = hostEnvironment;

//        }


//        public IActionResult Index()
//        {
//            IEnumerable<ImageUpload> images = _context.Images;
//            return View(images);

//        }


//        public IActionResult Details(int? id)
//        {
//            if (id == null || _context.Images == null)
//            {
//                return NotFound();
//            }

//            var imageUpload = _context.Images
//                .Find(id);
//            if (imageUpload == null)
//            {
//                return NotFound();
//            }

//            return View(imageUpload);
//        }


//        public IActionResult Create()
//        {
//            return View();
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> CreateAsync(ImageUpload imageUpload)
//        {
//            if (ModelState.IsValid)
//            {

//                string wwwRootPath = _hostEnvironment.WebRootPath;
//                string fileName = Path.GetFileNameWithoutExtension(imageUpload.Name);
//                string extension = Path.GetExtension(imageUpload.Name);
//                imageUpload.Name = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
//                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
//                using (var fileStream = new FileStream(path, FileMode.Create))
//                {
//                    object value = await imageUpload.Name.Copy();
//                }

//                _context.Add(imageUpload);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(imageUpload);
//        }



//    }
//}
