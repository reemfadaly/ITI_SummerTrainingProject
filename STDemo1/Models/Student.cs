using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace STDemo1.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage="*")]
        [StringLength(15, MinimumLength=3)]
        public string Name { get; set; }

        [Range(10,20)]
        public int? Age { get; set; } 
        public int DeptId { get; set; }
       
        [Required]
        [RegularExpression(@"[a-zA-Z0-9_]*@[a-zA-Z]+.[a-zA-Z]{2,4}")] 
        [Remote(action: "IsEmailAvailable", controller: "Student")]
        public string Email {  get; set; }

        [Required, StringLength(15)]
        public string Password { get; set; }    
        [NotMapped] 
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        [ForeignKey("DeptId")]
        public virtual Department Department { get; set; }
        public override string ToString()
        {
            return $"{Id}:{Name}:{Age}:{DeptId}";
        }
    }
}
