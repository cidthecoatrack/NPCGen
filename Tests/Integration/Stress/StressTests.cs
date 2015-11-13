﻿using CharacterGen.Common.Alignments;
using CharacterGen.Common.CharacterClasses;
using CharacterGen.Generators;
using CharacterGen.Generators.Randomizers.Alignments;
using CharacterGen.Generators.Randomizers.CharacterClasses;
using CharacterGen.Generators.Randomizers.Races;
using CharacterGen.Generators.Verifiers;
using CharacterGen.Generators.Verifiers.Exceptions;
using CharacterGen.Tests.Integration.Common;
using Ninject;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace CharacterGen.Tests.Integration.Stress
{
    [TestFixture]
    [Stress]
    public abstract class StressTests : IntegrationTests
    {
        [Inject]
        public Stopwatch Stopwatch { get; set; }
        [Inject]
        public IAlignmentGenerator AlignmentGenerator { get; set; }
        [Inject]
        public IRandomizerVerifier RandomizerVerifier { get; set; }
        [Inject, Named(AlignmentRandomizerTypeConstants.Any)]
        public virtual IAlignmentRandomizer AlignmentRandomizer { get; set; }
        [Inject, Named(ClassNameRandomizerTypeConstants.Any)]
        public virtual IClassNameRandomizer ClassNameRandomizer { get; set; }
        [Inject, Named(LevelRandomizerTypeConstants.Any)]
        public ILevelRandomizer LevelRandomizer { get; set; }
        [Inject, Named(RaceRandomizerTypeConstants.BaseRace.AnyBase)]
        public virtual RaceRandomizer BaseRaceRandomizer { get; set; }
        [Inject, Named(RaceRandomizerTypeConstants.Metarace.AnyMeta)]
        public virtual RaceRandomizer MetaraceRandomizer { get; set; }
        [Inject]
        public ICharacterClassGenerator CharacterClassGenerator { get; set; }
        [Inject]
        public IRaceGenerator RaceGenerator { get; set; }

        private const Int32 ConfidentIterations = 1000000;
#if STRESS
        private const Int32 TimeLimitInSeconds = Int32.MaxValue;
#else
        private const Int32 TimeLimitInSeconds = 1;
#endif

        private Int32 iterations;

        [SetUp]
        public void StressSetup()
        {
            iterations = 0;
            Stopwatch.Start();
        }

        [TearDown]
        public void StressTearDown()
        {
            Stopwatch.Reset();
        }

        public abstract void Stress(String stressSubject);

        protected void Stress()
        {
            do MakeAssertions();
            while (TestShouldKeepRunning());
        }

        protected abstract void MakeAssertions();

        protected T Generate<T>(Func<T> generate, Func<T, Boolean> isValid)
        {
            T generatedObject;

            do generatedObject = generate();
            while (isValid(generatedObject) == false);

            return generatedObject;
        }

        protected T GenerateOrFail<T>(Func<T> generate, Func<T, Boolean> isValid)
        {
            T generatedObject;

            do generatedObject = generate();
            while (TestShouldKeepRunning() && isValid(generatedObject) == false);

            if (TestShouldKeepRunning() == false && isValid(generatedObject) == false)
                Assert.Fail("Stress test timed out.");

            return generatedObject;
        }

        private Boolean TestShouldKeepRunning()
        {
            iterations++;
            return Stopwatch.Elapsed.TotalSeconds < TimeLimitInSeconds && iterations < ConfidentIterations;
        }

        protected Alignment GetNewAlignment()
        {
            var compatible = RandomizerVerifier.VerifyCompatibility(AlignmentRandomizer, ClassNameRandomizer, LevelRandomizer, BaseRaceRandomizer, MetaraceRandomizer);

            if (compatible == false)
                throw new IncompatibleRandomizersException();

            var alignment = Generate(
                () => AlignmentGenerator.GenerateWith(AlignmentRandomizer),
                a => RandomizerVerifier.VerifyAlignmentCompatibility(a, ClassNameRandomizer, LevelRandomizer, BaseRaceRandomizer, MetaraceRandomizer));

            return alignment;
        }

        protected CharacterClass GetNewCharacterClass(Alignment alignment)
        {
            var characterClass = Generate(
                () => CharacterClassGenerator.GenerateWith(alignment, LevelRandomizer, ClassNameRandomizer),
                c => RandomizerVerifier.VerifyCharacterClassCompatibility(alignment, c, BaseRaceRandomizer, MetaraceRandomizer));

            return characterClass;
        }
    }
}