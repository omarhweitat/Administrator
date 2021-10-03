using AssignmentAdminEmployees.Domain.Interface;
using AssignmentAdminEmployees.Domain.Moduls;
using AssignmentAdminEmployees.Infrastruct.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Infrastruct.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void CreateEmployee(EMPLOYEE employee)
        {
            _db.EMPLOYEES.Add(employee);
            _db.SaveChanges();
        }

        public void DeleteEmployee(decimal? Id)
        {
            var employee = _db.EMPLOYEES.Find(Id);
            employee.RECORDSTATUS = 3;
            _db.SaveChanges();
        }

        public EMPLOYEE FindEmployee(decimal? Id)
        {
            return _db.EMPLOYEES.Find(Id);
        }

        public IEnumerable<DEPARTMENT> GETDEPARTMENTS()
        {
            return  _db.DEPARTMENTS;
        }

        public IEnumerable<EMPLOYEE> GetEMPLOYEES()
        {
            return _db.EMPLOYEES;
        }

        public IEnumerable<Employee_Table> GetEmpolyeeActive()
        {
            var Data = from employee in _db.EMPLOYEES
                       join status in _db.STATUS
                       on employee.EMPLOYEE_STATUS_ID equals status.STATUS_ID
                       join gender in _db.GENDERS
                       on employee.GENDER_ID equals gender.GENDER_ID
                       join department in _db.DEPARTMENTS
                       on employee.EMPLOYEE_DEPARTMENT_ID equals department.DEPARTMENT_ID
                       where employee.EMPLOYEE_STATUS_ID == 1 && employee.RECORDSTATUS == 2
                       select new Employee_Table
                       {
                           Id = employee.EMPLOYEE_ID,
                           Name = employee.EMPLOYEE_NAME_LANG1,
                           NameArabic =employee.EMPLOYEE_NAME_LANG2,
                           Working_From=employee.WORKING_HOUR_FROM,
                           Working_to=employee.WORKING_HOUR_TO,
                           Department=department.DEPARTMENT_DESC,
                           Age=Convert.ToString(employee.AGE),
                           Email = employee.EMAIL_ADDRERSS,
                           Modile = employee.MOBILE,
                           Status = status.STATUS_DESC,
                           Gender = gender.GENDER_DESC,
                           Salary = Convert.ToDecimal(employee.SALARY),

                       };
            return Data;
        }

        public IQueryable<Employee_Table> GetEmpolyeeFromDB()
        {
            var Data = from employee in _db.EMPLOYEES
                            join status in _db.STATUS
                            on employee.EMPLOYEE_STATUS_ID equals status.STATUS_ID
                            join gender in _db.GENDERS
                            on employee.GENDER_ID equals gender.GENDER_ID
                            where employee.RECORDSTATUS == 2
                            select new Employee_Table
                            {
                                Id=employee.EMPLOYEE_ID,
                                Name=employee.EMPLOYEE_NAME_LANG1,
                                Email=employee.EMAIL_ADDRERSS,
                                Modile=employee.MOBILE,
                                Status=status.STATUS_DESC,
                                Gender=gender.GENDER_DESC,
                                Salary=Convert.ToDecimal(employee.SALARY),
                                
                            };
            return Data;
        }

        public IEnumerable<GENDER> GETGENDERS()
        {
            return _db.GENDERS;
        }

        public IEnumerable<STATUS> GETSTATUS()
        {
            return _db.STATUS;
        }

        public void UpdateEmployee(EMPLOYEE employee)
        {
            _db.EMPLOYEES.Update(employee);
            _db.SaveChanges();
        }
    }
}
