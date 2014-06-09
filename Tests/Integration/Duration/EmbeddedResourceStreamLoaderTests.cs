﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Ninject;
using NPCGen.Tables.Interfaces;
using NPCGen.Tests.Integration.Common;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables
{
    [TestFixture]
    public class EmbeddedResourceStreamLoaderTests : IntegrationTest
    {
        [Inject]
        public IStreamLoader StreamLoader { get; set; }

        [Test]
        public void GetsFileIfItIsAnEmbeddedResource()
        {
            var table = LoadStreamOf("Level1Coins.xml");

            for (var i = 1; i <= 14; i++)
                Assert.That(table[i], Is.Empty);

            for (var i = 15; i <= 29; i++)
                Assert.That(table[i], Is.EqualTo("Copper,1d6*1000"));

            for (var i = 30; i <= 52; i++)
                Assert.That(table[i], Is.EqualTo("Silver,1d8*100"));

            for (var i = 53; i <= 95; i++)
                Assert.That(table[i], Is.EqualTo("Gold,2d8*10"));

            for (var i = 96; i <= 100; i++)
                Assert.That(table[i], Is.EqualTo("Platinum,1d4*10"));
        }

        private Dictionary<Int32, String> LoadStreamOf(String filename)
        {
            var table = new Dictionary<Int32, String>();
            var xmlDocument = new XmlDocument();

            using (var stream = StreamLoader.LoadStream(filename))
                xmlDocument.Load(stream);

            var objects = xmlDocument.DocumentElement.ChildNodes;
            foreach (XmlNode node in objects)
            {
                var lower = Convert.ToInt32(node.SelectSingleNode("lower").InnerText);
                var upper = Convert.ToInt32(node.SelectSingleNode("upper").InnerText);
                var content = node.SelectSingleNode("content").InnerText;

                for (var i = lower; i <= upper; i++)
                    table.Add(i, content);
            }

            return table;
        }

        [Test]
        public void ThrowErrorIfFileIsNotFormattedCorrectly()
        {
            Assert.That(() => StreamLoader.LoadStream("invalid filename"), Throws.ArgumentException.With.Message.EqualTo("\"invalid filename\" is not a valid file"));
        }

        [Test]
        public void ThrowErrorIfFileIsNotAnEmbeddedResource()
        {
            Assert.That(() => StreamLoader.LoadStream("invalid filename.xml"), Throws.InstanceOf<FileNotFoundException>().With.Message.EqualTo("invalid filename.xml"));
        }

        [Test]
        public void MatchWholeFileName()
        {
            Assert.That(() => StreamLoader.LoadStream("Coins.xml"), Throws.InstanceOf<FileNotFoundException>().With.Message.EqualTo("Coins.xml"));
        }

        [Test]
        public void DifferentiateAgainstDifferentFilesWithSimilarFilenameEndings()
        {
            var table = LoadStreamOf("SpellTypes.xml");

            for (var i = 1; i <= 70; i++)
                Assert.That(table[i], Is.EqualTo("Arcane"));

            for (var i = 71; i <= 100; i++)
                Assert.That(table[i], Is.EqualTo("Divine"));

            table = LoadStreamOf("CastersShieldSpellTypes.xml");

            for (var i = 1; i <= 80; i++)
                Assert.That(table[i], Is.EqualTo("Divine"));

            for (var i = 81; i <= 100; i++)
                Assert.That(table[i], Is.EqualTo("Arcane"));
        }
    }
}