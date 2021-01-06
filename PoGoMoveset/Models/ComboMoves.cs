using System;
using System.Collections.Generic;
using System.Text;

namespace PoGoMoveset.Models
{
    public class ComboMoves
    {
        public Move FastMove { get; set; }
        public Move ChargedMove { get; set; }
        public Pokemon[] Pokemon { get; set; }
        public decimal CombinedDPT
        {
            get
            {
                return FastMove.DPT * ChargedMove.DPT;
            }
        }

        public decimal CombinedDeadliness
        {
            get
            {
                return FastMove.DPT * ChargedMove.DPE;

            }
        }

        public decimal MostEfficient
        {
            get
            {
                if (FastMove.EGPT == 0)
                {
                    return 0;
                }
                var totalTurns = ChargedMove.Energy / FastMove.EGPT;
                var totDamage = (FastMove.DPT * totalTurns) + ChargedMove.DPT;
                return totDamage / (totalTurns + ChargedMove.Turn);
            }
        }
    }
}
