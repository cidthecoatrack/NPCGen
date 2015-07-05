﻿using System;
using EquipmentGen.Common.Items;
using NPCGen.Common.Abilities.Feats;
using NPCGen.Common.CharacterClasses;
using NPCGen.Tables.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables.Abilities.Feats.Data.CharacterClasses
{
    [TestFixture]
    public class BardFeatDataTests : CharacterClassFeatDataTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Formattable.Collection.CLASSFeatData, CharacterClassConstants.Bard); }
        }

        [TestCase(FeatConstants.SimpleWeaponProficiencyId,
            FeatConstants.SimpleWeaponProficiencyId,
            FeatConstants.SimpleWeaponProficiencyId,
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.MartialWeaponProficiencyId + WeaponConstants.Longsword,
            FeatConstants.MartialWeaponProficiencyId,
            WeaponConstants.Longsword,
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.MartialWeaponProficiencyId + WeaponConstants.Rapier,
            FeatConstants.MartialWeaponProficiencyId,
            WeaponConstants.Rapier,
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.MartialWeaponProficiencyId + WeaponConstants.Sap,
            FeatConstants.MartialWeaponProficiencyId,
            WeaponConstants.Sap,
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.MartialWeaponProficiencyId + WeaponConstants.ShortSword,
            FeatConstants.MartialWeaponProficiencyId,
            WeaponConstants.ShortSword,
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.MartialWeaponProficiencyId + WeaponConstants.Shortbow,
            FeatConstants.MartialWeaponProficiencyId,
            WeaponConstants.Shortbow,
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.ExoticWeaponProficiencyId + WeaponConstants.Whip,
            FeatConstants.ExoticWeaponProficiencyId,
            WeaponConstants.Whip,
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.LightArmorProficiencyId,
            FeatConstants.LightArmorProficiencyId,
            "",
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.ShieldProficiencyId,
            FeatConstants.ShieldProficiencyId,
            "",
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "1",
            FeatConstants.BardicMusicId,
            "",
            1,
            "",
            FeatConstants.Frequencies.Day,
            1,
            1,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "2",
            FeatConstants.BardicMusicId,
            "",
            2,
            "",
            FeatConstants.Frequencies.Day,
            2,
            2,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "3",
            FeatConstants.BardicMusicId,
            "",
            3,
            "",
            FeatConstants.Frequencies.Day,
            3,
            3,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "4",
            FeatConstants.BardicMusicId,
            "",
            4,
            "",
            FeatConstants.Frequencies.Day,
            4,
            4,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "5",
            FeatConstants.BardicMusicId,
            "",
            5,
            "",
            FeatConstants.Frequencies.Day,
            5,
            5,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "6",
            FeatConstants.BardicMusicId,
            "",
            6,
            "",
            FeatConstants.Frequencies.Day,
            6,
            6,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "7",
            FeatConstants.BardicMusicId,
            "",
            7,
            "",
            FeatConstants.Frequencies.Day,
            7,
            7,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "8",
            FeatConstants.BardicMusicId,
            "",
            8,
            "",
            FeatConstants.Frequencies.Day,
            8,
            8,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "9",
            FeatConstants.BardicMusicId,
            "",
            9,
            "",
            FeatConstants.Frequencies.Day,
            9,
            9,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "10",
            FeatConstants.BardicMusicId,
            "",
            10,
            "",
            FeatConstants.Frequencies.Day,
            10,
            10,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "11",
            FeatConstants.BardicMusicId,
            "",
            11,
            "",
            FeatConstants.Frequencies.Day,
            11,
            11,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "12",
            FeatConstants.BardicMusicId,
            "",
            12,
            "",
            FeatConstants.Frequencies.Day,
            12,
            12,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "13",
            FeatConstants.BardicMusicId,
            "",
            13,
            "",
            FeatConstants.Frequencies.Day,
            13,
            13,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "14",
            FeatConstants.BardicMusicId,
            "",
            14,
            "",
            FeatConstants.Frequencies.Day,
            14,
            14,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "15",
            FeatConstants.BardicMusicId,
            "",
            15,
            "",
            FeatConstants.Frequencies.Day,
            15,
            15,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "16",
            FeatConstants.BardicMusicId,
            "",
            16,
            "",
            FeatConstants.Frequencies.Day,
            16,
            16,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "17",
            FeatConstants.BardicMusicId,
            "",
            17,
            "",
            FeatConstants.Frequencies.Day,
            17,
            17,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "18",
            FeatConstants.BardicMusicId,
            "",
            18,
            "",
            FeatConstants.Frequencies.Day,
            18,
            18,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "19",
            FeatConstants.BardicMusicId,
            "",
            19,
            "",
            FeatConstants.Frequencies.Day,
            19,
            19,
            0)]
        [TestCase(FeatConstants.BardicMusicId + "20",
            FeatConstants.BardicMusicId,
            "",
            20,
            "",
            FeatConstants.Frequencies.Day,
            20,
            20,
            0)]
        [TestCase(FeatConstants.BardicKnowledgeId,
            FeatConstants.BardicKnowledgeId,
            "",
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.CountersongId,
            FeatConstants.CountersongId,
            "",
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.FascinateId,
            FeatConstants.FascinateId,
            "",
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.InspireCourageId + "1",
            FeatConstants.InspireCourageId,
            "",
            0,
            "",
            "",
            1,
            7,
            1)]
        [TestCase(FeatConstants.InspireCourageId + "2",
            FeatConstants.InspireCourageId,
            "",
            0,
            "",
            "",
            8,
            13,
            2)]
        [TestCase(FeatConstants.InspireCourageId + "3",
            FeatConstants.InspireCourageId,
            "",
            0,
            "",
            "",
            14,
            19,
            3)]
        [TestCase(FeatConstants.InspireCourageId + "4",
            FeatConstants.InspireCourageId,
            "",
            0,
            "",
            "",
            20,
            0,
            4)]
        [TestCase(FeatConstants.InspireCompetenceId,
            FeatConstants.InspireCompetenceId,
            "",
            0,
            "",
            "",
            3,
            0,
            0)]
        [TestCase(FeatConstants.SuggestionId,
            FeatConstants.SuggestionId,
            "",
            0,
            "",
            "",
            6,
            0,
            0)]
        [TestCase(FeatConstants.InspireGreatnessId,
            FeatConstants.InspireGreatnessId,
            "",
            0,
            "",
            "",
            9,
            0,
            0)]
        [TestCase(FeatConstants.SongOfFreedomId,
            FeatConstants.SongOfFreedomId,
            "",
            0,
            "",
            "",
            12,
            0,
            0)]
        [TestCase(FeatConstants.InspireHeroicsId,
            FeatConstants.InspireHeroicsId,
            "",
            0,
            "",
            "",
            15,
            0,
            0)]
        [TestCase(FeatConstants.MassSuggestionId,
            FeatConstants.MassSuggestionId,
            "",
            0,
            "",
            "",
            18,
            0,
            0)]
        public override void Data(String name, String featId, String focusType, Int32 frequencyQuantity, String frequencyQuantityStat, String frequencyTimePeriod, Int32 minimumLevel, Int32 maximumLevel, Int32 strength)
        {
            base.Data(name, featId, focusType, frequencyQuantity, frequencyQuantityStat, frequencyTimePeriod, minimumLevel, maximumLevel, strength);
        }
    }
}
