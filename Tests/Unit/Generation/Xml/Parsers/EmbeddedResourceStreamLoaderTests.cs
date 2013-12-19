﻿using NPCGen.Core.Generation.Xml.Parsers;
using NPCGen.Core.Generation.Xml.Parsers.Interfaces;
using NUnit.Framework;
using System.IO;

namespace NPCGen.Tests.Unit.Generation.Xml.Parsers
{
    [TestFixture]
    public class EmbeddedResourceStreamLoaderTests
    {
        private IStreamLoader streamLoader;

        [SetUp]
        public void Setup()
        {
            streamLoader = new EmbeddedResourceStreamLoader();
        }

        [Test]
        public void GetsFileIfItIsAnEmbeddeResource()
        {
            using (var stream = streamLoader.LoadStream("GoodCharacterClasses.xml"))
            {
                //no error was thrown, so the stream was successfully loaded
                Assert.Pass();
            }
        }

        [Test, ExpectedException(typeof(FileNotFoundException))]
        public void ThrowErrorIfFileIsNotEmbeddedResource()
        {
            using (var stream = streamLoader.LoadStream("NotAnActualFile.xml"))
            {
                //Shouldn't get here, should throw error
            }
        }
    }
}