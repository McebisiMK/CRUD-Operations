using System;
using System.Collections.Generic;

namespace Lulalend.Models
{
    public partial class Lecturers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
    }
}
