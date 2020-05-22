using MyCFTest.Models;
using MyCFTest.Options;
using MyCFTest.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCFTest.Services
{
    public class MediaManagement
    {
        private CFDbContext db;

        public MediaManagement(CFDbContext _db)
        {
            db = _db;
        }

        public Media CreateMedia(MediaOption mediaOption)
        {
            Project project = db.Projects.Find(mediaOption.ProjectId);

            Media media = new Media
            {
                Type = mediaOption.Type,
                URL = mediaOption.URL,
                Project = project
            };

            db.Medias.Add(media);
            db.SaveChanges();

            return media;
        }
    }
}
