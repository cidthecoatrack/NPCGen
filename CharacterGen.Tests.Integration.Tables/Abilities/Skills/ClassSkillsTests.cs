﻿using CharacterGen.Abilities.Skills;
using CharacterGen.CharacterClasses;
using CharacterGen.Domain.Tables;
using CharacterGen.Races;
using NUnit.Framework;
using System.Linq;

namespace CharacterGen.Tests.Integration.Tables.Abilities.Skills
{
    [TestFixture]
    public class ClassSkillsTests : CollectionTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Set.Collection.ClassSkills; }
        }

        [Test]
        public override void CollectionNames()
        {
            var baseRaceGroups = CollectionsMapper.Map(TableNameConstants.Set.Collection.BaseRaceGroups);
            var classGroups = CollectionsMapper.Map(TableNameConstants.Set.Collection.ClassNameGroups);

            var names = classGroups[GroupConstants.All].Union(baseRaceGroups[GroupConstants.All]);
            AssertCollectionNames(names);
        }

        [TestCase(CharacterClassConstants.Adept,
            SkillConstants.Concentration,
            SkillConstants.HandleAnimal,
            SkillConstants.Heal,
            SkillConstants.KnowledgeArcana,
            SkillConstants.KnowledgeArchitectureAndEngineering,
            SkillConstants.KnowledgeDungeoneering,
            SkillConstants.KnowledgeGeography,
            SkillConstants.KnowledgeHistory,
            SkillConstants.KnowledgeLocal,
            SkillConstants.KnowledgeNature,
            SkillConstants.KnowledgeNobilityAndRoyalty,
            SkillConstants.KnowledgeReligion,
            SkillConstants.KnowledgeThePlanes,
            SkillConstants.Spellcraft,
            SkillConstants.Survival)]
        [TestCase(CharacterClassConstants.Barbarian,
            SkillConstants.Climb,
            SkillConstants.HandleAnimal,
            SkillConstants.Intimidate,
            SkillConstants.Jump,
            SkillConstants.Listen,
            SkillConstants.Ride,
            SkillConstants.Survival,
            SkillConstants.Swim)]
        [TestCase(CharacterClassConstants.Cleric,
            SkillConstants.Concentration,
            SkillConstants.Diplomacy,
            SkillConstants.Heal,
            SkillConstants.KnowledgeArcana,
            SkillConstants.KnowledgeHistory,
            SkillConstants.KnowledgeReligion,
            SkillConstants.KnowledgeThePlanes,
            SkillConstants.Spellcraft)]
        [TestCase(CharacterClassConstants.Commoner,
            SkillConstants.Climb,
            SkillConstants.HandleAnimal,
            SkillConstants.Jump,
            SkillConstants.Listen,
            SkillConstants.Ride,
            SkillConstants.Spot,
            SkillConstants.Swim,
            SkillConstants.UseRope)]
        [TestCase(CharacterClassConstants.Druid,
            SkillConstants.Concentration,
            SkillConstants.Diplomacy,
            SkillConstants.HandleAnimal,
            SkillConstants.Heal,
            SkillConstants.KnowledgeNature,
            SkillConstants.Listen,
            SkillConstants.Ride,
            SkillConstants.Spellcraft,
            SkillConstants.Spot,
            SkillConstants.Survival,
            SkillConstants.Swim)]
        [TestCase(CharacterClassConstants.Expert)]
        [TestCase(CharacterClassConstants.Fighter,
            SkillConstants.Climb,
            SkillConstants.HandleAnimal,
            SkillConstants.Intimidate,
            SkillConstants.Jump,
            SkillConstants.Ride,
            SkillConstants.Swim)]
        [TestCase(CharacterClassConstants.Monk,
            SkillConstants.Balance,
            SkillConstants.Climb,
            SkillConstants.Concentration,
            SkillConstants.Diplomacy,
            SkillConstants.EscapeArtist,
            SkillConstants.Hide,
            SkillConstants.Jump,
            SkillConstants.KnowledgeArcana,
            SkillConstants.KnowledgeReligion,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.Perform,
            SkillConstants.SenseMotive,
            SkillConstants.Spot,
            SkillConstants.Swim,
            SkillConstants.Tumble)]
        [TestCase(CharacterClassConstants.Paladin,
            SkillConstants.Concentration,
            SkillConstants.Diplomacy,
            SkillConstants.HandleAnimal,
            SkillConstants.Heal,
            SkillConstants.KnowledgeNobilityAndRoyalty,
            SkillConstants.KnowledgeReligion,
            SkillConstants.Ride,
            SkillConstants.SenseMotive)]
        [TestCase(CharacterClassConstants.Ranger,
            SkillConstants.Climb,
            SkillConstants.Concentration,
            SkillConstants.HandleAnimal,
            SkillConstants.Heal,
            SkillConstants.Hide,
            SkillConstants.Jump,
            SkillConstants.KnowledgeDungeoneering,
            SkillConstants.KnowledgeGeography,
            SkillConstants.KnowledgeNature,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.Ride,
            SkillConstants.Search,
            SkillConstants.Spot,
            SkillConstants.Survival,
            SkillConstants.Swim,
            SkillConstants.UseRope)]
        [TestCase(CharacterClassConstants.Rogue,
            SkillConstants.Appraise,
            SkillConstants.Balance,
            SkillConstants.Bluff,
            SkillConstants.Climb,
            SkillConstants.DecipherScript,
            SkillConstants.Diplomacy,
            SkillConstants.DisableDevice,
            SkillConstants.Disguise,
            SkillConstants.EscapeArtist,
            SkillConstants.Forgery,
            SkillConstants.GatherInformation,
            SkillConstants.Hide,
            SkillConstants.Intimidate,
            SkillConstants.Jump,
            SkillConstants.KnowledgeLocal,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.OpenLock,
            SkillConstants.Perform,
            SkillConstants.Search,
            SkillConstants.SenseMotive,
            SkillConstants.SleightOfHand,
            SkillConstants.Spot,
            SkillConstants.Swim,
            SkillConstants.Tumble,
            SkillConstants.UseMagicDevice,
            SkillConstants.UseRope)]
        [TestCase(CharacterClassConstants.Sorcerer,
            SkillConstants.Bluff,
            SkillConstants.Concentration,
            SkillConstants.KnowledgeArcana,
            SkillConstants.Spellcraft)]
        [TestCase(CharacterClassConstants.Warrior,
            SkillConstants.Climb,
            SkillConstants.HandleAnimal,
            SkillConstants.Intimidate,
            SkillConstants.Jump,
            SkillConstants.Ride,
            SkillConstants.Swim)]
        [TestCase(CharacterClassConstants.Wizard,
            SkillConstants.Concentration,
            SkillConstants.DecipherScript,
            SkillConstants.KnowledgeArcana,
            SkillConstants.KnowledgeArchitectureAndEngineering,
            SkillConstants.KnowledgeDungeoneering,
            SkillConstants.KnowledgeGeography,
            SkillConstants.KnowledgeHistory,
            SkillConstants.KnowledgeLocal,
            SkillConstants.KnowledgeNature,
            SkillConstants.KnowledgeNobilityAndRoyalty,
            SkillConstants.KnowledgeReligion,
            SkillConstants.KnowledgeThePlanes,
            SkillConstants.Spellcraft)]
        [TestCase(RaceConstants.BaseRaces.Aasimar)]
        [TestCase(RaceConstants.BaseRaces.Azer,
            SkillConstants.Appraise,
            SkillConstants.Climb,
            SkillConstants.Hide,
            SkillConstants.Jump,
            SkillConstants.Listen,
            SkillConstants.Search,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.BlueSlaad,
            SkillConstants.Climb,
            SkillConstants.Hide,
            SkillConstants.Jump,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.Bugbear,
            SkillConstants.Climb,
            SkillConstants.Hide,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.Search,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.Centaur,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.Spot,
            SkillConstants.Survival)]
        [TestCase(RaceConstants.BaseRaces.CloudGiant,
            SkillConstants.Climb,
            SkillConstants.Diplomacy,
            SkillConstants.Intimidate,
            SkillConstants.Listen,
            SkillConstants.Perform,
            SkillConstants.SenseMotive,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.DeathSlaad,
            SkillConstants.Climb,
            SkillConstants.Concentration,
            SkillConstants.EscapeArtist,
            SkillConstants.Hide,
            SkillConstants.Intimidate,
            SkillConstants.Jump,
            RaceConstants.BaseRaces.DeathSlaad + SkillConstants.Knowledge,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.Search,
            SkillConstants.Spellcraft,
            SkillConstants.Spot,
            SkillConstants.Survival,
            SkillConstants.UseRope)]
        [TestCase(RaceConstants.BaseRaces.DeepDwarf)]
        [TestCase(RaceConstants.BaseRaces.DeepHalfling)]
        [TestCase(RaceConstants.BaseRaces.Derro,
            SkillConstants.Bluff,
            SkillConstants.Hide,
            SkillConstants.Listen,
            SkillConstants.MoveSilently)]
        [TestCase(RaceConstants.BaseRaces.Doppelganger,
            SkillConstants.Bluff,
            SkillConstants.Diplomacy,
            SkillConstants.Disguise,
            SkillConstants.Intimidate,
            SkillConstants.Listen,
            SkillConstants.SenseMotive,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.Drow)]
        [TestCase(RaceConstants.BaseRaces.DuergarDwarf)]
        [TestCase(RaceConstants.BaseRaces.FireGiant,
            SkillConstants.Climb,
            SkillConstants.Intimidate,
            SkillConstants.Jump,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.ForestGnome)]
        [TestCase(RaceConstants.BaseRaces.FrostGiant,
            SkillConstants.Climb,
            SkillConstants.Intimidate,
            SkillConstants.Jump,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.Gargoyle,
            SkillConstants.Hide,
            SkillConstants.Listen,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.Gnoll,
            SkillConstants.Listen,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.Goblin)]
        [TestCase(RaceConstants.BaseRaces.GrayElf)]
        [TestCase(RaceConstants.BaseRaces.GraySlaad,
            SkillConstants.Climb,
            SkillConstants.Concentration,
            SkillConstants.Hide,
            SkillConstants.Jump,
            SkillConstants.KnowledgeArcana,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.Search,
            SkillConstants.Spellcraft,
            SkillConstants.Spot,
            SkillConstants.Survival)]
        [TestCase(RaceConstants.BaseRaces.GreenSlaad,
            SkillConstants.Climb,
            SkillConstants.Concentration,
            SkillConstants.Hide,
            SkillConstants.Jump,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.Search,
            SkillConstants.Spot,
            SkillConstants.Survival)]
        [TestCase(RaceConstants.BaseRaces.Grimlock,
            SkillConstants.Climb,
            SkillConstants.Hide,
            SkillConstants.Listen,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.HalfElf)]
        [TestCase(RaceConstants.BaseRaces.HalfOrc)]
        [TestCase(RaceConstants.BaseRaces.Harpy,
            SkillConstants.Bluff,
            SkillConstants.Intimidate,
            SkillConstants.Listen,
            SkillConstants.Perform,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.HighElf)]
        [TestCase(RaceConstants.BaseRaces.HillDwarf)]
        [TestCase(RaceConstants.BaseRaces.HillGiant,
            SkillConstants.Climb,
            SkillConstants.Jump,
            SkillConstants.Listen,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.Hobgoblin)]
        [TestCase(RaceConstants.BaseRaces.HoundArchon,
            SkillConstants.Concentration,
            SkillConstants.Hide,
            SkillConstants.Jump,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.SenseMotive,
            SkillConstants.Spot,
            SkillConstants.Survival)]
        [TestCase(RaceConstants.BaseRaces.Human)]
        [TestCase(RaceConstants.BaseRaces.Janni,
            SkillConstants.Appraise,
            SkillConstants.Concentration,
            SkillConstants.EscapeArtist,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.Ride,
            SkillConstants.SenseMotive,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.Kobold)]
        [TestCase(RaceConstants.BaseRaces.LightfootHalfling)]
        [TestCase(RaceConstants.BaseRaces.Lizardfolk,
            SkillConstants.Balance,
            SkillConstants.Jump,
            SkillConstants.Swim)]
        [TestCase(RaceConstants.BaseRaces.MindFlayer,
            SkillConstants.Bluff,
            SkillConstants.Concentration,
            SkillConstants.Hide,
            SkillConstants.Intimidate,
            RaceConstants.BaseRaces.MindFlayer + SkillConstants.Knowledge,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.Minotaur,
            SkillConstants.Intimidate,
            SkillConstants.Jump,
            SkillConstants.Listen,
            SkillConstants.Search,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.MountainDwarf)]
        [TestCase(RaceConstants.BaseRaces.Ogre,
            SkillConstants.Climb,
            SkillConstants.Listen,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.OgreMage,
            SkillConstants.Listen,
            SkillConstants.Spot,
            SkillConstants.Spellcraft,
            SkillConstants.Concentration)]
        [TestCase(RaceConstants.BaseRaces.Orc)]
        [TestCase(RaceConstants.BaseRaces.Pixie)]
        [TestCase(RaceConstants.BaseRaces.Rakshasa,
            SkillConstants.Bluff,
            SkillConstants.Disguise,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.Perform,
            SkillConstants.SenseMotive,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.RedSlaad,
            SkillConstants.Climb,
            SkillConstants.Hide,
            SkillConstants.Jump,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.RockGnome)]
        [TestCase(RaceConstants.BaseRaces.Satyr,
            SkillConstants.Bluff,
            SkillConstants.Hide,
            SkillConstants.KnowledgeNature,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.Perform,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.Scorpionfolk,
            SkillConstants.Diplomacy,
            SkillConstants.Intimidate,
            SkillConstants.Listen,
            SkillConstants.SenseMotive,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.StoneGiant,
            SkillConstants.Climb,
            SkillConstants.Hide,
            SkillConstants.Listen,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.StormGiant,
            SkillConstants.Climb,
            SkillConstants.Concentration,
            SkillConstants.Diplomacy,
            SkillConstants.Intimidate,
            SkillConstants.Jump,
            SkillConstants.Listen,
            SkillConstants.Perform,
            SkillConstants.SenseMotive,
            SkillConstants.Spot,
            SkillConstants.Swim)]
        [TestCase(RaceConstants.BaseRaces.Svirfneblin)]
        [TestCase(RaceConstants.BaseRaces.TallfellowHalfling)]
        [TestCase(RaceConstants.BaseRaces.Tiefling)]
        [TestCase(RaceConstants.BaseRaces.Troglodyte,
            SkillConstants.Listen,
            SkillConstants.Hide)]
        [TestCase(RaceConstants.BaseRaces.Troll)]
        [TestCase(RaceConstants.BaseRaces.WildElf)]
        [TestCase(RaceConstants.BaseRaces.WoodElf)]
        [TestCase(RaceConstants.BaseRaces.YuanTiAbomination,
            SkillConstants.Concentration,
            SkillConstants.Hide,
            RaceConstants.BaseRaces.YuanTiAbomination + SkillConstants.Knowledge,
            SkillConstants.Listen,
            SkillConstants.MoveSilently,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.YuanTiHalfblood,
            SkillConstants.Concentration,
            SkillConstants.Hide,
            RaceConstants.BaseRaces.YuanTiHalfblood + SkillConstants.Knowledge,
            SkillConstants.Listen,
            SkillConstants.Spot)]
        [TestCase(RaceConstants.BaseRaces.YuanTiPureblood,
            SkillConstants.Concentration,
            SkillConstants.Disguise,
            SkillConstants.Hide,
            RaceConstants.BaseRaces.YuanTiPureblood + SkillConstants.Knowledge,
            SkillConstants.Listen,
            SkillConstants.Spot)]
        public void ClassSkills(string name, params string[] skills)
        {
            base.DistinctCollection(name, skills);
        }

        [Test]
        public void AristocratClassSkills()
        {
            var classSkills = new[]
            {
                SkillConstants.Appraise,
                SkillConstants.Bluff,
                SkillConstants.Diplomacy,
                SkillConstants.Disguise,
                SkillConstants.Forgery,
                SkillConstants.GatherInformation,
                SkillConstants.HandleAnimal,
                SkillConstants.Intimidate,
                SkillConstants.KnowledgeArcana,
                SkillConstants.KnowledgeArchitectureAndEngineering,
                SkillConstants.KnowledgeDungeoneering,
                SkillConstants.KnowledgeGeography,
                SkillConstants.KnowledgeHistory,
                SkillConstants.KnowledgeLocal,
                SkillConstants.KnowledgeNature,
                SkillConstants.KnowledgeNobilityAndRoyalty,
                SkillConstants.KnowledgeReligion,
                SkillConstants.KnowledgeThePlanes,
                SkillConstants.Listen,
                SkillConstants.Ride,
                SkillConstants.SenseMotive,
                SkillConstants.Spot,
                SkillConstants.Swim,
                SkillConstants.Survival
            };

            DistinctCollection(CharacterClassConstants.Aristocrat, classSkills);
        }

        [Test]
        public void BardClassSkills()
        {
            var classSkills = new[]
            {
                SkillConstants.Appraise,
                SkillConstants.Balance,
                SkillConstants.Bluff,
                SkillConstants.Climb,
                SkillConstants.Concentration,
                SkillConstants.DecipherScript,
                SkillConstants.Diplomacy,
                SkillConstants.Disguise,
                SkillConstants.EscapeArtist,
                SkillConstants.GatherInformation,
                SkillConstants.Hide,
                SkillConstants.Jump,
                SkillConstants.KnowledgeArcana,
                SkillConstants.KnowledgeArchitectureAndEngineering,
                SkillConstants.KnowledgeDungeoneering,
                SkillConstants.KnowledgeGeography,
                SkillConstants.KnowledgeHistory,
                SkillConstants.KnowledgeLocal,
                SkillConstants.KnowledgeNature,
                SkillConstants.KnowledgeNobilityAndRoyalty,
                SkillConstants.KnowledgeReligion,
                SkillConstants.KnowledgeThePlanes,
                SkillConstants.Listen,
                SkillConstants.MoveSilently,
                SkillConstants.Perform,
                SkillConstants.SenseMotive,
                SkillConstants.SleightOfHand,
                SkillConstants.Spellcraft,
                SkillConstants.Swim,
                SkillConstants.Tumble,
                SkillConstants.UseMagicDevice
            };

            DistinctCollection(CharacterClassConstants.Bard, classSkills);
        }
    }
}