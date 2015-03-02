﻿using System;

namespace NPCGen.Tables.Interfaces
{
    public static class TableNameConstants
    {
        public static class Set
        {
            public static class Percentile
            {
                public const String AlignmentGoodness = "AlignmentGoodness";
                public const String Traits = "Traits";
            }

            public static class Adjustments
            {
                public const String ArmorBonuses = "ArmorBonuses";
                public const String ArmorCheckPenalties = "ArmorCheckPenalties";
                public const String ClassHitDice = "ClassHitDice";
                public const String FeatArmorAdjustments = "FeatArmorAdjustments";
                public const String FeatInitiativeBonuses = "FeatInitiativeBonuses";
                public const String FighterFeatLevelRequirements = "FighterFeatLevelRequirements";
                public const String LandSpeeds = "LandSpeeds";
                public const String LevelAdjustments = "LevelAdjustments";
                public const String MaxDexterityBonus = "MaxDexterityBonus";
                public const String MonsterHitDice = "MonsterHitDice";
                public const String RacialBaseAttackAdjustments = "RacialBaseAttackAdjustments";
                public const String RacialInitiativeBonuses = "RacialInitiativeBonuses";
                public const String RacialNaturalArmorBonuses = "RacialNaturalArmorBonuses";
                public const String SkillPointsForClasses = "SkillPointsForClasses";
            }

            public static class Collection
            {
                public const String AutomaticLanguages = "AutomaticLanguages";
                public const String ArmorClassModifiers = "ArmorClassModifiers";
                public const String BaseRaceGroups = "BaseRaceGroups";
                public const String Names = "Names";
                public const String BonusLanguages = "BonusLanguages";
                public const String ClassFeats = "ClassFeats";
                public const String ClassNameGroups = "ClassNameGroups";
                public const String ClassSkills = "ClassSkills";
                public const String CrossClassSkills = "CrossClassSkills";
                public const String DragonSpecies = "DragonSpecies";
                public const String FeatGroups = "FeatGroups";
                public const String FeatSpecificApplications = "FeatSpecificApplications";
                public const String MetaraceGroups = "MetaraceGroups";
                public const String SkillData = "SkillData";
                public const String SkillGroups = "SkillGroups";
                public const String SkillSynergy = "SkillSynergy";
                public const String SkillSynergyFeats = "SkillSynergyFeats";
                public const String StatPriorities = "StatPriorities";

                public static class Groups
                {
                    public const String AverageBaseAttack = "AverageBaseAttack";
                    public const String CumulativeStrengths = "CumulativeStrengths";
                    public const String Deflection = "Deflection";
                    public const String Dodge = "Dodge";
                    public const String Genetic = "Genetic";
                    public const String GoodBaseAttack = "GoodBaseAttack";
                    public const String Healers = "Healers";
                    public const String Knowledge = "Knowledge";
                    public const String Lycanthrope = "Lycanthrope";
                    public const String Mages = "Mages";
                    public const String Monsters = "Monsters";
                    public const String NaturalArmor = "NaturalArmor";
                    public const String OverwrittenStrengths = "OverwrittenStrengths";
                    public const String Size = "Size";
                    public const String Spellcasters = "Spellcasters";
                    public const String Standard = "Standard";
                    public const String Stealth = "Stealth";
                    public const String Warriors = "Warriors";
                }
            }
        }

        public static class Formattable
        {
            public static class Percentile
            {
                public const String GOODNESSCharacterClasses = "{0}CharacterClasses";
                public const String GOODNESSCLASSBaseRaces = "{0}{1}BaseRaces";
                public const String GOODNESSCLASSMetaraces = "{0}{1}Metaraces";
            }

            public static class Adjustments
            {
                public const String BASERACESkillAdjustments = "{0}SkillAdjustments";
                public const String CLASSFeatLevelRequirements = "{0}FeatLevelRequirements";
                public const String FEATSkillAdjustments = "{0}SkillAdjustments";
                public const String METARACESkillAdjustments = "{0}SkillAdjustments";
            }
        }
    }
}