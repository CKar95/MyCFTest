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
    public class BackerManagement
    {
        private CFDbContext db;

        public BackerManagement(CFDbContext _db)
        {
            db = _db;
        }

        public Backer CreateBacker(BackerOption backOption)
        {
            Backer backer = new Backer
            {
                FirstName = backOption.FirstName,
                LastName = backOption.LastName,
                Email = backOption.Email,
                Username = backOption.Username,
                Password = backOption.Password,
                Dob = backOption.Dob
            };

            db.Backers.Add(backer);
            db.SaveChanges();

            return backer;
        }

        public PackageFund FundProject(PackageFundOption pfOption)
        {
            Backer backer = db.Backers.Find(pfOption.BackerId);
            Project project = db.Projects.Find(pfOption.ProjectId);
            Package package = db.Packages.Find(pfOption.PackageId);

            PackageFund packageFund = new PackageFund
            {
                Backer = backer,
                Project = project,
                Package = package,
                DateFund = DateTime.Now
            };

            db.PackageFunds.Add(packageFund);
            db.SaveChanges();
            return packageFund;
        }

        public List<Project> FindProjectsFundedByBacker(int backerId)
        {
            List<PackageFund> pfs = db.PackageFunds.Include(pf => pf.Project).Where(pf => pf.Backer.Id == backerId).ToList();
            List<Project> projects = new List<Project>();

            foreach (PackageFund pf in pfs)
            {
                projects.Add(pf.Project);
            }

            return projects;
        }
    }
}
