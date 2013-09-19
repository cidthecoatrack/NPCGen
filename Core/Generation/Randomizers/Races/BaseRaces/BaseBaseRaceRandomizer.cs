﻿using NPCGen.Core.Data.Alignments;
using NPCGen.Core.Generation.Providers.Interfaces;
using System;

namespace NPCGen.Core.Generation.Randomizers.Races.BaseRaces
{
    public abstract class BaseBaseRaceRandomizer : IBaseRaceRandomizer
    {
        private IPercentileResultProvider percentileResultProvider;

        public BaseBaseRaceRandomizer(IPercentileResultProvider percentileResultProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
        }

        public String Randomize(Alignment alignment, String className)
        {
            var tableName = String.Format("{0}{1}BaseRaces", alignment.GetGoodnessString(), className);
            var baseRace = String.Empty;

            do baseRace = percentileResultProvider.GetPercentileResult(tableName);
            while (!RaceIsAllowed(baseRace, alignment, className));

            return baseRace;
        }

        protected abstract Boolean RaceIsAllowed(String baseRace, Alignment alignment, String className);
    }
}