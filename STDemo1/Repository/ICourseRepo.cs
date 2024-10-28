using STDemo1.Models;
using STDemo1.Data;
namespace STDemo1.Repository
{
    public interface ICourseRepo
    {
        public List<Course> GetAll();
        public Course GetById(int id);
        public void Add(Course course);
        public void Edit(Course course);
        public void DeleteById(int id);
    }
}
