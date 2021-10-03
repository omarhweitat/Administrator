
using AssignmentAdminEmployees.Domain.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Application.Interface
{
    public interface ILoginService
    {
        User Validation(string username, string password);
    }
}
