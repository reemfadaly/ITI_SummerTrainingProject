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
        //CRUD:==> CREATE, READ ALL OR ONE, UPDATE, DELETE
        // ------------ADD Department--------------
        //ITIContext db = new ITIContext();

        //department/create method:get (by default)
        IDepartmentRepo departmentRepo; //= new DepartmentRepo();
        public DepartmentController(IDepartmentRepo _departmentRepo)
        {
            departmentRepo= _departmentRepo;
        }
        public IActionResult Create()
        {
            return View();
            //view must have the same name as the name of the method
        }

        //department/create method:post
        [HttpPost] //go to the below create action to add the poste data returned from the above action
        public IActionResult Create(Department dept) //model binder //any request that has a data named deptid, name, capacity it takes the itsvalue from the request to the dept id (case nonsensitive)
                                                                    //post method, Request.Form[:deptid"]
                                                                    //Request.RouteValues["id"]
                                                                    //instead of using model binder we need Request.Query["id"]
                                                                    //for manual searching for get method, Request.Query["deptid"]
        {
            departmentRepo.Add(dept);
            return RedirectToAction("Index"); //return list in the index
            //Department dept = new Department() { DeptId = deptid, DeptName = name, Capacity = capacity };
            ////db.Departments.Add(dept);
            ////db.SaveChanges();
            //return "Added";
            //create and showcreate can be the same name => create (so it's overload) but this will make confloict when calling by url
            // so, identify one of them using post

            //to call it in url
            //department(Controllername)/create(ActionName)?deptid=100&name=IT&capacity=60(setting data to parameters)
            //?deptid=200&name=IT&capacity=40  => returns Added and will add new line to db
            //?deptid=200&name=IT&capacity=40  => argument exception as primary key is duplicated
            //?deptid=200&capacity=40           => name is nullable so it's set to 0
        }

        //read one department
        //data in dept is transformed to string
        //-----READ-----------
        public IActionResult Details(int? id)
        {
            ////Department dept = db.Departments.SingleOrDefault(a=>a.DeptId == id);
            if(id==null)
                return BadRequest();
            Department dept = departmentRepo.GetById(id.Value);
            return View(dept); //object from department + in the view @Model.DeptId...
            //error 400
            //string str = $"{dept.DeptId}:{dept.DeptName}:{dept.Capacity}";
            //ViewData["x"]=30;
            //ViewData["y"]=40;
            //ViewData["department"] = dept; //dictionary to add values
            //ViewBag.z = 900;

            //Student student = new Student();{ Id = 10, Name="Reem", Age=30 }
            //DetailsViewModel model = new DetailsViewModel() { Student=std, Department=dept};
            //return RedirectPermanent("http://www.google.com"); //direct to google
            //return Redirect("http://www.google.com");  //returns to details then google
            //return File("names.txt", "text/plain", "Names.txt");
            //return Json(dept);
            //or// return Content(str);
            //or create the obj// return new ContentResult() {Content = str};

            //for not found
            //return Notfound();   //but this only is not enough 

            //to call this action
            // /depatment/details?deptid=100
            // 100:IT:60
            // /department/details?deptid=200
            // 200:0:40
        }




        //------------DELETE Department------------
        public IActionResult Delete(int id)
        {
            //var dept = db.Departments.SingleOrDefault(a => a.DeptId == id);
            var dept = departmentRepo.GetById(id);
            return View(dept);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int DeptId)
        {
            departmentRepo.DeleteById(DeptId);
            return RedirectToAction("Index");
            ////var dept = db.Departments.SingleOrDefault(a => a.DeptId == id);
            ////db.Departments.Remove(dept); //remove from memory not from db
            ////db.SaveChanges(); //remove from db
            // /department/delete?id=300
            // /department/delete?200 //without id it is stored in a key called id 
        }




        //------------UPDATE------
        //public string Edit(Department dept)
        //{
        //    ////var dept = db.Departments.SingleOrDefault(a => a.DeptId == id);
        //    ////if (dept != null)
        //    ////{
        //    ////    dept.DeptName = name;
        //    ////    dept.Capacity = capacity;
        //    ////    db.SaveChanges();
        //    ////    return "department updated";
        //    ////}
        //    deptRep.Edit(dept);
        //    return "department update error";

        //    // /department/edit/100?name=aly%capacity=900
        //}

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


        //read list of department
        // intead of return view, it returns index
        //used in APIs
        //returns arrays
        public IActionResult Index()
        {
            var result = departmentRepo.GetAll();
            return View(result);
            ////var result = db.Departments.ToList();
            //return Json(result);

            //return View(); //null exception
            //return View(new Department()) //one object instead of list

            // /department/index
            // /department   //without index  =>   default value for action: index
        }

    }
}
