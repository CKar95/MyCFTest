using System;
using System.Collections.Generic;
using System.Text;

namespace MyCFTest.Models
{
    public class ProjectCreator : User
    {
        public List<Project> Projects { get; set; }
    }
}
