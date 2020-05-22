using MyCFTest.Models;
using MyCFTest.Options;
using MyCFTest.Repository;
using MyCFTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCFTest
{
    class TestPackageManagement
    {
        public static void Testing()
        {
            using CFDbContext db = new CFDbContext();
            PackageManagement pkMng = new PackageManagement(db);

            //PackageOption pkOption1 = new PackageOption
            //{
            //    ProjectId = 2,
            //    Amount = 110m,
            //    Reward = "2 sugars",
            //    Description = "Thanks for the support"

            //};

            //PackageOption pkOption2 = new PackageOption
            //{
            //    ProjectId = 2,
            //    Amount = 360m,
            //    Reward = "6 sugars",
            //    Description = "Thanks for the support, we love you a lot"

            //};

            //Package package1 = pkMng.CreatePackage(pkOption1);
            //Package package2 = pkMng.CreatePackage(pkOption2);

            List<Package> packages = pkMng.FindPackagesByProjectId(1);

            foreach (Package p in packages)
            {
                Console.WriteLine($"Option ammount: {p.Amount} and reward: {p.Reward}");
            }
        }
    }
}
