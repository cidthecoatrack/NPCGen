﻿using NPCGen.Common;
using NPCGen.Common.Alignments;
using NPCGen.Common.CharacterClasses;
using NPCGen.Common.Races;
using NPCGen.Common.Stats;
using NPCGen.Generators.Interfaces;
using System;
using System.Collections.Generic;
using NPCGen.Selectors.Interfaces;
using NPCGen.Generators.Interfaces.Verifiers;
using NPCGen.Generators.Interfaces.Randomizers.Alignments;
using NPCGen.Generators.Interfaces.Randomizers.CharacterClasses;
using NPCGen.Generators.Interfaces.Randomizers.Races;
using NPCGen.Generators.Interfaces.Randomizers.Stats;
using NPCGen.Generators.Interfaces.Verifiers.Exceptions;

namespace NPCGen.Generators
{
    public class CharacterGenerator : ICharacterGenerator
    {
        private ILanguageGenerator languageGenerator;
        private IAlignmentGenerator alignmentGenerator;
        private ICharacterClassGenerator characterClassGenerator;
        private IStatsGenerator statsGenerator;
        private IHitPointsGenerator hitPointsGenerator;
        private IRaceGenerator raceGenerator;
        private ILevelAdjustmentsSelector levelAdjustmentsSelector;
        private IRandomizerVerifier randomizerVerifier;
        private IPercentileSelector percentileResultSelector;

        public CharacterGenerator(IAlignmentGenerator alignmentGenerator, ICharacterClassGenerator characterClassGenerator, IRaceGenerator raceGenerator, IStatsGenerator statsGenerator, ILanguageGenerator languageGenerator, IHitPointsGenerator hitPointsGenerator, ILevelAdjustmentsSelector levelAdjustmentsSelector, IRandomizerVerifier randomizerVerifier, IPercentileSelector percentileResultSelector)
        {
            this.alignmentGenerator = alignmentGenerator;
            this.characterClassGenerator = characterClassGenerator;
            this.raceGenerator = raceGenerator;
            this.statsGenerator = statsGenerator;
            this.languageGenerator = languageGenerator;
            this.hitPointsGenerator = hitPointsGenerator;

            this.levelAdjustmentsSelector = levelAdjustmentsSelector;
            this.randomizerVerifier = randomizerVerifier;
            this.percentileResultSelector = percentileResultSelector;
        }

