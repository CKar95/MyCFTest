using Microsoft.EntityFrameworkCore;
using MyCFTest.Models;
using MyCFTest.Options;
using MyCFTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCFTest.Services
{
    public class PackageManagement
    {
        private CFDbContext db;

        public PackageManagement(CFDbContext _db)
        {
            db = _db;
        }

        public Package CreatePackage(PackageOption packOption)
        {
            Project project = db.Projects.Find(packOption.ProjectId);

            Package package = new Package
            {
                Amount = packOption.Amount,
                Reward = packOption.Reward,
                Description = packOption.Description,
                Project = project
            };

            db.Packages.Add(package);
            db.SaveChanges();

            return package;
        }

        public List<Package> FindPackagesByProjectId(int projId)
        {
            return db.Packages
                .Where(pk => pk.Project.Id == projId).ToList();
        }
    }
}
