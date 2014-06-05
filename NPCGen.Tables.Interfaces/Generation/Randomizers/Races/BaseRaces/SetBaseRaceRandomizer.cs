﻿using System;
using System.Collections.Generic;
using NPCGen.Core.Data.CharacterClasses;
using NPCGen.Core.Generation.Randomizers.Races.Interfaces;

namespace NPCGen.Core.Generation.Randomizers.Races.BaseRaces
{
    public class SetBaseRaceRandomizer : IBaseRaceRandomizer
    {
        public String BaseRace { get; set; }

        public String Randomize(String goodness, CharacterClassPrototype prototype)
        {
            return BaseRace;
        }

        public IEnumerable<String> GetAllPossibleResults(String goodness, CharacterClassPrototype prototype)
        {
            return new[] { BaseRace };
        }
    }
}