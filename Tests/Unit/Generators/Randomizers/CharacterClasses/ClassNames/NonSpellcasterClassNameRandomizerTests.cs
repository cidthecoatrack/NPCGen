﻿using CharacterGen.Generators.Domain.Randomizers.CharacterClasses.ClassNames;
using NUnit.Framework;
using System;

namespace CharacterGen.Tests.Unit.Generators.Randomizers.CharacterClasses.ClassNames
{
    [TestFixture]
    public class NonSpellcasterClassNameRandomizerTests : ClassNameRandomizerTests
    {
        protected override String classNameGroup
        {
            get { return "Spellcasters"; }
        }

        [SetUp]
        public void Setup()
        {
            randomizer = new NonSpellcasterClassNameRandomizer(mockPercentileResultSelector.Object, mockCollectionsSelector.Object, generator);
        }

        [Test]
        public void ClassIsAllowed()
        {
            alignmentClasses.Add(ClassName);
            var classNames = randomizer.GetAllPossibleResults(alignment);
            Assert.That(classNames, Contains.Item(ClassName));
        }

        [Test]
        public void ClassIsNotInAlignment()
        {
            var classNames = randomizer.GetAllPossibleResults(alignment);
            Assert.That(classNames, Is.All.Not.EqualTo(ClassName));
        }

        [Test]
        public void ClassIsInGroup()
        {
            alignmentClasses.Add(ClassName);
            groupClasses.Add(ClassName);
            var classNames = randomizer.GetAllPossibleResults(alignment);
            Assert.That(classNames, Is.All.Not.EqualTo(ClassName));
        }
    }
}