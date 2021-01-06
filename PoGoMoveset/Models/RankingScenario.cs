using System;
using System.Collections.Generic;
using System.Text;

namespace PoGoMoveset.Models
{
    public class RankingScenario
    {
        public string Slug { get; set; }
        public int[] Shields { get; set; }
        public int[] Energy { get; set; }
    }
}
