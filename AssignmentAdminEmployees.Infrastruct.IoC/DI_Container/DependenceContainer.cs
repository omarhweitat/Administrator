using AssignmentAdminEmployees.Application.Interface;
using AssignmentAdminEmployees.Application.Services;
using AssignmentAdminEmployees.Domain.Interface;
using AssignmentAdminEmployees.Infrastruct.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Infrastruct.IoC.DI_Container
{
    public class DependenceContainer
    {

        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<ILoginService, LoginServices>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IEmployeeRepository, EmployeeRepository>();
            service.AddScoped<IEmployeeService, EmployeeServices>();
        }
    }
}
