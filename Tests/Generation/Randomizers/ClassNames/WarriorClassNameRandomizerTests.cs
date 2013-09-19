﻿using System;
using Moq;
using NPCGen.Core.Data.Alignments;
using NPCGen.Core.Data.CharacterClasses;
using NPCGen.Core.Generation.Providers.Interfaces;
using NPCGen.Core.Generation.Randomizers.ClassNames;
using NUnit.Framework;

namespace NPCGen.Tests.Generation.Randomizers.ClassNames
{
    [TestFixture]
    public class WarriorClassNameRandomizerTests
    {
        private IClassNameRandomizer classNameRandomizer;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Alignment alignment;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            classNameRandomizer = new WarriorClassNameRandomizer(mockPercentileResultProvider.Object);

            alignment = new Alignment();
        }

        [Test]
        public void FighterAlwaysAllowed()
        {
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(CharacterClassConstants.Fighter)
                .Returns(CharacterClassConstants.Ranger);
            var className = classNameRandomizer.Randomize(alignment);
            Assert.That(className, Is.EqualTo(CharacterClassConstants.Fighter));
        }

        [Test]
        public void ClericNeverAllowed()
        {
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(CharacterClassConstants.Cleric)
                .Returns(CharacterClassConstants.Fighter);
            var className = classNameRandomizer.Randomize(alignment);
            Assert.That(className, Is.EqualTo(CharacterClassConstants.Fighter));
        }

        [Test]
        public void RangerAlwaysAllowed()
        {
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(CharacterClassConstants.Ranger)
                .Returns(CharacterClassConstants.Fighter);
            var className = classNameRandomizer.Randomize(alignment);
            Assert.That(className, Is.EqualTo(CharacterClassConstants.Ranger));
        }

        [Test]
        public void SorcererNeverAllowed()
        {
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(CharacterClassConstants.Sorcerer)
                .Returns(CharacterClassConstants.Fighter);
            var className = classNameRandomizer.Randomize(alignment);
            Assert.That(className, Is.EqualTo(CharacterClassConstants.Fighter));
        }

        [Test]
        public void RogueNeverAllowed()
        {
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(CharacterClassConstants.Rogue)
                .Returns(CharacterClassConstants.Fighter);
            var className = classNameRandomizer.Randomize(alignment);
            Assert.That(className, Is.EqualTo(CharacterClassConstants.Fighter));
        }

        [Test]
        public void WizardNeverAllowed()
        {
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(CharacterClassConstants.Wizard)
                .Returns(CharacterClassConstants.Fighter);
            var className = classNameRandomizer.Randomize(alignment);
            Assert.That(className, Is.EqualTo(CharacterClassConstants.Fighter));
        }

        [Test]
        public void BarbarianNotAllowedIfAlignmentIsLawful()
        {
            alignment.Lawfulness = AlignmentConstants.Lawful;
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(CharacterClassConstants.Barbarian)
                .Returns(CharacterClassConstants.Fighter);
            var className = classNameRandomizer.Randomize(alignment);
            Assert.That(className, Is.EqualTo(CharacterClassConstants.Fighter));
        }

        [Test]
        public void BarbarianAllowedIfAlignmentIsNotLawful()
        {
            alignment.Lawfulness = AlignmentConstants.Neutral;
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(CharacterClassConstants.Barbarian)
                .Returns(CharacterClassConstants.Fighter);
            var className = classNameRandomizer.Randomize(alignment);
            Assert.That(className, Is.EqualTo(CharacterClassConstants.Barbarian));
        }

        [Test]
        public void BardNeverAllowed()
        {
            alignment.Lawfulness = AlignmentConstants.Chaotic;
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(CharacterClassConstants.Bard)
                .Returns(CharacterClassConstants.Fighter);
            var className = classNameRandomizer.Randomize(alignment);
            Assert.That(className, Is.EqualTo(CharacterClassConstants.Fighter));
        }

        [Test]
        public void DruidNeverAllowed()
        {
            alignment.Lawfulness = AlignmentConstants.Neutral;
            alignment.Goodness = AlignmentConstants.Good;
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(CharacterClassConstants.Druid)
                .Returns(CharacterClassConstants.Fighter);
            var className = classNameRandomizer.Randomize(alignment);
            Assert.That(className, Is.EqualTo(CharacterClassConstants.Fighter));
        }

        [Test]
        public void MonkNotAllowedIfAlignmentIsNotLawful()
        {
            alignment.Lawfulness = AlignmentConstants.Neutral;
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(CharacterClassConstants.Monk)
                .Returns(CharacterClassConstants.Fighter);
            var className = classNameRandomizer.Randomize(alignment);
            Assert.That(className, Is.EqualTo(CharacterClassConstants.Fighter));
        }

        [Test]
        public void MonkAllowedIfAlignmentIsLawful()
        {
            alignment.Lawfulness = AlignmentConstants.Lawful;
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(CharacterClassConstants.Monk)
                .Returns(CharacterClassConstants.Fighter);
            var className = classNameRandomizer.Randomize(alignment);
            Assert.That(className, Is.EqualTo(CharacterClassConstants.Monk));
        }

        [Test]
        public void PaladinNotAllowedIfAlignmentIsNotLawful()
        {
            alignment.Lawfulness = AlignmentConstants.Neutral;
            alignment.Goodness = AlignmentConstants.Good;
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(CharacterClassConstants.Paladin)
                .Returns(CharacterClassConstants.Fighter);
            var className = classNameRandomizer.Randomize(alignment);
            Assert.That(className, Is.EqualTo(CharacterClassConstants.Fighter));
        }

        [Test]
        public void PaladinNotAllowedIfAlignmentIsNotGood()
        {
            alignment.Goodness = AlignmentConstants.Neutral;
            alignment.Lawfulness = AlignmentConstants.Lawful;
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(CharacterClassConstants.Paladin)
                .Returns(CharacterClassConstants.Fighter);
            var className = classNameRandomizer.Randomize(alignment);
            Assert.That(className, Is.EqualTo(CharacterClassConstants.Fighter));
        }

        [Test]
        public void PaladinAllowedIfAlignmentIsLawfulGood()
        {
            alignment.Goodness = AlignmentConstants.Good;
            alignment.Lawfulness = AlignmentConstants.Lawful;
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(CharacterClassConstants.Paladin)
                .Returns(CharacterClassConstants.Fighter);
            var className = classNameRandomizer.Randomize(alignment);
            Assert.That(className, Is.EqualTo(CharacterClassConstants.Paladin));
        }
    }
}