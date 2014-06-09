﻿using System;
using System.IO;
using System.Linq;
using Moq;
using NPCGen.Mappers;
using NPCGen.Mappers.Interfaces;
using NPCGen.Tables.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Unit.Mappers
{
    [TestFixture]
    public class PercentileXmlParserTests
    {
        private IPercentileXmlParser percentileXmlParser;
        private Mock<IStreamLoader> mockStreamLoader;
        private const String filename = "PercentileXmlParserTests.xml";

        [SetUp]
        public void Setup()
        {
            MakeXmlFile();

            mockStreamLoader = new Mock<IStreamLoader>();
            mockStreamLoader.Setup(l => l.LoadStream(filename)).Returns(() => GetStream());

            percentileXmlParser = new PercentileXmlParser(mockStreamLoader.Object);
        }

        [Test]
        public void LoadXmlFromStream()
        {
            var table = percentileXmlParser.Parse(filename);

            Assert.That(table[1], Is.EqualTo("one through five"));
            Assert.That(table[2], Is.EqualTo("one through five"));
            Assert.That(table[3], Is.EqualTo("one through five"));
            Assert.That(table[4], Is.EqualTo("one through five"));
            Assert.That(table[5], Is.EqualTo("one through five"));
            Assert.That(table[6], Is.EqualTo("six only"));
            Assert.That(table[7], Is.Empty);
            Assert.That(table.Count(), Is.EqualTo(7));
        }

        private Stream GetStream()
        {
            return new FileStream(filename, FileMode.Open);
        }

        private void MakeXmlFile()
        {
            var content = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                            <percentile>
                                <object>
                                    <lower>1</lower>
                                    <content>one through five</content>
                                    <upper>5</upper>
                                </object>
                                <object>
                                    <lower>6</lower>
                                    <content>six only</content>
                                    <upper>6</upper>
                                </object>
                                <object>
                                    <lower>7</lower>
                                    <content></content>
                                    <upper>7</upper>
                                </object>
                            </percentile>";
            File.WriteAllText(filename, content);
        }
    }
}