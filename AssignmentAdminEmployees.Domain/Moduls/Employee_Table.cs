using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Domain.Moduls
{
    public class Employee_Table
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string NameArabic { get; set; }
        public string Email { get; set; }
        public string Working_From { get; set; }
        public string Working_to { get; set; }
        public string Modile { get; set; }
        public string Department { get; set; }
        public string Age { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
    }
}
