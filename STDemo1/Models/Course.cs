using System.ComponentModel.DataAnnotations.Schema;

namespace STDemo1.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public virtual Department Department { get; set; }
        public override string ToString()
        {
            return $"{Id}:{Name}:{DeptId}";
        }
    }
}
