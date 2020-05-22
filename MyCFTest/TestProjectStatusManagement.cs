using MyCFTest.Models;
using MyCFTest.Options;
using MyCFTest.Repository;
using MyCFTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCFTest
{
    class TestProjectStatusManagement
    {
        public static void Testing()
        {
            using CFDbContext db = new CFDbContext();
            ProjectStatusManagement psMng = new ProjectStatusManagement(db);

            ProjectStatusOption psOption = new ProjectStatusOption
            {
                Title = "Today is a beutiful day",
                ProjectId = 1
            };

            ProjectStatus ps = psMng.CreateProjectStatus(psOption);
        }
    }
}
