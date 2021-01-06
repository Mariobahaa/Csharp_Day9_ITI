using System;
using System.Collections.Generic;
using System.Text;

namespace Day9
{
    class Club
    {
        public int ClubID { get; set; }
        public String ClubName { get; set; }
        List<Employee> Members;
        public void AddMember(Employee E)
        {
            Members.Add(E);
            E.EmployeeLayOff += RemoveMember;
            ///Try Register for EmployeeLayOff Event Here
        }
        ///CallBackMethod
        public void RemoveMember
       (object sender, EmployeeLayOffEventArgs e)
        {
            
            if(e.Cause != LayOffCause.retired && e.Cause!=LayOffCause.board)
            {
                if (sender is Employee Emp)
                    Members.Remove(Emp);
            }
            ///Employee Will not be removed from the Club if Age>60
            ///Employee will be removed from Club if Vacation Stock < 0
        }
    }
}
