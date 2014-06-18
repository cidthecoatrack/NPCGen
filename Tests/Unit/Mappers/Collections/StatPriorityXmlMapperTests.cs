﻿using System;
using System.IO;
using System.Linq;
using Moq;
using NPCGen.Mappers;
using NPCGen.Mappers.Collections;
using NPCGen.Mappers.Interfaces;
using NPCGen.Tables.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Unit.Mappers
{
    [TestFixture]
    public class StatPriorityXmlMapperTests
    {
        private IStatPriorityMapper mapper;
        private Mock<IStreamLoader> mockStreamLoader;
        private const String tableName = "StatPriorityXmlMapperTests";
        private String filename;

        [SetUp]
        public void Setup()
        {
            filename = tableName + ".xml";
            MakeXmlFile();

            mockStreamLoader = new Mock<IStreamLoader>();
            mockStreamLoader.Setup(l => l.LoadFor(filename)).Returns(GetStream());

            mapper = new StatPriorityXmlMapper(mockStreamLoader.Object);
        }

        [Test]
        public void AppendXmlFileExtensionToTableName()
        {
            mapper.Map(tableName);
            mockStreamLoader.Verify(l => l.LoadFor(filename), Times.Once);
        }

        [Test]
        public void LoadXmlFromStream()
        {
            var objects = mapper.Map(tableName);

            Assert.That(objects.Count(), Is.EqualTo(1));
            Assert.That(objects.ContainsKey("class name"), Is.True);

            var firstElement = objects["class name"];
            Assert.That(firstElement.FirstPriority, Is.EqualTo("strength"));
            Assert.That(firstElement.SecondPriority, Is.EqualTo("wisdom"));
        }

        private Stream GetStream()
        {
            return new FileStream(filename, FileMode.Open);
        }

        private void MakeXmlFile()
        {
            var content = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><statPriorities><object><className>class name</className><first>strength</first><second>wisdom</second></object></statPriorities>";
            File.WriteAllText(filename, content);
        }
    }
}