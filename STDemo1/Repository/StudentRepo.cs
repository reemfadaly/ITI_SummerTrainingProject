using Microsoft.EntityFrameworkCore;
using STDemo1.Data;
using STDemo1.Models;

namespace STDemo1.Repository
{
    public class StudentRepo : IStudentRepo
    {
        ITIContext db; //= new ITIContext();
        public StudentRepo(ITIContext db)
        {
            this.db = db;
        }

        public void Add(Student student)
        {
            db.Add(student);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var student = db.Students.FirstOrDefault(a => a.Id == id);
            db.Students.Remove(student);
            db.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return db.Students.Include(s => s.Department).ToList();
        }

        public Student GetById(int id)
        {
            return db.Students.FirstOrDefault(a => a.Id == id);
        }

        public void Edit(Student student)
        {
            var Student = db.Students.FirstOrDefault(a => a.Id == student.Id);
            if (Student != null)
            {
                Student.Name = student.Name;
                Student.Age = student.Age;
                Student.Email = student.Email;
                Student.DeptId = student.DeptId;

                db.SaveChanges();
            }
        }
    }
}
