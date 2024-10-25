using Microsoft.AspNetCore.Mvc;
using ustomLogger.Data;
using ustomLogger.Models;

namespace ustomLogger.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private  UserData _userdata; 
        private  List<User> _users => _userdata.GetUsers();
        public UserController(UserData userData) 
        {
            _userdata = userData;
        }
        [HttpGet]
        [Route("GetUserById")]
        public  User GetUserById(int id)
        {
            var User =  _users.FirstOrDefault(x => x.Id == id);
            if (User != null)
            {
                return User;
            }
            return null;
        }
        [HttpPost]
        [Route("CreateUser")]
        public User CretaeUser([FromBody] User user)
        {
            var UserCerate = _users.FirstOrDefault(U => U.Id == user.Id);
            if (UserCerate == null)
            {
                _users.Add(user);
                foreach (var item in _users)
                {
                    Console.WriteLine(item.Name);
                }
                return UserCerate;
            }
            return null;
        }
    }
}
