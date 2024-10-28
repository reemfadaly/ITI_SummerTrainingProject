using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace STDemo1.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptId { get; set; }

        [StringLength(15)]
        public string DeptName { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; } = true;
        public virtual List<Student> Students { get; set; }
        public override string ToString()
        {
            return $"{DeptId}:{DeptName}:{Capacity}";
        }
        
    }
}
