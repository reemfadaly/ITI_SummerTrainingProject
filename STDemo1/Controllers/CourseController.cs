using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STDemo1.Data;
using STDemo1.Models;
using System.Linq;
using STDemo1.Repository;

namespace STDemo1.Controllers
{
    public class CourseController : Controller
    {
        IDepartmentRepo departmentRepo;
        ICourseRepo courseRepo;
        public CourseController(IDepartmentRepo departmentRepo, ICourseRepo courseRepo)
        {
            this.courseRepo = courseRepo;
            this.departmentRepo = departmentRepo;
        }

        public IActionResult Create()
        {
            ViewBag.depts = departmentRepo.GetAll();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course) 
        {
            if (ModelState.IsValid)  
            {
                courseRepo.Add(course);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.depts = departmentRepo.GetAll();
                return View();
            }
        }

        public IActionResult Details(int id)
        {
            var course = courseRepo.GetById(id);

            return View(course);
        }

        public IActionResult Delete(int Id)
        {
            ViewBag.Title = "Delete Course";
            var course = courseRepo.GetById(Id);
            return View(course);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            courseRepo.DeleteById(Id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var course = courseRepo.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewBag.depts = departmentRepo.GetAll();
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {

                courseRepo.Edit(course);
                return RedirectToAction("Index");
            }
            ViewBag.depts = departmentRepo.GetAll();
            return View(course);
        }

        public IActionResult Index()
        {
            var courses = courseRepo.GetAll(); //join students w departments
            return View(courses);


        }

    }
}
