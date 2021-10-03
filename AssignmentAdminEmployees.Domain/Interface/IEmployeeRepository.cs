using AssignmentAdminEmployees.Domain.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Domain.Interface
{
    public interface IEmployeeRepository
    {
        IEnumerable<EMPLOYEE> GetEMPLOYEES();
        IQueryable<Employee_Table> GetEmpolyeeFromDB();
        IEnumerable<STATUS> GETSTATUS();
        IEnumerable<DEPARTMENT> GETDEPARTMENTS();
        IEnumerable<GENDER> GETGENDERS();
        void CreateEmployee(EMPLOYEE employee);
        void UpdateEmployee(EMPLOYEE employee);
        void DeleteEmployee(decimal? Id);
        EMPLOYEE FindEmployee(decimal? Id);
        IEnumerable<Employee_Table> GetEmpolyeeActive();
    }
}
