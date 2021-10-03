using AssignmentAdminEmployees.Application.DTO;
using AssignmentAdminEmployees.Application.Interface;
using AssignmentAdminEmployees.Application.TableDataModel;
using AssignmentAdminEmployees.Domain.Interface;
using AssignmentAdminEmployees.Domain.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Application.Services
{
    public class EmployeeServices : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void CreateEmployee(EmployeeDTO employeeDTO)
        {
            var Employee = new EMPLOYEE
            {
                EMPLOYEE_NAME_LANG1 = employeeDTO.EMPLOYEE_NAME_LANG1,
                EMPLOYEE_NAME_LANG2 = employeeDTO.EMPLOYEE_NAME_LANG2,
                EMAIL_ADDRERSS = employeeDTO.EMAIL_ADDRERSS,
                MOBILE = employeeDTO.MOBILE,
                EMPLOYEE_STATUS_ID = employeeDTO.EMPLOYEE_STATUS_ID,
                EMPLOYEE_DEPARTMENT_ID = employeeDTO.EMPLOYEE_DEPARTMENT_ID,
                WORKING_HOUR_FROM = employeeDTO.WORKING_HOUR_FROM,
                WORKING_HOUR_TO = employeeDTO.WORKING_HOUR_TO,
                USER_ADD=employeeDTO.USER_ADD,
                AGE = employeeDTO.AGE,
                SALARY = employeeDTO.SALARY,
                GENDER_ID = employeeDTO.GENDER_ID
            };
            Employee.RECORDSTATUS = 2;
            DateTime date = DateTime.Now;
            Employee.DATETIMEADD = decimal.Parse($"{date:yyyyMMddhhmmss}");
            _employeeRepository.CreateEmployee(Employee);
        }

        public void DeleteEmployee(decimal? Id)
        {
            _employeeRepository.DeleteEmployee(Id);
        }

        public EmployeeDTO FindEmployee(decimal? Id)
        {
            var Employee = _employeeRepository.FindEmployee(Id);

            return new EmployeeDTO
            {
                EMPLOYEE_NAME_LANG1 = Employee.EMPLOYEE_NAME_LANG1,
                EMPLOYEE_NAME_LANG2 = Employee.EMPLOYEE_NAME_LANG2,
                EMAIL_ADDRERSS = Employee.EMAIL_ADDRERSS,
                MOBILE = Employee.MOBILE,
                EMPLOYEE_STATUS_ID = Employee.EMPLOYEE_STATUS_ID,
                EMPLOYEE_DEPARTMENT_ID = Employee.EMPLOYEE_DEPARTMENT_ID,
                WORKING_HOUR_FROM = Employee.WORKING_HOUR_FROM,
                WORKING_HOUR_TO = Employee.WORKING_HOUR_TO,
                AGE = Employee.AGE,
                SALARY = Employee.SALARY,
                GENDER_ID = Employee.GENDER_ID,
                

            };
        }

        public IEnumerable<DEPARTMENT> GETDEPARTMENTS()
        {
            return _employeeRepository.GETDEPARTMENTS();
        }

        public IEnumerable<EMPLOYEE> GetEMPLOYEES()
        {
            return _employeeRepository.GetEMPLOYEES();
        }

        public IEnumerable<Employee_Table> GetEmpolyeeActive()
        {
            return _employeeRepository.GetEmpolyeeActive();
        }

        public IEnumerable<GENDER> GETGENDERS()
        {
            return _employeeRepository.GETGENDERS();
        }

        public IEnumerable<STATUS> GETSTATUS()
        {
            return _employeeRepository.GETSTATUS();
        }

        public object PostEmployeeTableDataJson(DataTableRequest model)
        {
            try
            {
                var totalRecords = 0;
                var recordsFiltered = 0;
                model.Start = model.Start != 0 ? (model.Start / 10) : 0;
                model.Draw = model.Draw != 0 ? (model.Draw) : 1;
                model.Length = model.Length == 0 ? 10 : model.Length;
                var data = _employeeRepository.GetEmpolyeeFromDB().AsQueryable();
                totalRecords = data.Count();
                string SearchText = model.Search.Value.ToLower();
                if (!string.IsNullOrWhiteSpace(SearchText))
                {
                    data = data.Where(x => (x.Name.ToLower().Contains(SearchText)));
                }
                string Name = model.Columns[1].Search.Value.ToLower();
                if (!string.IsNullOrWhiteSpace(Name))
                {
                    data = data.Where(x => (x.Name.ToLower().Contains(Name)));
                }
                
                string Email = model.Columns[2].Search.Value.ToLower();
                if (!string.IsNullOrWhiteSpace(Email))
                {
                    data = data.Where(x => (x.Email.ToLower().Contains(Email)));
                }
                
                string Mobile = model.Columns[3].Search.Value.ToLower();
                if (!string.IsNullOrWhiteSpace(Mobile))
                {
                    data = data.Where(x => (x.Modile.ToLower().Contains(Mobile)));
                }
                
                
                recordsFiltered = data.Count();
                data = data
                        .OrderByDescending(x => x.Id)
                        .Skip(model.Start * model.Length)
                        .Take(model.Length);
                var Finaldata = data
                            .Select(x => new
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Email = x.Email,
                                Modile = x.Modile,
                                Status = x.Status,
                                Gender=x.Gender,
                                Salary=x.Salary
                            }).ToList();
                var Data = new
                {
                    Draw = model.Draw,
                    RecordsTotal = totalRecords,
                    RecordsFiltered = recordsFiltered,
                    Data = Finaldata
                };

                return Data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var Employee = _employeeRepository.FindEmployee(employeeDTO.EMPLOYEE_ID);
            Employee.EMPLOYEE_ID = employeeDTO.EMPLOYEE_ID;
            Employee.EMPLOYEE_NAME_LANG1 = employeeDTO.EMPLOYEE_NAME_LANG1;
            Employee.EMPLOYEE_NAME_LANG2 = employeeDTO.EMPLOYEE_NAME_LANG2;
            Employee.EMAIL_ADDRERSS = employeeDTO.EMAIL_ADDRERSS;
            Employee.MOBILE = employeeDTO.MOBILE;
            Employee.EMPLOYEE_STATUS_ID = employeeDTO.EMPLOYEE_STATUS_ID;
            Employee.EMPLOYEE_DEPARTMENT_ID = employeeDTO.EMPLOYEE_DEPARTMENT_ID;
            Employee.WORKING_HOUR_FROM = employeeDTO.WORKING_HOUR_FROM;
            Employee.WORKING_HOUR_TO = employeeDTO.WORKING_HOUR_TO;
            Employee.AGE = employeeDTO.AGE;
            Employee.SALARY = employeeDTO.SALARY;
            Employee.GENDER_ID = employeeDTO.GENDER_ID;
            DateTime date = DateTime.Now;
            Employee.DATETIMEMODDEL = decimal.Parse($"{date:yyyyMMddhhmmss}");
            _employeeRepository.UpdateEmployee(Employee);
        }

        
    }
}
