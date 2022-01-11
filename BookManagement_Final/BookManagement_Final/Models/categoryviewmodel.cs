using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore_project.Models
{
    public class categoryviewmodel
    {
        [Key]
        public int categoryID { get; set; }
        [Required]
        public string categoryName { get; set; }
        [Required]
        public string categoryDescription { get; set; }
    }
}
