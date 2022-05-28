using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Crud_Operation.Data.Models.ViewModels
{
    public class EmployeeVM
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string Designation { get; set; }

        public int Salary { get; set; }
    }
}
