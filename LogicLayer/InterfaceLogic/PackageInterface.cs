using PlanMyTrip.DataTransferObject;
using PlanMyTrip.Models;

namespace PlanMyTrip.LogicLayer.InterfaceLogic
{
    public interface PackageInterface
    {
        string AddPackage(PackageAddDTO PackageObj);

        string EditPackage(int Pid,PackageAddDTO PackageObj);
        string DeletePackage(int Pid);
        Package ViewPackage (int Pid);
        List<Package> GetAllPackages();

    }
}
