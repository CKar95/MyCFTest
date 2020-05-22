using MyCFTest.Models;
using MyCFTest.Options;
using MyCFTest.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCFTest.Services
{
    class ProjectStatusManagement
    {
        private CFDbContext db;

        public ProjectStatusManagement(CFDbContext _db)
        {
            db = _db;
        }

        public ProjectStatus CreateProjectStatus(ProjectStatusOption psOption)
        {
            Project project = db.Projects.Find(psOption.ProjectId);

            ProjectStatus ps = new ProjectStatus
            {
                Title = psOption.Title,
                Project = project,
                Date = DateTime.Now
            };

            db.ProjectStatuses.Add(ps);
            db.SaveChanges();

            return ps;
        }
    }
}
