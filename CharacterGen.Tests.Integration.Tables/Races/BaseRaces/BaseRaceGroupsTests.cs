﻿using CharacterGen.Alignments;
using CharacterGen.Domain.Tables;
using CharacterGen.Races;
using NUnit.Framework;
using System.Linq;

namespace CharacterGen.Tests.Integration.Tables.Races.BaseRaces
{
    [TestFixture]
    public class BaseRaceGroupsTests : CollectionTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Set.Collection.BaseRaceGroups; }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = new[]
            {
                GroupConstants.All,
                GroupConstants.HasWings,
                GroupConstants.Monsters,
                GroupConstants.Standard,
                RaceConstants.Sizes.Colossal,
                RaceConstants.Sizes.Gargantuan,
                RaceConstants.Sizes.Huge,
                RaceConstants.Sizes.Large,
                RaceConstants.Sizes.Medium,
                RaceConstants.Sizes.Small,
                RaceConstants.Sizes.Tiny,
                AlignmentConstants.ChaoticEvil,
                AlignmentConstants.ChaoticGood,
                AlignmentConstants.ChaoticNeutral,
                AlignmentConstants.LawfulEvil,
                AlignmentConstants.LawfulGood,
                AlignmentConstants.LawfulNeutral,
                AlignmentConstants.NeutralEvil,
                AlignmentConstants.NeutralGood,
                AlignmentConstants.TrueNeutral,
            };

            AssertCollectionNames(names);
        }

        [TestCase(GroupConstants.Standard,
            RaceConstants.BaseRaces.HalfElf,
            RaceConstants.BaseRaces.HalfOrc,
            RaceConstants.BaseRaces.HighElf,
            RaceConstants.BaseRaces.HillDwarf,
            RaceConstants.BaseRaces.Human,
            RaceConstants.BaseRaces.LightfootHalfling,
            RaceConstants.BaseRaces.RockGnome)]
        [TestCase(RaceConstants.Sizes.Colossal)]
        [TestCase(RaceConstants.Sizes.Gargantuan)]
        [TestCase(RaceConstants.Sizes.Huge,
            RaceConstants.BaseRaces.CloudGiant,
            RaceConstants.BaseRaces.StormGiant)]
        [TestCase(RaceConstants.Sizes.Large,
            RaceConstants.BaseRaces.BlueSlaad,
            RaceConstants.BaseRaces.Centaur,
            RaceConstants.BaseRaces.FireGiant,
            RaceConstants.BaseRaces.FrostGiant,
            RaceConstants.BaseRaces.GreenSlaad,
            RaceConstants.BaseRaces.HillGiant,
            RaceConstants.BaseRaces.Minotaur,
            RaceConstants.BaseRaces.Ogre,
            RaceConstants.BaseRaces.OgreMage,
            RaceConstants.BaseRaces.RedSlaad,
            RaceConstants.BaseRaces.Scorpionfolk,
            RaceConstants.BaseRaces.StoneGiant,
            RaceConstants.BaseRaces.Troll,
            RaceConstants.BaseRaces.YuanTiAbomination)]
        [TestCase(RaceConstants.Sizes.Medium,
            RaceConstants.BaseRaces.Aasimar,
            RaceConstants.BaseRaces.Azer,
            RaceConstants.BaseRaces.Bugbear,
            RaceConstants.BaseRaces.DeathSlaad,
            RaceConstants.BaseRaces.DeepDwarf,
            RaceConstants.BaseRaces.Doppelganger,
            RaceConstants.BaseRaces.Drow,
            RaceConstants.BaseRaces.DuergarDwarf,
            RaceConstants.BaseRaces.Gargoyle,
            RaceConstants.BaseRaces.Gnoll,
            RaceConstants.BaseRaces.GrayElf,
            RaceConstants.BaseRaces.GraySlaad,
            RaceConstants.BaseRaces.Grimlock,
            RaceConstants.BaseRaces.HalfElf,
            RaceConstants.BaseRaces.HalfOrc,
            RaceConstants.BaseRaces.Harpy,
            RaceConstants.BaseRaces.HighElf,
            RaceConstants.BaseRaces.HillDwarf,
            RaceConstants.BaseRaces.Hobgoblin,
            RaceConstants.BaseRaces.HoundArchon,
            RaceConstants.BaseRaces.Human,
            RaceConstants.BaseRaces.Janni,
            RaceConstants.BaseRaces.Lizardfolk,
            RaceConstants.BaseRaces.MindFlayer,
            RaceConstants.BaseRaces.MountainDwarf,
            RaceConstants.BaseRaces.Orc,
            RaceConstants.BaseRaces.Rakshasa,
            RaceConstants.BaseRaces.Satyr,
            RaceConstants.BaseRaces.Tiefling,
            RaceConstants.BaseRaces.Troglodyte,
            RaceConstants.BaseRaces.WildElf,
            RaceConstants.BaseRaces.WoodElf,
            RaceConstants.BaseRaces.YuanTiHalfblood,
            RaceConstants.BaseRaces.YuanTiPureblood)]
        [TestCase(RaceConstants.Sizes.Small,
            RaceConstants.BaseRaces.DeepHalfling,
            RaceConstants.BaseRaces.Derro,
            RaceConstants.BaseRaces.ForestGnome,
            RaceConstants.BaseRaces.Goblin,
            RaceConstants.BaseRaces.Kobold,
            RaceConstants.BaseRaces.LightfootHalfling,
            RaceConstants.BaseRaces.Pixie,
            RaceConstants.BaseRaces.RockGnome,
            RaceConstants.BaseRaces.Svirfneblin,
            RaceConstants.BaseRaces.TallfellowHalfling)]
        [TestCase(RaceConstants.Sizes.Tiny)]
        [TestCase(GroupConstants.HasWings,
            RaceConstants.BaseRaces.Gargoyle,
            RaceConstants.BaseRaces.Harpy,
            RaceConstants.BaseRaces.Pixie)]
        public void BaseRaceGroup(string name, params string[] collection)
        {
            base.DistinctCollection(name, collection);
        }

        [Test]
        public void MonsterBaseRaces()
        {
            var baseRaces = new[]
            {
                RaceConstants.BaseRaces.Azer,
                RaceConstants.BaseRaces.BlueSlaad,
                RaceConstants.BaseRaces.Bugbear,
                RaceConstants.BaseRaces.Centaur,
                RaceConstants.BaseRaces.CloudGiant,
                RaceConstants.BaseRaces.DeathSlaad,
                RaceConstants.BaseRaces.Derro,
                RaceConstants.BaseRaces.Doppelganger,
                RaceConstants.BaseRaces.FireGiant,
                RaceConstants.BaseRaces.FrostGiant,
                RaceConstants.BaseRaces.Gargoyle,
                RaceConstants.BaseRaces.Gnoll,
                RaceConstants.BaseRaces.Goblin,
                RaceConstants.BaseRaces.GraySlaad,
                RaceConstants.BaseRaces.GreenSlaad,
                RaceConstants.BaseRaces.Grimlock,
                RaceConstants.BaseRaces.Harpy,
                RaceConstants.BaseRaces.HillGiant,
                RaceConstants.BaseRaces.Hobgoblin,
                RaceConstants.BaseRaces.HoundArchon,
                RaceConstants.BaseRaces.Janni,
                RaceConstants.BaseRaces.Kobold,
                RaceConstants.BaseRaces.Lizardfolk,
                RaceConstants.BaseRaces.MindFlayer,
                RaceConstants.BaseRaces.Minotaur,
                RaceConstants.BaseRaces.Ogre,
                RaceConstants.BaseRaces.OgreMage,
                RaceConstants.BaseRaces.Orc,
                RaceConstants.BaseRaces.Pixie,
                RaceConstants.BaseRaces.Rakshasa,
                RaceConstants.BaseRaces.RedSlaad,
                RaceConstants.BaseRaces.Satyr,
                RaceConstants.BaseRaces.Scorpionfolk,
                RaceConstants.BaseRaces.StoneGiant,
                RaceConstants.BaseRaces.StormGiant,
                RaceConstants.BaseRaces.Troglodyte,
                RaceConstants.BaseRaces.Troll,
                RaceConstants.BaseRaces.YuanTiAbomination,
                RaceConstants.BaseRaces.YuanTiHalfblood,
                RaceConstants.BaseRaces.YuanTiPureblood,
            };

            base.DistinctCollection(GroupConstants.Monsters, baseRaces);
        }

        [Test]
        public void AllBaseRaces()
        {
            var baseRaces = new[]
            {
                RaceConstants.BaseRaces.Aasimar,
                RaceConstants.BaseRaces.Azer,
                RaceConstants.BaseRaces.BlueSlaad,
                RaceConstants.BaseRaces.Bugbear,
                RaceConstants.BaseRaces.Centaur,
                RaceConstants.BaseRaces.CloudGiant,
                RaceConstants.BaseRaces.DeathSlaad,
                RaceConstants.BaseRaces.DeepDwarf,
                RaceConstants.BaseRaces.DeepHalfling,
                RaceConstants.BaseRaces.Derro,
                RaceConstants.BaseRaces.Doppelganger,
                RaceConstants.BaseRaces.Drow,
                RaceConstants.BaseRaces.DuergarDwarf,
                RaceConstants.BaseRaces.FireGiant,
                RaceConstants.BaseRaces.ForestGnome,
                RaceConstants.BaseRaces.FrostGiant,
                RaceConstants.BaseRaces.Gargoyle,
                RaceConstants.BaseRaces.Gnoll,
                RaceConstants.BaseRaces.Goblin,
                RaceConstants.BaseRaces.GrayElf,
                RaceConstants.BaseRaces.GraySlaad,
                RaceConstants.BaseRaces.GreenSlaad,
                RaceConstants.BaseRaces.Grimlock,
                RaceConstants.BaseRaces.HalfElf,
                RaceConstants.BaseRaces.HalfOrc,
                RaceConstants.BaseRaces.Harpy,
                RaceConstants.BaseRaces.HighElf,
                RaceConstants.BaseRaces.HillDwarf,
                RaceConstants.BaseRaces.HillGiant,
                RaceConstants.BaseRaces.Hobgoblin,
                RaceConstants.BaseRaces.HoundArchon,
                RaceConstants.BaseRaces.Human,
                RaceConstants.BaseRaces.Janni,
                RaceConstants.BaseRaces.Kobold,
                RaceConstants.BaseRaces.LightfootHalfling,
                RaceConstants.BaseRaces.Lizardfolk,
                RaceConstants.BaseRaces.MindFlayer,
                RaceConstants.BaseRaces.Minotaur,
                RaceConstants.BaseRaces.MountainDwarf,
                RaceConstants.BaseRaces.Ogre,
                RaceConstants.BaseRaces.OgreMage,
                RaceConstants.BaseRaces.Orc,
                RaceConstants.BaseRaces.Pixie,
                RaceConstants.BaseRaces.Rakshasa,
                RaceConstants.BaseRaces.RedSlaad,
                RaceConstants.BaseRaces.RockGnome,
                RaceConstants.BaseRaces.Satyr,
                RaceConstants.BaseRaces.Scorpionfolk,
                RaceConstants.BaseRaces.StoneGiant,
                RaceConstants.BaseRaces.StormGiant,
                RaceConstants.BaseRaces.Svirfneblin,
                RaceConstants.BaseRaces.TallfellowHalfling,
                RaceConstants.BaseRaces.Tiefling,
                RaceConstants.BaseRaces.Troglodyte,
                RaceConstants.BaseRaces.Troll,
                RaceConstants.BaseRaces.WildElf,
                RaceConstants.BaseRaces.WoodElf,
                RaceConstants.BaseRaces.YuanTiAbomination,
                RaceConstants.BaseRaces.YuanTiHalfblood,
                RaceConstants.BaseRaces.YuanTiPureblood,
            };

            base.DistinctCollection(GroupConstants.All, baseRaces);
        }

        [Test]
        public void LawfulGoodBaseRaces()
        {
            var baseRaces = new[]
            {
                RaceConstants.BaseRaces.Aasimar,
                RaceConstants.BaseRaces.Centaur,
                RaceConstants.BaseRaces.CloudGiant,
                RaceConstants.BaseRaces.DeepDwarf,
                RaceConstants.BaseRaces.DuergarDwarf,
                RaceConstants.BaseRaces.FireGiant,
                RaceConstants.BaseRaces.ForestGnome,
                RaceConstants.BaseRaces.HalfElf,
                RaceConstants.BaseRaces.HalfOrc,
                RaceConstants.BaseRaces.HillDwarf,
                RaceConstants.BaseRaces.HoundArchon,
                RaceConstants.BaseRaces.Human,
                RaceConstants.BaseRaces.MountainDwarf,
                RaceConstants.BaseRaces.RockGnome,
                RaceConstants.BaseRaces.StormGiant,
            };

            base.DistinctCollection(AlignmentConstants.LawfulGood, baseRaces);
        }

        [Test]
        public void NeutralGoodBaseRaces()
        {
            var baseRaces = new[]
            {
                RaceConstants.BaseRaces.Aasimar,
                RaceConstants.BaseRaces.Centaur,
                RaceConstants.BaseRaces.CloudGiant,
                RaceConstants.BaseRaces.DeepDwarf,
                RaceConstants.BaseRaces.DeepHalfling,
                RaceConstants.BaseRaces.Doppelganger,
                RaceConstants.BaseRaces.ForestGnome,
                RaceConstants.BaseRaces.GrayElf,
                RaceConstants.BaseRaces.Grimlock,
                RaceConstants.BaseRaces.HalfElf,
                RaceConstants.BaseRaces.HalfOrc,
                RaceConstants.BaseRaces.HighElf,
                RaceConstants.BaseRaces.HillDwarf,
                RaceConstants.BaseRaces.Human,
                RaceConstants.BaseRaces.Janni,
                RaceConstants.BaseRaces.LightfootHalfling,
                RaceConstants.BaseRaces.Lizardfolk,
                RaceConstants.BaseRaces.MountainDwarf,
                RaceConstants.BaseRaces.Pixie,
                RaceConstants.BaseRaces.RockGnome,
                RaceConstants.BaseRaces.StoneGiant,
                RaceConstants.BaseRaces.StormGiant,
                RaceConstants.BaseRaces.Svirfneblin,
                RaceConstants.BaseRaces.TallfellowHalfling,
                RaceConstants.BaseRaces.WildElf,
                RaceConstants.BaseRaces.WoodElf,
            };

            base.DistinctCollection(AlignmentConstants.NeutralGood, baseRaces);
        }

        [Test]
        public void ChaoticGoodBaseRaces()
        {
            var baseRaces = new[]
            {
                RaceConstants.BaseRaces.Aasimar,
                RaceConstants.BaseRaces.BlueSlaad,
                RaceConstants.BaseRaces.Centaur,
                RaceConstants.BaseRaces.CloudGiant,
                RaceConstants.BaseRaces.ForestGnome,
                RaceConstants.BaseRaces.FrostGiant,
                RaceConstants.BaseRaces.GrayElf,
                RaceConstants.BaseRaces.GraySlaad,
                RaceConstants.BaseRaces.GreenSlaad,
                RaceConstants.BaseRaces.HalfElf,
                RaceConstants.BaseRaces.HalfOrc,
                RaceConstants.BaseRaces.HighElf,
                RaceConstants.BaseRaces.HillDwarf,
                RaceConstants.BaseRaces.HillGiant,
                RaceConstants.BaseRaces.Human,
                RaceConstants.BaseRaces.MountainDwarf,
                RaceConstants.BaseRaces.Orc,
                RaceConstants.BaseRaces.RedSlaad,
                RaceConstants.BaseRaces.RockGnome,
                RaceConstants.BaseRaces.Satyr,
                RaceConstants.BaseRaces.StormGiant,
                RaceConstants.BaseRaces.WildElf,
            };

            base.DistinctCollection(AlignmentConstants.ChaoticGood, baseRaces);
        }

        [Test]
        public void LawfulNeutralBaseRaces()
        {
            var baseRaces = new[]
            {
                RaceConstants.BaseRaces.Aasimar,
                RaceConstants.BaseRaces.Azer,
                RaceConstants.BaseRaces.DeepDwarf,
                RaceConstants.BaseRaces.DeepHalfling,
                RaceConstants.BaseRaces.Doppelganger,
                RaceConstants.BaseRaces.DuergarDwarf,
                RaceConstants.BaseRaces.FireGiant,
                RaceConstants.BaseRaces.HalfElf,
                RaceConstants.BaseRaces.HalfOrc,
                RaceConstants.BaseRaces.HillDwarf,
                RaceConstants.BaseRaces.Hobgoblin,
                RaceConstants.BaseRaces.Human,
                RaceConstants.BaseRaces.Janni,
                RaceConstants.BaseRaces.Kobold,
                RaceConstants.BaseRaces.LightfootHalfling,
                RaceConstants.BaseRaces.Lizardfolk,
                RaceConstants.BaseRaces.MindFlayer,
                RaceConstants.BaseRaces.MountainDwarf,
                RaceConstants.BaseRaces.OgreMage,
                RaceConstants.BaseRaces.Scorpionfolk,
                RaceConstants.BaseRaces.StoneGiant,
                RaceConstants.BaseRaces.Svirfneblin,
                RaceConstants.BaseRaces.TallfellowHalfling,
                RaceConstants.BaseRaces.Tiefling,
            };

            base.DistinctCollection(AlignmentConstants.LawfulNeutral, baseRaces);
        }

        [Test]
        public void TrueNeutralBaseRaces()
        {
            var baseRaces = new[]
            {
                RaceConstants.BaseRaces.Aasimar,
                RaceConstants.BaseRaces.BlueSlaad,
                RaceConstants.BaseRaces.Centaur,
                RaceConstants.BaseRaces.CloudGiant,
                RaceConstants.BaseRaces.DeepDwarf,
                RaceConstants.BaseRaces.DeepHalfling,
                RaceConstants.BaseRaces.Doppelganger,
                RaceConstants.BaseRaces.Drow,
                RaceConstants.BaseRaces.ForestGnome,
                RaceConstants.BaseRaces.Goblin,
                RaceConstants.BaseRaces.GraySlaad,
                RaceConstants.BaseRaces.GreenSlaad,
                RaceConstants.BaseRaces.Grimlock,
                RaceConstants.BaseRaces.HalfElf,
                RaceConstants.BaseRaces.HalfOrc,
                RaceConstants.BaseRaces.Human,
                RaceConstants.BaseRaces.Janni,
                RaceConstants.BaseRaces.LightfootHalfling,
                RaceConstants.BaseRaces.Lizardfolk,
                RaceConstants.BaseRaces.RedSlaad,
                RaceConstants.BaseRaces.RockGnome,
                RaceConstants.BaseRaces.Satyr,
                RaceConstants.BaseRaces.StoneGiant,
                RaceConstants.BaseRaces.Svirfneblin,
                RaceConstants.BaseRaces.TallfellowHalfling,
                RaceConstants.BaseRaces.Tiefling,
                RaceConstants.BaseRaces.WoodElf,
            };

            base.DistinctCollection(AlignmentConstants.TrueNeutral, baseRaces);
        }

        [Test]
        public void ChaoticNeutralBaseRaces()
        {
            var baseRaces = new[]
            {
                RaceConstants.BaseRaces.Aasimar,
                RaceConstants.BaseRaces.BlueSlaad,
                RaceConstants.BaseRaces.Bugbear,
                RaceConstants.BaseRaces.DeathSlaad,
                RaceConstants.BaseRaces.DeepDwarf,
                RaceConstants.BaseRaces.DeepHalfling,
                RaceConstants.BaseRaces.Derro,
                RaceConstants.BaseRaces.Doppelganger,
                RaceConstants.BaseRaces.FrostGiant,
                RaceConstants.BaseRaces.Gargoyle,
                RaceConstants.BaseRaces.Gnoll,
                RaceConstants.BaseRaces.GrayElf,
                RaceConstants.BaseRaces.GraySlaad,
                RaceConstants.BaseRaces.GreenSlaad,
                RaceConstants.BaseRaces.HalfElf,
                RaceConstants.BaseRaces.HalfOrc,
                RaceConstants.BaseRaces.Harpy,
                RaceConstants.BaseRaces.HighElf,
                RaceConstants.BaseRaces.HillGiant,
                RaceConstants.BaseRaces.Human,
                RaceConstants.BaseRaces.Janni,
                RaceConstants.BaseRaces.LightfootHalfling,
                RaceConstants.BaseRaces.Lizardfolk,
                RaceConstants.BaseRaces.Minotaur,
                RaceConstants.BaseRaces.Ogre,
                RaceConstants.BaseRaces.Orc,
                RaceConstants.BaseRaces.RedSlaad,
                RaceConstants.BaseRaces.Satyr,
                RaceConstants.BaseRaces.StoneGiant,
                RaceConstants.BaseRaces.StormGiant,
                RaceConstants.BaseRaces.Svirfneblin,
                RaceConstants.BaseRaces.TallfellowHalfling,
                RaceConstants.BaseRaces.Tiefling,
                RaceConstants.BaseRaces.Troglodyte,
                RaceConstants.BaseRaces.Troll,
                RaceConstants.BaseRaces.WildElf,
                RaceConstants.BaseRaces.WoodElf,
                RaceConstants.BaseRaces.YuanTiAbomination,
                RaceConstants.BaseRaces.YuanTiHalfblood,
                RaceConstants.BaseRaces.YuanTiPureblood,
            };

            base.DistinctCollection(AlignmentConstants.ChaoticNeutral, baseRaces);
        }

        [Test]
        public void LawfulEvilBaseRaces()
        {
            var baseRaces = new[]
            {
                RaceConstants.BaseRaces.CloudGiant,
                RaceConstants.BaseRaces.DeepDwarf,
                RaceConstants.BaseRaces.Drow,
                RaceConstants.BaseRaces.DuergarDwarf,
                RaceConstants.BaseRaces.FireGiant,
                RaceConstants.BaseRaces.FrostGiant,
                RaceConstants.BaseRaces.Goblin,
                RaceConstants.BaseRaces.Grimlock,
                RaceConstants.BaseRaces.HalfElf,
                RaceConstants.BaseRaces.HalfOrc,
                RaceConstants.BaseRaces.HillDwarf,
                RaceConstants.BaseRaces.HillGiant,
                RaceConstants.BaseRaces.Hobgoblin,
                RaceConstants.BaseRaces.Human,
                RaceConstants.BaseRaces.Kobold,
                RaceConstants.BaseRaces.MindFlayer,
                RaceConstants.BaseRaces.MountainDwarf,
                RaceConstants.BaseRaces.OgreMage,
                RaceConstants.BaseRaces.Orc,
                RaceConstants.BaseRaces.Rakshasa,
                RaceConstants.BaseRaces.Scorpionfolk,
                RaceConstants.BaseRaces.Tiefling,
            };

            base.DistinctCollection(AlignmentConstants.LawfulEvil, baseRaces);
        }

        [Test]
        public void NeutralEvilBaseRaces()
        {
            var baseRaces = new[]
            {
                RaceConstants.BaseRaces.Bugbear,
                RaceConstants.BaseRaces.CloudGiant,
                RaceConstants.BaseRaces.DeathSlaad,
                RaceConstants.BaseRaces.DeepDwarf,
                RaceConstants.BaseRaces.DeepHalfling,
                RaceConstants.BaseRaces.Derro,
                RaceConstants.BaseRaces.Doppelganger,
                RaceConstants.BaseRaces.Drow,
                RaceConstants.BaseRaces.DuergarDwarf,
                RaceConstants.BaseRaces.FireGiant,
                RaceConstants.BaseRaces.FrostGiant,
                RaceConstants.BaseRaces.Gargoyle,
                RaceConstants.BaseRaces.Gnoll,
                RaceConstants.BaseRaces.Goblin,
                RaceConstants.BaseRaces.Grimlock,
                RaceConstants.BaseRaces.HalfElf,
                RaceConstants.BaseRaces.HalfOrc,
                RaceConstants.BaseRaces.Harpy,
                RaceConstants.BaseRaces.HillGiant,
                RaceConstants.BaseRaces.Hobgoblin,
                RaceConstants.BaseRaces.Human,
                RaceConstants.BaseRaces.Janni,
                RaceConstants.BaseRaces.Kobold,
                RaceConstants.BaseRaces.LightfootHalfling,
                RaceConstants.BaseRaces.Lizardfolk,
                RaceConstants.BaseRaces.MindFlayer,
                RaceConstants.BaseRaces.Minotaur,
                RaceConstants.BaseRaces.Ogre,
                RaceConstants.BaseRaces.OgreMage,
                RaceConstants.BaseRaces.Orc,
                RaceConstants.BaseRaces.Scorpionfolk,
                RaceConstants.BaseRaces.StoneGiant,
                RaceConstants.BaseRaces.Svirfneblin,
                RaceConstants.BaseRaces.TallfellowHalfling,
                RaceConstants.BaseRaces.Tiefling,
                RaceConstants.BaseRaces.Troglodyte,
                RaceConstants.BaseRaces.Troll,
                RaceConstants.BaseRaces.WoodElf,
                RaceConstants.BaseRaces.YuanTiAbomination,
                RaceConstants.BaseRaces.YuanTiHalfblood,
                RaceConstants.BaseRaces.YuanTiPureblood,
            };

            base.DistinctCollection(AlignmentConstants.NeutralEvil, baseRaces);
        }

        [Test]
        public void ChaoticEvilBaseRaces()
        {
            var baseRaces = new[]
            {
                RaceConstants.BaseRaces.BlueSlaad,
                RaceConstants.BaseRaces.Bugbear,
                RaceConstants.BaseRaces.CloudGiant,
                RaceConstants.BaseRaces.DeathSlaad,
                RaceConstants.BaseRaces.Derro,
                RaceConstants.BaseRaces.Drow,
                RaceConstants.BaseRaces.DuergarDwarf,
                RaceConstants.BaseRaces.FireGiant,
                RaceConstants.BaseRaces.FrostGiant,
                RaceConstants.BaseRaces.Gargoyle,
                RaceConstants.BaseRaces.Gnoll,
                RaceConstants.BaseRaces.Goblin,
                RaceConstants.BaseRaces.GraySlaad,
                RaceConstants.BaseRaces.GreenSlaad,
                RaceConstants.BaseRaces.Grimlock,
                RaceConstants.BaseRaces.HalfElf,
                RaceConstants.BaseRaces.HalfOrc,
                RaceConstants.BaseRaces.Harpy,
                RaceConstants.BaseRaces.HillGiant,
                RaceConstants.BaseRaces.Human,
                RaceConstants.BaseRaces.Minotaur,
                RaceConstants.BaseRaces.Ogre,
                RaceConstants.BaseRaces.Orc,
                RaceConstants.BaseRaces.RedSlaad,
                RaceConstants.BaseRaces.Satyr,
                RaceConstants.BaseRaces.StormGiant,
                RaceConstants.BaseRaces.Tiefling,
                RaceConstants.BaseRaces.Troglodyte,
                RaceConstants.BaseRaces.Troll,
                RaceConstants.BaseRaces.YuanTiAbomination,
                RaceConstants.BaseRaces.YuanTiHalfblood,
                RaceConstants.BaseRaces.YuanTiPureblood,
            };

            base.DistinctCollection(AlignmentConstants.ChaoticEvil, baseRaces);
        }

        [Test]
        public void AllBaseRacesHaveFullAlignmentGroup()
        {
            var fullAlignments = new[]
            {
                AlignmentConstants.ChaoticEvil,
                AlignmentConstants.ChaoticNeutral,
                AlignmentConstants.ChaoticGood,
                AlignmentConstants.LawfulEvil,
                AlignmentConstants.LawfulNeutral,
                AlignmentConstants.LawfulGood,
                AlignmentConstants.NeutralEvil,
                AlignmentConstants.TrueNeutral,
                AlignmentConstants.NeutralGood,
            };

            var baseRaceGroups = CollectionsMapper.Map(TableNameConstants.Set.Collection.BaseRaceGroups);
            var baseRaces = baseRaceGroups[GroupConstants.All];
            var alignmentBaseRaces = baseRaceGroups.Where(kvp => fullAlignments.Contains(kvp.Key)).SelectMany(kvp => kvp.Value).Distinct();

            AssertCollection(alignmentBaseRaces, baseRaces);
        }
    }
}