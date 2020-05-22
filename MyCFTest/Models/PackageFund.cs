using System;
using System.Collections.Generic;
using System.Text;

namespace MyCFTest.Models
{
    public class PackageFund
    {
        public int Id { get; set; }
        public Backer Backer { get; set; }
        public Project Project { get; set; }
        public Package Package { get; set; }
        public DateTime DateFund { get; set; }

    }
}
