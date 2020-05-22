using MyCFTest.Models;
using MyCFTest.Options;
using MyCFTest.Repository;
using MyCFTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCFTest
{
    public class TestBackerManagement
    {
        public static void Testing()
        {
            using CFDbContext db = new CFDbContext();
            BackerManagement bckMng = new BackerManagement(db);

            //CREATE BACKER: START
            //BackerOption bckOption = new BackerOption
            //{
            //    FirstName = "Giannhs",
            //    LastName = "Giannou",
            //    Email = "gi@hot",
            //    Username = "gi",
            //    Password = "123",
            //    Dob = DateTime.Now
            //};

            //Backer backer = bckMng.CreateBacker(bckOption);
            //CREATE BACKER: END

            //BACKER FUND A PROJECT: START
            ProjectManagement projMng = new ProjectManagement(db);
            List<Project> projects = projMng.FindProjects();

            foreach (Project p in projects)
            {
                Console.WriteLine($"Project Id = {p.Id}, Title = {p.Title}");
            }

            Console.WriteLine("Please select a Project Id you want to fund");
            int projId = Convert.ToInt32(Console.ReadLine());

            PackageManagement pkMng = new PackageManagement(db);
            List<Package> packages = pkMng.FindPackagesByProjectId(projId);

            foreach (Package pk in packages)
            {
                Console.WriteLine($"Package Id = {pk.Id}, Amount = {pk.Amount}");
            }

            Console.WriteLine("Please select a Package Id with which you will fund the project");
            int pkId = Convert.ToInt32(Console.ReadLine());

            PackageFundOption pfOption = new PackageFundOption
            {
                BackerId = 3,
                PackageId = pkId,
                ProjectId = projId
            };

            bckMng.FundProject(pfOption);
            //BACKER FUND A PROJECT: END

            var projectsfunded = bckMng.FindProjectsFundedByBacker(2);

        }
    }
}
