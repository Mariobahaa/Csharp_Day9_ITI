using System;
using System.Collections.Generic;
using System.Text;

namespace Day9
{
    class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }

        List<Employee> Staff;
        public void AddStaff(Employee E)
        {
            if (Staff == null) Staff = new List<Employee>();

            if (E != null)
            {
                Staff?.Add(E);
                E.EmployeeLayOff += RemoveStaff;
            }
            ///Try Register for EmployeeLayOff Event Here
        }
        ///CallBackMethod
        public void RemoveStaff(object sender,
       EmployeeLayOffEventArgs e)
        {
            if(sender is Employee Emp){
                Staff?.Remove(Emp);
            }
            
        }
    }
}
