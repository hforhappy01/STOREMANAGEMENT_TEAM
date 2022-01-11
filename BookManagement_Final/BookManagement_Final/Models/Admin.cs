using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Models
{
    public class Admin

    {
        [Key]
        public int adminId { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string passwordHash { get; set; }

    }
}