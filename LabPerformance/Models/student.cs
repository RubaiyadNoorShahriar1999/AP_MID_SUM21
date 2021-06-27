using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabPerformance.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string ID { get; set; }

        public string DOB { get; set; }
        public int Credit { get; set; }
        public double CGPA { get; set; }
        public int Dept_ID { get; set; }
    }
}