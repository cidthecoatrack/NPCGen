﻿using NPCGen.Common.Races;
using NPCGen.Generators.Randomizers.Races.Metaraces;
using NUnit.Framework;

namespace NPCGen.Tests.Unit.Generators.Randomizers.Races.Metaraces
{
    [TestFixture]
    public class GoodForcedMetaraceRandomizerTests : MetaraceRandomizerTests
    {
        [SetUp]
        public void Setup()
        {
            randomizer = new GoodForcedMetaraceRandomizer(mockPercentileResultSelector.Object, mockLevelAdjustmentsSelector.Object);
        }

        [Test]
        public void HalfCelestialIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.Metaraces.HalfCelestial);
        }

        [Test]
        public void HalfDragonIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.Metaraces.HalfDragon);
        }

        [Test]
        public void HalfFiendIsNotAllowed()
        {
            AssertRaceIsNotAllowed(RaceConstants.Metaraces.HalfFiend);
        }

        [Test]
        public void WerebearIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.Metaraces.Werebear);
        }

        [Test]
        public void WereboarIsNotAllowed()
        {
            AssertRaceIsNotAllowed(RaceConstants.Metaraces.Wereboar);
        }

        [Test]
        public void WereratIsNotAllowed()
        {
            AssertRaceIsNotAllowed(RaceConstants.Metaraces.Wererat);
        }

        [Test]
        public void WeretigerIsNotAllowed()
        {
            AssertRaceIsNotAllowed(RaceConstants.Metaraces.Weretiger);
        }

        [Test]
        public void WerewolfIsNotAllowed()
        {
            AssertRaceIsNotAllowed(RaceConstants.Metaraces.Werewolf);
        }
    }
}