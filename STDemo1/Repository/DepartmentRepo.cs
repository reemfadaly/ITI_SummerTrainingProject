using STDemo1.Data;
using STDemo1.Models;

namespace STDemo1.Repository
{
    public class DepartmentRepo : IDepartmentRepo
    {
        ITIContext db; //= new ITIContext();
        public DepartmentRepo(ITIContext _db)
        {
            db = _db;
        }
        public void Add(Department department)
        {
            db.Add(department);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var dept = db.Departments.FirstOrDefault(a => a.DeptId == id);
            //db.Departments.Remove(dept);
            dept.Status = false;
            db.SaveChanges();
        }

        public List<Department> GetAll()
        {
            return db.Departments.Where(a=>a.Status==true).ToList();
        }

        public Department GetById(int id)
        {
            return db.Departments.FirstOrDefault(a => a.DeptId == id);
        }

        public void Edit(Department department)
        {
            var Depratment = db.Departments.FirstOrDefault(a => a.DeptId == department.DeptId);
            if (Depratment != null)
            {
                Depratment.DeptName = department.DeptName;
                Depratment.DeptId = department.DeptId;
                Depratment.Capacity = department.Capacity;

                db.SaveChanges();
            }
        }

    }
}
