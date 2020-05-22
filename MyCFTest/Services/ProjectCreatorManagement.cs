using MyCFTest.Models;
using MyCFTest.Options;
using MyCFTest.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCFTest.Services
{
    public class ProjectCreatorManagement
    {
        private CFDbContext db;

        public ProjectCreatorManagement(CFDbContext _db)
        {
            db = _db;
        }

        public ProjectCreator CreateProjectCreator(ProjectCreatorOption pcOption)
        {
            ProjectCreator pc = new ProjectCreator
            {
                FirstName = pcOption.FirstName,
                LastName = pcOption.LastName,
                Email = pcOption.Email,
                Username = pcOption.Username,
                Password = pcOption.Password,
                Dob = pcOption.Dob
            };

            db.ProjectCreators.Add(pc);
            db.SaveChanges();

            return pc;
        }

        public ProjectCreator FindProjecCreatortById(int pcId)
        {
            return db.ProjectCreators.Find(pcId);
        }
    }
}
