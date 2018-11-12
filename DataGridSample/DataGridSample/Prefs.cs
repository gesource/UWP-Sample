using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridSample
{
    public class Region
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
    }

    public class Pref
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
    }
}
