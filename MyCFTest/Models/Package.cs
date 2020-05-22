using System;
using System.Collections.Generic;
using System.Text;

namespace MyCFTest.Models
{
    public class Package
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Reward { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
        public List<PackageFund> PackageFunds { get; set; }

    }
}
