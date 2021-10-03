
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
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<User> GetUser()
        {
            return _db.Users;
        }
    }
}
