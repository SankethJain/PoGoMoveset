using System;
using System.Collections.Generic;
using System.Text;

namespace PoGoMoveset.Models
{
    public class Settings
    {
        public int PartySize { get; set; }
        public int MaxBuffStages { get; set; }
        public int BuffDivisor { get; set; }
        public decimal ShadowAtkMult { get; set; }
        public decimal ShadowDefMult { get; set; }
    }
}
