using System;
using System.Collections.Generic;
using System.Text;

namespace MyCFTest.Models
{
    public class Backer : User
    {
        public int ProjectsFunded { get; set; }
        public int TotalAmount { get; set; }
        public List<PackageFund> PackageFunds { get; set; }
    }
}
