using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanMyTrip.DataTransferObject;
using PlanMyTrip.LogicLayer.InterfaceLogic;
using PlanMyTrip.Models;

namespace PlanMyTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserInterface _UserInterface;
        public UserController(UserInterface _UserInterface)
        {
            this._UserInterface = _UserInterface;
        }

        [HttpPost("Register")]
        public IActionResult RegisterUser(RegisterDTO userObj)
        {
            string result = _UserInterface.RegisterUser(userObj);
            if(result =="1")
            {
                return Ok("Registeration Successfull");
            }
            else if(result =="2")
            {
                return BadRequest("Registeration Failed");
            }
            else if(result=="3")
            {
                return BadRequest("User Details is already existing");
            }
            else
            {
                return BadRequest("Unable to register");
            }
        }
        [HttpPost("Login")]
        public IActionResult LoginUser(LoginDTO LoginObj)
        {
            string result = _UserInterface.LoginUser(LoginObj);
            if (result == "2")
            {
                return Ok("Login Successfull");
            }
            else if (result == "1")
            {
                return BadRequest("User does not exist");
            }
            else if (result == "3")
            {
                return BadRequest("Password is incorrect");
            }
            else
            {
                return BadRequest("Unable to Login");
            }
        }
    }
}
