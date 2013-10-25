﻿using System;
using System.Collections.Generic;
using NPCGen.Core.Data.Races;
using NPCGen.Core.Data.Stats;
using NPCGen.Core.Generation.Providers.Interfaces;
using NPCGen.Core.Generation.Xml.Parsers.Interfaces;

namespace NPCGen.Core.Generation.Providers
{
    public class StatAdjustmentsProvider : IStatAdjustmentsProvider
    {
        private IStatAdjustmentXmlParser statAdjustmentXmlParser;

        public StatAdjustmentsProvider(IStatAdjustmentXmlParser statAdjustmentXmlParser)
        {
            this.statAdjustmentXmlParser = statAdjustmentXmlParser;
        }

        public Dictionary<String, Int32> GetAdjustments(Race race)
        {
            var adjustments = new Dictionary<String, Int32>();

            foreach (var stat in StatConstants.GetStats())
            {
                var filename = String.Format("{0}StatAdjustments.xml", stat);
                var statAdjustments = statAdjustmentXmlParser.Parse(filename);
                adjustments.Add(stat, statAdjustments[race.BaseRace] + statAdjustments[race.Metarace]);
            }

            return adjustments;
        }
    }
}