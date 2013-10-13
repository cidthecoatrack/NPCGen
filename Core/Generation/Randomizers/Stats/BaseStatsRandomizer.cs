﻿using System;
using System.Collections.Generic;
using NPCGen.Core.Data.Stats;
using NPCGen.Core.Generation.Randomizers.Stats.Interfaces;

namespace NPCGen.Core.Generation.Randomizers.Stats
{
    public abstract class BaseStatsRandomizer : IStatsRandomizer
    {
        public Dictionary<String, Stat> Randomize()
        {
            var stats = InitializeStats();

            do
            {
                foreach (var kvp in stats)
                    kvp.Value.Value = RollStat();
            } while (!StatsAreAllowed(stats.Values));

            return stats;
        }

        private Dictionary<String, Stat> InitializeStats()
        {
            var stats = new Dictionary<String, Stat>();

            stats.Add(StatConstants.Strength, new Stat());
            stats.Add(StatConstants.Constitution, new Stat());
            stats.Add(StatConstants.Dexterity, new Stat());
            stats.Add(StatConstants.Intelligence, new Stat());
            stats.Add(StatConstants.Wisdom, new Stat());
            stats.Add(StatConstants.Charisma, new Stat());

            foreach (var kvp in stats)
                kvp.Value.Name = kvp.Key;

            return stats;
        }

        protected abstract Int32 RollStat();
        protected abstract Boolean StatsAreAllowed(IEnumerable<Stat> stats);
    }
}