        public Character CreateWith(IAlignmentRandomizer alignmentRandomizer, IClassNameRandomizer classNameRandomizer,
            ILevelRandomizer levelRandomizer, IBaseRaceRandomizer baseRaceRandomizer, IMetaraceRandomizer metaraceRandomizer,
            IStatsRandomizer statsRandomizer)
        {
            VerifyRandomizers(alignmentRandomizer, classNameRandomizer, levelRandomizer, baseRaceRandomizer, metaraceRandomizer);

            var character = new Character();

            character.Alignment = GenerateAlignment(alignmentRandomizer, classNameRandomizer, levelRandomizer, baseRaceRandomizer,
                metaraceRandomizer);
            var characterClassPrototype = GenerateCharacterClassPrototype(classNameRandomizer, levelRandomizer, character.Alignment,
                baseRaceRandomizer, metaraceRandomizer);

            var levelAdjustments = levelAdjustmentsSelector.GetLevelAdjustments();
            character.Race = GenerateRace(baseRaceRandomizer, metaraceRandomizer, levelAdjustments, character.Alignment, characterClassPrototype);

            characterClassPrototype.Level -= levelAdjustments[character.Race.BaseRace];
            characterClassPrototype.Level -= levelAdjustments[character.Race.Metarace];

            character.Class = characterClassGenerator.CreateWith(characterClassPrototype);

            character.Stats = statsGenerator.CreateWith(statsRandomizer, character.Class, character.Race);
            character.HitPoints = hitPointsGenerator.CreateWith(character.Class, character.Stats[StatConstants.Constitution].Bonus, character.Race);
            character.InterestingTrait = percentileResultSelector.GetPercentileResult("Traits");
            character.Languages = languageGenerator.CreateWith(character.Race, character.Class.ClassName, character.Stats[StatConstants.Intelligence].Bonus);

            //Application.DoEvents();
            //progress.Text += "\nDetermining gear...";
            ////Variables for determining magical abilities of NPC's items
            //Equipment = new String[EquipmentType.Types];
            //var twoHanded = false;

            ////Generate weapon
            //Application.DoEvents();
            //progress.Text += "\nGenerating weapon...";
            //var bonus = BonusByChance(level * PercentageChance(charClass, EquipmentType.Weapon));
            //Equipment[EquipmentType.Weapon] = Weapons.Generate(bonus, charClass, level, true, ref twoHanded);
            //if (charClass == CLASS.MONK)
            //    Equipment[EquipmentType.Weapon] += String.Format("\nUnarmed Strike: 1d{0}", Classes.MonkDamage(level));
            //progress.Text += Equipment[EquipmentType.Weapon];

            ////Generate armor
            //System.Windows.Forms.Application.DoEvents();
            //progress.Text += "\nGenerating armor...";
            //bonus = BonusByChance(level * PercentageChance(charClass, EquipmentType.Armor));
            //Equipment[EquipmentType.Armor] = Armor.GenerateArmor(bonus, charClass, level);
            //progress.Text += Equipment[EquipmentType.Armor];

            ////Generate rogue abilities, if applicable
            //System.Windows.Forms.Application.DoEvents();
            //progress.Text += "\nGenerating rogue abilities...";
            //bool[] ArmorBool = new bool[3];
            //ArmorBool[0] = (Equipment[EquipmentType.Armor] == String.Empty);
            //ArmorBool[1] = (Equipment[EquipmentType.Armor].Contains("chain") || Equipment[EquipmentType.Armor].Contains("mithral"));
            //ArmorBool[2] = (Equipment[EquipmentType.Armor].Contains("padded") || Equipment[EquipmentType.Armor].Contains("leather"));
            //if (charClass == CLASS.THIEF)
            //    RogueAbilities = Classes.ThiefAbilities(level, race.Race, StatScores[Stats.Dexterity], ArmorBool);
            //else if (charClass == CLASS.BARD)
            //    RogueAbilities = Classes.BardAbilities(level, race.Race, StatScores[Stats.Dexterity], ArmorBool);
            //if (RogueAbilities != null)
            //    foreach (var abil in RogueAbilities)
            //        progress.Text += " " + abil.ToString();

            ////Generate shield or dual-wield weapon
            //Application.DoEvents();
            //progress.Text += "\nGenerating shield or dual-wield weapon...";
            //if (!twoHanded)
            //{
            //    bonus = BonusByChance(level * PercentageChance(charClass, EquipmentType.Shield));
            //    if (Armor.CanWield(charClass, false) && StatScores[Stats.Dexterity] > 18)
            //    {
            //        if (Dice.Percentile() > 50)
            //            Equipment[EquipmentType.Shield] = Weapons.Generate(bonus, charClass, level, false, ref twoHanded);
            //        else
            //            Equipment[EquipmentType.Shield] = Armor.GenerateShield(bonus, charClass, level);
            //    }
            //    else if (StatScores[Stats.Dexterity] > 18)
            //        Equipment[EquipmentType.Shield] = Weapons.Generate(bonus, charClass, level, false, ref twoHanded);
            //    else if (Armor.CanWield(charClass, false))
            //        Equipment[EquipmentType.Shield] = Armor.GenerateShield(bonus, charClass, level);
            //}
            //progress.Text += Equipment[EquipmentType.Shield];

            ////Generate bracers
            //Application.DoEvents();
            //progress.Text += "\nGenerating bracers...";
            //bonus = BonusByChance(level * PercentageChance(charClass, EquipmentType.Bracers));
            //if (bonus > 0)
            //    Equipment[EquipmentType.Bracers] = String.Format("Bracers AC {0}", 10 - 2 * bonus);
            //progress.Text += Equipment[EquipmentType.Bracers];

            ////Generate rings of protection
            //Application.DoEvents();
            //progress.Text += "\nGenerating ring of protection...";
            //bonus = BonusByChance(level * PercentageChance(charClass, EquipmentType.RingOfProtection));
            //if (bonus > 0)
            //    Equipment[EquipmentType.RingOfProtection] = String.Format("Ring of Protection +{0}", bonus);
            //progress.Text += Equipment[EquipmentType.RingOfProtection];

            ////Generate potions.  Bonus is quantity
            //Application.DoEvents();
            //progress.Text += "\nGenerating potions...";
            //bonus = BonusByChance(level * PercentageChance(charClass, EquipmentType.Potion));
            //Equipment[EquipmentType.Potion] = MagicItems.Potion(MagicItems.PowerByLevel(level), bonus);
            //progress.Text += Equipment[EquipmentType.Potion];

            ////Generate scrolls.  Bonus is quantity
            //Application.DoEvents();
            //progress.Text += "\nGenerating scrolls...";
            //bonus = BonusByChance(level * PercentageChance(charClass, EquipmentType.Scroll));
            //Equipment[EquipmentType.Scroll] = Scrolls.Generate(charClass, level, bonus);
            //progress.Text += Equipment[EquipmentType.Scroll];

            ////Generate miscellaneous items.  Bonus is quantity
            //Application.DoEvents();
            //progress.Text += "\nGenerating miscellaneous items...";
            //bonus = BonusByChance(level * PercentageChance(charClass, EquipmentType.Miscellaneous));
            //if (bonus > 0)
            //    Equipment[EquipmentType.Miscellaneous] = MagicItems.Generate(MagicItems.PowerByLevel(level), bonus);
            //Equipment[EquipmentType.Miscellaneous] += "\n" + Treasure.MundaneItems();
            //if (Dice.Percentile() > 10)
            //{
            //    Equipment[EquipmentType.Miscellaneous] += "\nPack:";
            //    Equipment[EquipmentType.Miscellaneous] += String.Format("\n\tRations ({0} Days)", Dice.d8() - 1);
            //    Equipment[EquipmentType.Miscellaneous] += String.Format("\n\t{0}' rope", Dice.Percentile() / 2);
            //    Equipment[EquipmentType.Miscellaneous] += String.Format("\n\t{0} torches", Dice.d4() - 1);
            //    Equipment[EquipmentType.Miscellaneous] += String.Format("\n\tflint & steel");
            //    Equipment[EquipmentType.Miscellaneous] += String.Format("\n\twhetstone");
            //    Equipment[EquipmentType.Miscellaneous] += String.Format("\n\t{0} spikes", Dice.d4() - 1);
            //}
            //progress.Text += Equipment[EquipmentType.Miscellaneous];

            ////Generate money
            //Application.DoEvents();
            //progress.Text += "\nGenerating money, gems, and art objects...";
            //Equipment[EquipmentType.Money] = Treasure.Money(level);
            //progress.Text += Equipment[EquipmentType.Money];

            ////Generate spells
            //Application.DoEvents();
            //progress.Text += "\nGenerating spells...";
            //if (charClass == CLASS.BARD || charClass == CLASS.WIZARD || charClass == CLASS.CLERIC || charClass == CLASS.DRUID || charClass == CLASS.PALADIN || charClass == CLASS.RANGER || charClass == CLASS.SORCERER)
            //    Equipment[EquipmentType.Spells] = String.Format("{0} spells: {1}\n", charClass.ToString(), Classes.SpellString(charClass, level, StatScores[Stats.Intelligence], StatScores[Stats.Wisdom], StatScores[Stats.Charisma]));
            //progress.Text += Equipment[EquipmentType.Spells];

            ////Generate familiars
            //Application.DoEvents();
            //progress.Text += "\nGenerating familiars...";
            //Equipment[EquipmentType.Familiars] = Classes.Familiar(charClass, level);
            //progress.Text += Equipment[EquipmentType.Familiars];

            return character;
        }

