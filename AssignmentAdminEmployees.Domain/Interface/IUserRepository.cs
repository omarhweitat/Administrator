using AssignmentAdminEmployees.Domain.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Domain.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUser();
    }
}
