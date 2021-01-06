using System;
using System.Collections.Generic;
using System.Text;

namespace Day9
{
    class Employee
    {
        public event
       EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;
        protected virtual void OnEmployeeLayOff
       (EmployeeLayOffEventArgs e)
        {
            throw new NotImplementedException();
        }
        public int EmployeeID { get; set; }
        public DateTime BirthDate
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public int VacationStock
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public bool RequestVacation(DateTime From, DateTime To)
        {
            throw new NotImplementedException();
        }
        public void EndOfYearOperation()
        {
            throw new NotImplementedException();
        }
    }
    public enum LayOffCause
    { ///Implement it YourSelf 
    }
    public class EmployeeLayOffEventArgs
    {
        public LayOffCause Cause { get; set; }
    }

    class SalesPerson : Employee
    {
        public int AchievedTarget { get; set; }
        public bool CheckTarget(int Quota)
        {
            throw new NotImplementedException();
        }
    }
    class BoardMember : Employee
    {
        public void Resign()
        {
            throw new NotImplementedException();
        }
    }
}