        private void VerifyRandomizers(IAlignmentRandomizer alignmentRandomizer, IClassNameRandomizer classNameRandomizer,
            ILevelRandomizer levelRandomizer, IBaseRaceRandomizer baseRaceRandomizer, IMetaraceRandomizer metaraceRandomizer)
        {
            var verified = randomizerVerifier.VerifyCompatibility(alignmentRandomizer, classNameRandomizer, levelRandomizer,
                baseRaceRandomizer, metaraceRandomizer);

            if (!verified)
                throw new IncompatibleRandomizersException();
        }

        private Alignment GenerateAlignment(IAlignmentRandomizer alignmentRandomizer, IClassNameRandomizer classNameRandomizer,
            ILevelRandomizer levelRandomizer, IBaseRaceRandomizer baseRaceRandomizer, IMetaraceRandomizer metaraceRandomizer)
        {
            Alignment alignment;

            do alignment = alignmentGenerator.CreateWith(alignmentRandomizer);
            while (!randomizerVerifier.VerifyAlignmentCompatibility(alignment, classNameRandomizer, levelRandomizer, baseRaceRandomizer,
                metaraceRandomizer));

            return alignment;
        }

        private CharacterClassPrototype GenerateCharacterClassPrototype(IClassNameRandomizer classNameRandomizer, ILevelRandomizer levelRandomizer,
            Alignment alignment, IBaseRaceRandomizer baseRaceRandomizer, IMetaraceRandomizer metaraceRandomizer)
        {
            CharacterClassPrototype prototype;

            do prototype = characterClassGenerator.CreatePrototypeWith(alignment, levelRandomizer, classNameRandomizer);
            while (!randomizerVerifier.VerifyCharacterClassCompatibility(alignment.Goodness, prototype, baseRaceRandomizer, metaraceRandomizer));

            return prototype;
        }

        private Race GenerateRace(IBaseRaceRandomizer baseRaceRandomizer, IMetaraceRandomizer metaraceRandomizer, Dictionary<String, Int32> levelAdjustments, Alignment alignment, CharacterClassPrototype prototype)
        {
            Race race;

            do race = raceGenerator.CreateWith(alignment.Goodness, prototype, baseRaceRandomizer, metaraceRandomizer);
            while (levelAdjustments[race.BaseRace] + levelAdjustments[race.Metarace] >= prototype.Level);

            return race;
        }
    }
}