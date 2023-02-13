using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanMyTrip.DataTransferObject;
using PlanMyTrip.LogicLayer.InterfaceLogic;

namespace PlanMyTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly PackageInterface packageInterface;
        public PackageController(PackageInterface packageInterface)
        {
            this.packageInterface = packageInterface;
        }

        [HttpPost("Add_Package")]
        public IActionResult AddPackage(PackageAddDTO packageObj)
        {
            string result = packageInterface.AddPackage(packageObj);
            if(result == "1")
            {
                return Ok("Package Added Successfully");
            }
            else if(result == "2")
            {
                return BadRequest("Unable to add Package");
            }
            else
            {
                return BadRequest("Package already exists");
            }
        }
        [HttpPut("Edit_Package/{Pid}")]
        public IActionResult EditPackage([FromRoute] int Pid,PackageAddDTO packageObj)
        {
            string result = packageInterface.EditPackage(Pid,packageObj);
            if (result == "1")
            {
                return Ok("Package Edited Successfully");
            }
            else
            {
                return BadRequest("Package is not found");
            }
        }
        [HttpDelete("Delete_Package/{Pid}")]
        public IActionResult DeletePackage([FromRoute] int Pid)
        {
            string result = packageInterface.DeletePackage(Pid);
            if (result == "1")
            {
                return Ok("Package deleted Successfully");
            }
            else
            {
                return BadRequest("Package Deletion Failed");
            }
        }

        [HttpGet("GetAllPackages")]
        public IActionResult GetAllPackages()
        {
            var result = packageInterface.GetAllPackages();
            if (result!=null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("There is no Package");
            }
        }
        [HttpGet("View_Package/{Pid}")]
        public IActionResult View_Package([FromRoute] int Pid)
        {
            var result = packageInterface.ViewPackage(Pid);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("There is no Package with existing Id");
            }
        }
    }
}
