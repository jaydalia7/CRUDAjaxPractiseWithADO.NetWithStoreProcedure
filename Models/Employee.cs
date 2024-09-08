using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAjaxPractiseWithADO.NetWithStoreProcedure.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}