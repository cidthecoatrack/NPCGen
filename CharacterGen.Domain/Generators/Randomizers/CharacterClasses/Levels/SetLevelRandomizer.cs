﻿using CharacterGen.Randomizers.CharacterClasses;
using System.Collections.Generic;

namespace CharacterGen.Domain.Generators.Randomizers.CharacterClasses.Levels
{
    internal class SetLevelRandomizer : ISetLevelRandomizer
    {
        public int SetLevel { get; set; }
        public bool AllowAdjustments { get; set; }

        public SetLevelRandomizer()
        {
            AllowAdjustments = true;
        }

        public int Randomize()
        {
            return SetLevel;
        }

        public IEnumerable<int> GetAllPossibleResults()
        {
            return new[] { SetLevel };
        }
    }
}