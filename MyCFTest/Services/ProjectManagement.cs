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
    public class ProjectManagement
    {
        private CFDbContext db;

        public ProjectManagement(CFDbContext _db)
        {
            db = _db;
        }

        //CRUD
        // create read update delete

        public Project CreateProject(ProjectOption projOption)
        {
            ProjectCreatorManagement pcMng = new ProjectCreatorManagement(db);
            Project project = new Project
            {
                ProjectCreator = pcMng.FindProjecCreatortById(projOption.ProjectCreatorId),
                Title = projOption.Title,
                Description = projOption.Description,
                Category = projOption.Category,
                EndDate = projOption.EndDate,
                Goal = projOption.Goal,
                Progress = 0,
                StartDate = DateTime.Now,
                State = true,
                CurrentAmount = 0
            };

            db.Projects.Add(project);
            db.SaveChanges();

            return project;
        }

        public Project FindProjectById(int projId)
        {
            return db.Projects.Find(projId);
        }

        public List<Project> FindProjectsByCategory(string category)
        {
            return db.Projects.Where(p => p.Category == category).ToList();
        }

        public List<Project> FindProjectsByTitle(string title)
        {
            return db.Projects.Where(p => p.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        public List<Project> FindProjects()
        {
            return db.Projects.ToList();
        }
        public List<Project> FindProjectsByProjectCreator(int pcId)
        {
            return db.Projects.Where(p => p.ProjectCreator.Id == pcId).ToList();
        }

        

        public List<Project> SortProjectsByTrends()
        {
            List<Project> projectsNotSorted = FindProjects();
            foreach (Project p in projectsNotSorted)
            {
                p.NumberOfBackers = db.PackageFunds.Where(pf => pf.Project.Id == p.Id).ToList().Count();
            }

            return projectsNotSorted.OrderByDescending(p => p.NumberOfBackers).ToList();
        }

        public decimal TrackProgressByProjectId(int projId)
        {
            PackageManagement pkMng = new PackageManagement(db);
            Project project = FindProjectById(projId);
            List<Package> packages = pkMng.FindPackagesByProjectId(projId);


            List<PackageFund> packageFunds = db.PackageFunds
                .Where(pf => pf.Project.Id == projId)
                .ToList();


            decimal fundsOfProject = 0;
            foreach(PackageFund pf in packageFunds)
            {
                fundsOfProject += pf.Package.Amount;
            }

            if (fundsOfProject > 0)
                return (fundsOfProject / project.Goal) * 100m;
            else
                return 0;
        }


        public Project Update(ProjectOption projOption, int projId)
        {
            Project project = db.Projects.Find(projId);

            if (projOption.Title != null)
                project.Title = projOption.Title;
            if (projOption.Description != null)
                project.Description = projOption.Description;
            if (projOption.Category != null)
                project.Category = projOption.Category;
            if (projOption.EndDate != new DateTime())
                project.EndDate = projOption.EndDate;
            if (projOption.Goal > 0)
                project.Goal = projOption.Goal;


            db.SaveChanges();
            return project;
        }


        //Delete Project: Hard
        public bool HardDeleteProjectById(int id)
        {
            Project project = db.Projects.Find(id);
            if (project != null)
            {
                db.Projects.Remove(project);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        //Delete Project: Soft
        public bool SoftDeleteCustomerById(int id)
        {
            Project project = db.Projects.Find(id);
            if (project != null)
            {
                project.State = false;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
