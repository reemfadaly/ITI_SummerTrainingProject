using STDemo1.Models;
using STDemo1.Data;
namespace STDemo1.Repository
{
    public interface IDepartmentRepo
    {
        public List<Department> GetAll();
        public Department GetById(int id);
        public void Add(Department department);
        public void Edit(Department department);
        public void DeleteById(int id);
    }
   
        //public class DepartmentRepo2 : IDepartmentRepo
        //{
        //    static List<Department> db = new List<Department>();
        //    public void Add(Department department)
        //    {
        //        db.Add(department);
        //    }

        //    public void DeleteById(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public List<Department> GetAll()
        //    {
        //        return db;
        //    }

        //    public Department GetById(int id)
        //    {
        //        return db.FirstOrDefault(a=>a.DeptId==id);
        //    }

        //    public void Update(Department department)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
}
