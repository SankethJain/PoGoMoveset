using System;
using System.Collections.Generic;
using System.Text;

namespace PoGoMoveset.Models
{
    public class CliffhangerTier
    {
        public int League { get; set; }
        public int Max { get; set; }
        public Tier[] Tiers { get; set; }
    }

    public class Tier
    {
        public int Points { get; set; }
        public string[] Pokemon { get; set; }
    }
}
