using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Models
{
    public class Bookstore
    {

        [Key]

        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Author { get; set; }
        [Required]


        public string Publisher { get; set; }




        public string Edition
        {
            get;
            set;
        }


       

        public string Price
        {
            get; set;
        }
    }
}