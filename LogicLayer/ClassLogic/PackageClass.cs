using PlanMyTrip.Data;
using PlanMyTrip.DataTransferObject;
using PlanMyTrip.LogicLayer.InterfaceLogic;
using PlanMyTrip.Models;

namespace PlanMyTrip.LogicLayer.ClassLogic
{
    public class PackageClass : PackageInterface
    {
        private readonly PMTDbContext Database;
        public PackageClass(PMTDbContext database)
        {
            Database = database;
        }

        public string AddPackage(PackageAddDTO PackageObj)
        {
            var package = Database.PackageTable.FirstOrDefault(x => x.PackageName == PackageObj.PackageName);
            if (package == null)
            {
                package = new Package();
                package.PackageName = PackageObj.PackageName;
                package.PackagePrice = PackageObj.PackagePrice;
                package.PackageDisPrice = PackageObj.PackageDisPrice;
                package.Destination = PackageObj.Destination;
                package.Duration = PackageObj.Duration;
                package.PersonCount = PackageObj.PersonCount;
                package.PackageDetails = PackageObj.PackageDetails;
                if (package != null)
                {
                    Database.PackageTable.Add(package);
                    Database.SaveChanges();
                    return "1"; //Package added successfully
                }
                else
                {
                    return "2"; //Unable to add Package
                }
            }
            else
            {
                return "3";//Package is already existing
            }
        }

        public string DeletePackage(int Pid)
        {
            var package = Database.PackageTable.FirstOrDefault(x => x.PackageId == Pid);
            if (package != null)
            {
                Database.PackageTable.Remove(package);
                Database.SaveChanges();
                return "1";
            }
            return "2";
        }

        public string EditPackage(int Pid, PackageAddDTO PackageObj)
        {
            var package = Database.PackageTable.FirstOrDefault(x => x.PackageId == Pid);
            if (package != null)
            {
                package.PackageName = PackageObj.PackageName;
                package.PackagePrice = PackageObj.PackagePrice;
                package.PackageDisPrice = PackageObj.PackageDisPrice;
                package.Destination = PackageObj.Destination;
                package.Duration = PackageObj.Duration;
                package.PersonCount = PackageObj.PersonCount;
                package.PackageDetails = PackageObj.PackageDetails;
                Database.SaveChanges();
                return "1"; //Package Edited successfully
            }
            else
            {
                return "2";//Package is not found
            }
        }

        public List<Package> GetAllPackages()
        {
            return Database.PackageTable.ToList();
        }

        public Package ViewPackage(int Pid)
        {
            var package = Database.PackageTable.FirstOrDefault(x => x.PackageId == Pid);
            if (package != null)
            {
                return package;
            }
            else 
            {
                return null;
            }
        }
    }
}
