﻿using CharacterGen.Domain.Tables;
using CharacterGen.Randomizers.Races;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CharacterGen.Tests.Unit.Generators.Randomizers.Races.Metaraces
{
    [TestFixture]
    public abstract class MetaraceRandomizerTestBase : RaceRandomizerTestBase
    {
        protected RaceRandomizer randomizer;
        protected abstract IEnumerable<string> metaraces { get; }

        [SetUp]
        public void MetaraceRandomizerTestBaseSetup()
        {
            mockPercentileSelector.Setup(s => s.SelectAllFrom(It.IsAny<string>())).Returns(metaraces);

            foreach (var metarace in metaraces)
                adjustments[metarace] = 0;

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.MetaraceGroups, alignment.Full)).Returns(metaraces);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.MetaraceGroups, characterClass.Name)).Returns(metaraces);
        }
    }
}