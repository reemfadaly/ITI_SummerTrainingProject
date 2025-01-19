using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using STDemo1.Data;
using STDemo1.Models;
using STDemo1.ViewModels;
using STDemo1.Repository;

namespace STDemo1.Controllers
{
    public class DepartmentController : Controller
    {
        
        IDepartmentRepo departmentRepo; 
        public DepartmentController(IDepartmentRepo _departmentRepo)
        {
            departmentRepo= _departmentRepo;
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost] 
        public IActionResult Create(Department dept) 
        {
            departmentRepo.Add(dept);
            return RedirectToAction("Index"); 
        }

        public IActionResult Details(int? id)
        {
            if(id==null)
                return BadRequest();
            Department dept = departmentRepo.GetById(id.Value);
            return View(dept); 
        }



        public IActionResult Delete(int id)
        {
            var dept = departmentRepo.GetById(id);
            return View(dept);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int DeptId)
        {
            departmentRepo.DeleteById(DeptId);
            return RedirectToAction("Index");
        }





        public IActionResult Edit(int id)
        {
            var department = departmentRepo.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            ViewBag.depts = departmentRepo.GetAll();
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {

                departmentRepo.Edit(department);
                return RedirectToAction("Index");
            }
            ViewBag.depts = departmentRepo.GetAll();
            return View(department);
        }


        public IActionResult Index()
        {
            var result = departmentRepo.GetAll();
            return View(result);
        }

    }
}
