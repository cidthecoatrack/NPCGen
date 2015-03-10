﻿using System;
using NPCGen.Common.Races;
using NPCGen.Tables.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables.Races.Metaraces
{
    [TestFixture]
    public class DragonSpeciesTests : CollectionTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Set.Collection.DragonSpecies; }
        }

        [TestCase("Lawful Good",
            RaceConstants.Metaraces.Species.Bronze,
            RaceConstants.Metaraces.Species.Gold,
            RaceConstants.Metaraces.Species.Silver)]
        [TestCase("Neutral Good",
            RaceConstants.Metaraces.Species.Bronze,
            RaceConstants.Metaraces.Species.Gold,
            RaceConstants.Metaraces.Species.Silver,
            RaceConstants.Metaraces.Species.Brass,
            RaceConstants.Metaraces.Species.Copper)]
        [TestCase("Chaotic Good",
            RaceConstants.Metaraces.Species.Brass,
            RaceConstants.Metaraces.Species.Copper)]
        [TestCase("Lawful Evil",
            RaceConstants.Metaraces.Species.Blue,
            RaceConstants.Metaraces.Species.Green)]
        [TestCase("Neutral Evil",
            RaceConstants.Metaraces.Species.Blue,
            RaceConstants.Metaraces.Species.Green,
            RaceConstants.Metaraces.Species.Black,
            RaceConstants.Metaraces.Species.Red,
            RaceConstants.Metaraces.Species.White)]
        [TestCase("Chaotic Evil",
            RaceConstants.Metaraces.Species.Black,
            RaceConstants.Metaraces.Species.Red,
            RaceConstants.Metaraces.Species.White)]
        public override void DistinctCollection(String name, params String[] collection)
        {
            base.DistinctCollection(name, collection);
        }
    }
}