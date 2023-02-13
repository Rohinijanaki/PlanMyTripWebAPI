using PlanMyTrip.DataTransferObject;
using PlanMyTrip.Models;

namespace PlanMyTrip.LogicLayer.InterfaceLogic
{
    public interface UserInterface
    {
        string RegisterUser(RegisterDTO userObj);
        string LoginUser(LoginDTO LoginObj);
    }
}
