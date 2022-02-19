using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabExamProject.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        
        
        [Display(Name = "Product Name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="plz Enter Product Name")]
        [StringLength (50,ErrorMessage ="The {0} value cannot be greater than {1} characters")]
        [Range(typeof(string),"2","5",ErrorMessage ="String is in between 2 and 5")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "plz Enter rate ")]
        public decimal Rate { get; set; }
       
        [Required(ErrorMessage = "plz Enter discription")]
        [StringLength(200, ErrorMessage = "The {0} value cannot be greater than {1} characters")]
        public string Description{ get; set; }
       
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "plz select categoryName")]
        public string CategoryName { get; set; }

    }
}