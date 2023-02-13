using PlanMyTrip.Data;
using PlanMyTrip.DataTransferObject;
using PlanMyTrip.LogicLayer.InterfaceLogic;
using PlanMyTrip.Models;

namespace PlanMyTrip.LogicLayer.ClassLogic
{
    public class UserClass : UserInterface
    {
        private readonly PMTDbContext Database;
        public UserClass(PMTDbContext _Database)
        {
            Database = _Database;
        }
        public string LoginUser(LoginDTO LoginObj)
        {
            var user = Database.UserTable.FirstOrDefault(x => x.UserName == LoginObj.UserName);
            if(user == null)
            {
                return "1"; //"User does not exist"
            }
            else
            {
                if(user.Password == LoginObj.Password)
                {
                    return "2";// "Login successfull";
                }
                else
                {
                    return "3";// "Password is incorrect";
                }
            }
        }

        public string RegisterUser(RegisterDTO userObj)
        {
            var user = Database.UserTable.FirstOrDefault(x => x.UserName == userObj.UserName);
            if( user == null)
            {
                user = new User();
                user.UserName = userObj.UserName;
                user.Password = userObj.Password;
                user.Email = userObj.Email;
                user.FullName = userObj.FullName;
                user.MobileNumber = userObj.MobileNumber;
                user.UserType = userObj.UserType;
                if(user != null)
                {
                    Database.UserTable.Add(user);
                    Database.SaveChanges();
                    return "1";
                }
                else
                {
                    return "2";
                }
            }
            else
            {
                return "3";
            }
        }
    }
}
