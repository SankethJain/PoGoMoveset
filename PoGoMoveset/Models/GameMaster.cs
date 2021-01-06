using System;
using System.Collections.Generic;
using System.Text;

namespace PoGoMoveset.Models
{
    public class GameMaster
    {
        public Settings Settings { get; set; }
        public RankingScenario[] RankingScenarios { get; set; }
        public Cup[] Cups { get; set; }
        public string[] PokemonTags { get; set; }
        public PokemonRegion[] PokemonRegions { get; set; }
        public string[] ShadowPokemon { get; set; }
        public CliffhangerTier[] CliffhangerTiers { get; set; }
        public Pokemon[] Pokemon { get; set; }
        public Move[] Moves { get; set; }
    }
}
