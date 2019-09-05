using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d2tv.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Tag { get; set; }
        public double Rating { get; set; }
        public int Losses { get; set; }
        public int Wins { get; set; }

        public string LogoUrl { get; set; }
    }
}
