using MyCFTest.Models;
using MyCFTest.Options;
using MyCFTest.Repository;
using MyCFTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCFTest
{
    class TestProjectCreatorManagement
    {
        public static void Testing()
        {
            using CFDbContext db = new CFDbContext();
            ProjectCreatorManagement pcMng = new ProjectCreatorManagement(db);

            ProjectCreatorOption pcOption = new ProjectCreatorOption
            {
                FirstName = "Nikos",
                LastName = "Nikou",
                Email = "nik@hot",
                Username = "nik",
                Password = "123",
                Dob = DateTime.Now
            };

            ProjectCreator pc = pcMng.CreateProjectCreator(pcOption);
        }
    }
}
