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
            DateTime retirement = BirthDate.AddYears(60);
            if (DateTime.Now.CompareTo(retirement) > 0 || VacationStock < 0)
                EmployeeLayOff.Invoke(this, e);
        }
        public int EmployeeID { get; set; }
        public DateTime BirthDate
        {
            get;
            set;
        }
        public int VacationStock
        {
            get;
            set;
        }
        public bool RequestVacation(DateTime From, DateTime To)
        {
            int reqDays = (To - From).Days;
            VacationStock -= reqDays;
            OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.fired });

            return VacationStock >=0;   
        }
        public void EndOfYearOperation()
        {       
              OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.retired });  
        }
        
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


    public enum LayOffCause
    { ///Implement it YourSelf 
        retired,
        fired //vacation stock exceeded
    }
    public class EmployeeLayOffEventArgs
    {
        public LayOffCause Cause { get; set; }
    }
}

