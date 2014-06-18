﻿using System;
using System.Collections.Generic;
using Ninject;
using NPCGen.Common.CharacterClasses;
using NPCGen.Generators.Interfaces.Randomizers.CharacterClasses;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Stress.Randomizers.CharacterClasses.ClassNames
{
    [TestFixture]
    public class StealthClassNameRandomizerTests : ClassNameRandomizerTests
    {
        [Inject, Named(ClassNameRandomizerTypeConstants.Stealth)]
        public override IClassNameRandomizer ClassNameRandomizer { get; set; }

        protected override IEnumerable<String> particularClassNames
        {
            get
            {
                return new[]
                {
                    CharacterClassConstants.Bard,
                    CharacterClassConstants.Ranger,
                    CharacterClassConstants.Rogue
                };
            }
        }
    }
}