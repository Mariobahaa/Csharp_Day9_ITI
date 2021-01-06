using System;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee E1 = new Employee();
            E1.EmployeeID = 1;
            E1.BirthDate = DateTime.Now; // not old
            E1.VacationStock = 0; //no vacations left

            Employee E2 = new Employee();
            E2.EmployeeID = 2;
            DateTime E2Bdate = new DateTime(1920,01,01);
           
            E2.BirthDate = E2Bdate; // old
            E2.VacationStock = 100; //many vacations left

            SalesPerson SP = new SalesPerson();
            SP.EmployeeID = 3;
            SP.BirthDate = DateTime.Now; // not old
            SP.VacationStock = -1; //negative vacations left
            SP.AchievedTarget = 10;

            BoardMember BM = new BoardMember();
            BM.EmployeeID = 4;
            BM.BirthDate = E2.BirthDate; //old
            BM.VacationStock = -1; //negative vacations left

            Department Dept = new Department();
            Dept.DeptName = "Sales";
            Dept.DeptID = 1;
            Dept.AddStaff(E1);
            Dept.AddStaff(E2);
            Dept.AddStaff(SP);
            Dept.AddStaff(BM);

            Club club = new Club();
            club.ClubID = 1;
            club.ClubName = "Old Boys";
            club.AddMember(E1);
            club.AddMember(E2);
            club.AddMember(SP);
            club.AddMember(BM);

            E1.EndOfYearOperation();
            E1.RequestVacation(DateTime.Now, DateTime.Now.AddDays(2));

            E2.EndOfYearOperation();
            E2.RequestVacation(DateTime.Now, DateTime.Now.AddDays(2));

            SP.EndOfYearOperation();
            SP.RequestVacation(DateTime.Now, DateTime.Now.AddDays(2));
            SP.CheckTarget(100); //didn't acheive

            BM.EndOfYearOperation();
            BM.RequestVacation(DateTime.Now, DateTime.Now.AddDays(2));
            BM.Resign(); //didn't acheive
        }
    }
}
