using System;
using System.Collections.Generic;
using System.Text;

namespace PoGoMoveset.Models
{
    public class Cup
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public CupCriteria[] Include { get; set; }
        public CupCriteria[] Exclude { get; set; }
        public int PartySize { get; set; }
        public string[] RestrictedPokemon { get; set; }
        public Slot[] Slots { get; set; }
    }

    public class CupCriteria
    {
        public string FilterType { get; set; }
        public string[] Values { get; set; }
    }

    public class Slot
    {
        public string[] Pokemon { get; set; }
    }
}
