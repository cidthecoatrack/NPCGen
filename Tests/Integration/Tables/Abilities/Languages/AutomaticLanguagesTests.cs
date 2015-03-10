﻿using System;
using NPCGen.Common.Abilities;
using NPCGen.Common.CharacterClasses;
using NPCGen.Common.Races;
using NPCGen.Tables.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables.Abilities.Languages
{
    [TestFixture]
    public class AutomaticLanguagesTests : CollectionTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Set.Collection.AutomaticLanguages; }
        }

        [TestCase(RaceConstants.BaseRaces.AasimarId,
            LanguageConstants.Common,
            LanguageConstants.Celestial)]
        [TestCase(RaceConstants.BaseRaces.BugbearId,
            LanguageConstants.Common,
            LanguageConstants.Goblin)]
        [TestCase(RaceConstants.BaseRaces.DerroId,
            LanguageConstants.Common,
            LanguageConstants.Dwarven)]
        [TestCase(RaceConstants.BaseRaces.DoppelgangerId,
            LanguageConstants.Common)]
        [TestCase(RaceConstants.BaseRaces.DrowId,
            LanguageConstants.Common,
            LanguageConstants.Elven,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.DuergarDwarfId,
            LanguageConstants.Common,
            LanguageConstants.Dwarven,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.DeepDwarfId,
            LanguageConstants.Common,
            LanguageConstants.Dwarven)]
        [TestCase(RaceConstants.BaseRaces.HillDwarfId,
            LanguageConstants.Common,
            LanguageConstants.Dwarven)]
        [TestCase(RaceConstants.BaseRaces.MountainDwarfId,
            LanguageConstants.Common,
            LanguageConstants.Dwarven)]
        [TestCase(RaceConstants.BaseRaces.GrayElfId,
            LanguageConstants.Common,
            LanguageConstants.Elven)]
        [TestCase(RaceConstants.BaseRaces.HighElfId,
            LanguageConstants.Common,
            LanguageConstants.Elven)]
        [TestCase(RaceConstants.BaseRaces.WildElfId,
            LanguageConstants.Common,
            LanguageConstants.Elven)]
        [TestCase(RaceConstants.BaseRaces.WoodElfId,
            LanguageConstants.Common,
            LanguageConstants.Elven)]
        [TestCase(RaceConstants.BaseRaces.GnollId,
            LanguageConstants.Gnoll)]
        [TestCase(RaceConstants.BaseRaces.ForestGnomeId,
            LanguageConstants.Common,
            LanguageConstants.Elven,
            LanguageConstants.Gnome,
            LanguageConstants.Sylvan)]
        [TestCase(RaceConstants.BaseRaces.RockGnomeId,
            LanguageConstants.Common,
            LanguageConstants.Gnome)]
        [TestCase(RaceConstants.BaseRaces.SvirfneblinId,
            LanguageConstants.Common,
            LanguageConstants.Gnome,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.GoblinId,
            LanguageConstants.Common,
            LanguageConstants.Goblin)]
        [TestCase(RaceConstants.Metaraces.HalfCelestialId,
            LanguageConstants.Celestial)]
        [TestCase(RaceConstants.Metaraces.HalfDragonId,
            LanguageConstants.Draconic)]
        [TestCase(RaceConstants.BaseRaces.HalfElfId,
            LanguageConstants.Common,
            LanguageConstants.Elven)]
        [TestCase(RaceConstants.Metaraces.HalfFiendId,
            LanguageConstants.Infernal)]
        [TestCase(RaceConstants.BaseRaces.HalfOrcId,
            LanguageConstants.Common,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.DeepHalflingId,
            LanguageConstants.Common,
            LanguageConstants.Halfling)]
        [TestCase(RaceConstants.BaseRaces.LightfootHalflingId,
            LanguageConstants.Common,
            LanguageConstants.Halfling)]
        [TestCase(RaceConstants.BaseRaces.TallfellowHalflingId,
            LanguageConstants.Common,
            LanguageConstants.Halfling)]
        [TestCase(RaceConstants.BaseRaces.HobgoblinId,
            LanguageConstants.Common,
            LanguageConstants.Goblin)]
        [TestCase(RaceConstants.BaseRaces.HumanId,
            LanguageConstants.Common)]
        [TestCase(RaceConstants.BaseRaces.KoboldId,
            LanguageConstants.Draconic)]
        [TestCase(RaceConstants.BaseRaces.LizardfolkId,
            LanguageConstants.Common,
            LanguageConstants.Draconic)]
        [TestCase(RaceConstants.BaseRaces.MindFlayerId,
            LanguageConstants.Common,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.MinotaurId,
            LanguageConstants.Common,
            LanguageConstants.Giant)]
        [TestCase(RaceConstants.BaseRaces.OgreId,
            LanguageConstants.Common,
            LanguageConstants.Giant)]
        [TestCase(RaceConstants.BaseRaces.OgreMageId,
            LanguageConstants.Common,
            LanguageConstants.Giant)]
        [TestCase(RaceConstants.BaseRaces.OrcId,
            LanguageConstants.Common,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.TieflingId,
            LanguageConstants.Common,
            LanguageConstants.Infernal)]
        [TestCase(RaceConstants.BaseRaces.TroglodyteId,
            LanguageConstants.Draconic)]
        [TestCase(RaceConstants.Metaraces.WerebearId)]
        [TestCase(RaceConstants.Metaraces.WereboarId)]
        [TestCase(RaceConstants.Metaraces.WereratId)]
        [TestCase(RaceConstants.Metaraces.WeretigerId)]
        [TestCase(RaceConstants.Metaraces.WerewolfId)]
        [TestCase(RaceConstants.Metaraces.NoneId)]
        [TestCase(CharacterClassConstants.Barbarian)]
        [TestCase(CharacterClassConstants.Bard)]
        [TestCase(CharacterClassConstants.Cleric)]
        [TestCase(CharacterClassConstants.Druid,
            LanguageConstants.Druidic)]
        [TestCase(CharacterClassConstants.Fighter)]
        [TestCase(CharacterClassConstants.Monk)]
        [TestCase(CharacterClassConstants.Paladin)]
        [TestCase(CharacterClassConstants.Ranger)]
        [TestCase(CharacterClassConstants.Rogue)]
        [TestCase(CharacterClassConstants.Sorcerer)]
        [TestCase(CharacterClassConstants.Wizard)]
        public override void DistinctCollection(String name, params String[] languages)
        {
            base.DistinctCollection(name, languages);
        }
    }
}