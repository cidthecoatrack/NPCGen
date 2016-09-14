﻿using CharacterGen.Domain.Selectors.Collections;
using CharacterGen.Domain.Tables;
using Moq;
using NUnit.Framework;

namespace CharacterGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class SkillSelectorTests
    {
        private ISkillSelector skillSelector;
        private Mock<ICollectionsSelector> mockInnerSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<ICollectionsSelector>();
            skillSelector = new SkillSelector(mockInnerSelector.Object);
        }

        [Test]
        public void GetCollectionFromInnerCollectionSelector()
        {
            var skillData = new[] { "base stat" };

            mockInnerSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.SkillData, "skill")).Returns(skillData);

            var selection = skillSelector.SelectFor("skill");
            Assert.That(selection.BaseStatName, Is.EqualTo("base stat"));
        }
    }
}