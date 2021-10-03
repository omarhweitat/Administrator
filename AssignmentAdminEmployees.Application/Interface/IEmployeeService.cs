using AssignmentAdminEmployees.Application.DTO;
using AssignmentAdminEmployees.Application.TableDataModel;
using AssignmentAdminEmployees.Domain.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Application.Interface
{
    public interface IEmployeeService
    {
        IEnumerable<EMPLOYEE> GetEMPLOYEES();
        object PostEmployeeTableDataJson(DataTableRequest model);
        IEnumerable<STATUS> GETSTATUS();
        IEnumerable<DEPARTMENT> GETDEPARTMENTS();
        IEnumerable<GENDER> GETGENDERS();
        void CreateEmployee(EmployeeDTO employeeDTO);
        void UpdateEmployee(EmployeeDTO employeeDTO);
        void DeleteEmployee(decimal? Id);
        EmployeeDTO FindEmployee(decimal? Id);
        IEnumerable<Employee_Table> GetEmpolyeeActive();
    }
}
