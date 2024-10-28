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
    public class StudentController : Controller
    {
            // ------------ADD Student--------------
            //ITIContext db = new ITIContext();
            IStudentRepo studentRepo; //= new StudentRepo();
            IDepartmentRepo departmentRepo; //= new DepartmentRepo();
            
            public StudentController(IDepartmentRepo _departmentRepo, IStudentRepo _studentRepo)
        {
            departmentRepo = _departmentRepo;
            studentRepo=_studentRepo;
        }
            public IActionResult Create()
            {
            ViewBag.depts = departmentRepo.GetAll(); //join student with departments
            return View();
            }
        [HttpPost]
            public IActionResult Create(Student student) //Model Binder
            {
            if (ModelState.IsValid)  //checks on the data entered matches the annotation
            {
                studentRepo.Add(student);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.depts = departmentRepo.GetAll();
                return View();
            }
            }

        public JsonResult IsEmailAvailable(string email)
        {
            var isEmailTaken = studentRepo.GetAll().Any(s => s.Email ==email);
            if (isEmailTaken)
            {
                return Json("Email is already taken");
            }
            return Json(true);
        }
            

            //-----READ-----------
            public IActionResult Details(int id)
            {
            var student = studentRepo.GetById(id);
            
                return View(student);
        }




        //------------DELETE ------------
        public IActionResult Delete(int Id)
        {
            ViewBag.Title = "Delete Student";
            var student = studentRepo.GetById(Id);
            return View(student);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            studentRepo.DeleteById(Id);
            return RedirectToAction("Index");
        }


        //------------UPDATE------
        public IActionResult Edit(int id)
        {
            var student = studentRepo.GetById(id);
            if (student == null)
            {
                return NotFound(); 
            }

            
            ViewBag.depts = departmentRepo.GetAll();

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepo.Edit(student);
                return RedirectToAction("Index");
            }

         
            ViewBag.depts = departmentRepo.GetAll();

        
            return View(student);
        }




        public IActionResult Index()
            {
                var students = studentRepo.GetAll(); //join students w departments
                return View(students);

                
            }
    }
}
