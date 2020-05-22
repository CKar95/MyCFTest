using MyCFTest.Models;
using MyCFTest.Options;
using MyCFTest.Repository;
using MyCFTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCFTest
{
    class TestMediaManagement
    {
        public static void Testing()
        {
            using CFDbContext db = new CFDbContext();
            MediaManagement mediaMng = new MediaManagement(db);

            MediaOption mediaOption = new MediaOption
            {
                ProjectId = 1,
                Type = "Photo",
                URL = "myFace.png"
            };

            Media media = mediaMng.CreateMedia(mediaOption);
        }
    }
}
