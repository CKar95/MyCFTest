using System;
using System.Collections.Generic;
using System.Text;

namespace MyCFTest.Models
{
    public class Media
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
        public Project Project { get; set; }
    }
}
