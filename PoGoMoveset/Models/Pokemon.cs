using System;
using System.Collections.Generic;
using System.Text;

namespace PoGoMoveset.Models
{
    public class Pokemon
    {
        public int Dex { get; set; }
        public string SpeciesName { get; set; }
        public string SpeciesId { get; set; }
        public PokemonBaseStats BaseStats { get; set; }
        public string[] Types { get; set; }
        public string[] FastMoves { get; set; }
        public string[] ChargedMoves { get; set; }
        public string[] Tags { get; set; }
        public PokemonDefaultIVs DefaultIVs { get; set; }
        public int Level25CP { get; set; }
    }

    public class PokemonBaseStats
    {
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
    }

    public class PokemonDefaultIVs
    {
        public decimal[] Cp1500 { get; set; }
        public decimal[] Cp2500 { get; set; }
    }
}
