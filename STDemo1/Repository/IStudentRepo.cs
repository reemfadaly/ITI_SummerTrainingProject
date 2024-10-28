using Microsoft.EntityFrameworkCore;
using STDemo1.Data;
using STDemo1.Models;

namespace STDemo1.Repository
{
    public interface IStudentRepo
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public void Add(Student student);
        public void Edit(Student student);
        public void DeleteById(int id);
    }
   
}
