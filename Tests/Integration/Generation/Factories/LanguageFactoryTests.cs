﻿using System;
using System.Collections.Generic;
using Ninject;
using NPCGen.Core.Data.CharacterClasses;
using NPCGen.Core.Data.Races;
using NPCGen.Core.Data.Stats;
using NPCGen.Core.Generation.Factories.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Generation.Factories
{
    [TestFixture]
    public class LanguageFactoryTests : IntegrationTest
    {
        [Inject]
        public ILanguageFactory LanguageFactory { get; set; }
        [Inject]
        public Race Race { get; set; }
        [Inject]
        public CharacterClass CharacterClass { get; set; }
        [Inject]
        public Dictionary<String, Stat> Stats { get; set; }

        [Test]
        public void LanguageFactoryReturnsLanguages()
        {
            for (var i = 0; i < ConfidenceLevel; i++)
            {
                var languages = LanguageFactory.CreateWith(Race, CharacterClass.ClassName, Stats[StatConstants.Intelligence].Bonus);
                Assert.That(languages, Is.Not.Null);
            }
        }
    }
}