﻿using CharacterGen.Mappers;
using CharacterGen.Mappers.Domain.Percentiles;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CharacterGen.Tests.Unit.Mappers.Percentiles
{
    [TestFixture]
    public class PercentileMapperCachingProxyTests
    {
        private PercentileMapper proxy;
        private Mock<PercentileMapper> mockInnerMapper;
        private Dictionary<Int32, String> table;

        [SetUp]
        public void Setup()
        {
            table = new Dictionary<Int32, String>();
            mockInnerMapper = new Mock<PercentileMapper>();
            mockInnerMapper.Setup(m => m.Map("table name")).Returns(table);

            proxy = new PercentileMapperCachingProxy(mockInnerMapper.Object);
        }

        [Test]
        public void ReturnTableFromInnerMapper()
        {
            var result = proxy.Map("table name");
            Assert.That(result, Is.EqualTo(table));
        }

        [Test]
        public void CacheTable()
        {
            proxy.Map("table name");
            var result = proxy.Map("table name");

            Assert.That(result, Is.EqualTo(table));
            mockInnerMapper.Verify(p => p.Map(It.IsAny<String>()), Times.Once);
        }
    }
}