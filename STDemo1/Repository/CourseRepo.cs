using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STDemo1.Data;
using STDemo1.Models;

namespace STDemo1.Repository
{
    public class CourseRepo : ICourseRepo
    {
        ITIContext db;
        public CourseRepo(ITIContext db)
        {
            this.db = db;
        }
        public void Add(Course course)
        {
            db.Add(course);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var course = db.Courses.FirstOrDefault(a => a.Id == id);
            db.Courses.Remove(course);
            db.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return db.Courses.Include(s => s.Department).ToList();
        }


        public Course GetById(int id)
        {
            return db.Courses.FirstOrDefault(a => a.Id == id);
        }

        public void Edit(Course course)
        {
            var Course = db.Courses.FirstOrDefault(a => a.Id == course.Id);
            if (Course != null)
            {
                Course.Id = course.Id;
                Course.Name = course.Name;
                Course.DeptId = course.DeptId;

                db.SaveChanges();
            }
        }


    }
    
}
