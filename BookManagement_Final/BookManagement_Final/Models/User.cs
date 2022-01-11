using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore_project.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
       
        public string MiddleName { get; set; }
         [Required]
        public string LastName { get; set; }
      
    }
}
