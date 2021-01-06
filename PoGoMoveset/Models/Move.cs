using System;
using System.Collections.Generic;
using System.Text;

namespace PoGoMoveset.Models
{
    public class Move
    {
        public string MoveId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Type { get; set; }
        public decimal Power { get; set; }
        public decimal Energy { get; set; }
        public decimal EnergyGain { get; set; }
        public decimal CoolDown { get; set; }
        public int[] Buffs { get; set; }
        public string BuffTarget { get; set; }
        public string BuffApplyChance { get; set; }

        public decimal Turn
        {
            get
            {
                return CoolDown / 500;
            }
        }
        public decimal EPT
        {
            get
            {
                return Energy / Turn;
            }
        }

        public decimal DPT
        {
            get
            {
                return Power / Turn;
            }
        }

        public decimal EGPT
        {
            get
            {
                return EnergyGain / Turn;
            }
        }

        public decimal EGDamage
        {
            get
            {
                return EGPT * DPT;
            }
        }

        public decimal DPE
        {
            get
            {
                if (Energy == 0)
                {
                    return 0;
                }
                else
                {
                    return Power / Energy;
                }
            }
        }
    }
}
