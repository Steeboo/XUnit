using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    public class Student
    {
        [MaxLength(10)]
        public string Name { get; set; }

        public int Id { get; set; }
    }
}
