using AssignmentAdminEmployees.Application.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentAdminEmployees.Domain.Moduls;
using AssignmentAdminEmployees.Domain.Interface;

namespace AssignmentAdminEmployees.Application.Services
{
    public class LoginServices : ILoginService
    {
        private readonly IUserRepository _userRepository;
        public LoginServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Validation(string username, string password)
        {
            var User = _userRepository.GetUser().SingleOrDefault(x => x.Username == username
              && x.Password == password);
            return User;
        }

        
    }
}
