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
            Console.Write($"Layed off Employee with ID: {this?.EmployeeID} ");
            Console.WriteLine($"Because {e.Cause}");
                EmployeeLayOff?.Invoke(this, e);
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
            if (From.CompareTo(To) > 0) return false;
            int reqDays = To.Subtract(From).Days;
            VacationStock -= reqDays;

            if(VacationStock<0)
                OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.vacation });

            return VacationStock >=0;   
        }
        public void EndOfYearOperation()
        {
            DateTime retirement = BirthDate.AddYears(60);

            if (DateTime.Now.CompareTo(retirement) > 0)
                OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.retired });  
        }
        
    }

    class SalesPerson : Employee
    {
        public int AchievedTarget { get; set; }
        public bool CheckTarget(int Quota)
        {
            if(AchievedTarget< Quota)
                OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.target });

            return AchievedTarget >= Quota;
        }

        protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            if(e?.Cause == LayOffCause.target || e?.Cause == LayOffCause.retired)
                base.OnEmployeeLayOff(e);
        }
    }
    class BoardMember : Employee
    {
        public void Resign()
        {
            OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.board });

        }

        protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            if (e?.Cause == LayOffCause.board)
                base.OnEmployeeLayOff(e);
        }
    }

    
    public enum LayOffCause
    { ///Implement it YourSelf 
        retired, //retired employee
        vacation, //vacation stock exceeded
        target, //failed to complete target
        board //board member

        //YES!! I know that retired and board can be the same thing. ;)
    }
    public class EmployeeLayOffEventArgs
    {
        public LayOffCause Cause { get; set; }
    }
}

