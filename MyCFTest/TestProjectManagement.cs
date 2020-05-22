using MyCFTest.Models;
using MyCFTest.Options;
using MyCFTest.Repository;
using MyCFTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCFTest
{
    class TestProjectManagement
    {
        public static void Testing()
        {
            using CFDbContext db = new CFDbContext();
            ProjectManagement projMng = new ProjectManagement(db);

            //ProjectOption projOption = new ProjectOption
            //{
            //   ProjectCreatorId = 1,
            //   Title = "Full of sugar juice",
            //   Description = "We are NOT using stevia",
            //   Category = "HealthNOT",
            //   EndDate = DateTime.Now.AddDays(4),
            //   Goal = 5000m,

            //};

            //Project project = projMng.CreateProject(projOption);

            //////////////////////////////////////////
            Console.WriteLine(projMng.TrackProgressByProjectId(1));
            //////////////////////////////////////////

            //var proj = projMng.FindProjectsByProjectCreator(1);

            //var trediProjects = projMng.SortProjectsByTrends();


        }
    }
}
