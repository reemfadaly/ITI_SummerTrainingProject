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
        public int? Age { get; set; } //? accepts null
        public int DeptId { get; set; }
        //for different naming 
        //[ForeignKey("Department")]    
        //public int? DeptNo {get; set;}  ?is for nullable (to be not required )
        [Required]
        [RegularExpression(@"[a-zA-Z0-9_]*@[a-zA-Z]+.[a-zA-Z]{2,4}")] //* zero or more  + one or more
        [Remote(action: "IsEmailAvailable", controller: "Student")]
        public string Email {  get; set; }

        [Required, StringLength(15)]
        public string Password { get; set; }    
        [NotMapped] //no need to create a confirmpassword column in db
        [Compare("Password")]
        //[MyValidation] for more validation, customize it using new method in myvalidationattribute
        public string ConfirmPassword { get; set; }
        
        [ForeignKey("DeptId")]
        public virtual Department Department { get; set; }
        public override string ToString()
        {
            return $"{Id}:{Name}:{Age}:{DeptId}";
        }
    }
}
