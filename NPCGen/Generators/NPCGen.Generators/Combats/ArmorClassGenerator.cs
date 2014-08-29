﻿using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Common.Items;
using NPCGen.Common.Combats;
using NPCGen.Common.Items;
using NPCGen.Generators.Interfaces.Combats;
using NPCGen.Selectors.Interfaces;

namespace NPCGen.Generators.Combats
{
    public class ArmorClassGenerator : IArmorClassGenerator
    {
        private ICollectionsSelector collectionsSelector;
        private IAdjustmentsSelector adjustmentsSelector;

        public ArmorClassGenerator(ICollectionsSelector collectionsSelector, IAdjustmentsSelector adjustmentsSelector)
        {
            this.collectionsSelector = collectionsSelector;
            this.adjustmentsSelector = adjustmentsSelector;
        }

        public ArmorClass GenerateWith(Equipment equipment, Int32 adjustedDexterityBonus, IEnumerable<String> feats)
        {
            var armorBonuses = GetArmorBonuses(equipment);
            var sizeModifier = GetSizeModifier(feats);
            var deflectionBonus = GetDeflectionBonus(equipment.Treasure.Items);
            var naturalArmorBonus = GetNaturalArmorBonus(equipment.Treasure.Items, feats);
            var dodgeBonus = GetDodgeBonus(feats);

            var armorClass = new ArmorClass();
            armorClass.Full = 10 + armorBonuses + sizeModifier + deflectionBonus + naturalArmorBonus + adjustedDexterityBonus + dodgeBonus;
            armorClass.Touch = armorClass.Full - armorBonuses - naturalArmorBonus;
            armorClass.FlatFooted = armorClass.Full - adjustedDexterityBonus - dodgeBonus;

            return armorClass;
        }

        private Int32 GetArmorBonuses(Equipment equipment)
        {
            var armorBonus = GetArmorBonus(equipment.Armor);
            var shieldBonus = GetShieldBonus(equipment.OffHand);
            var armorEnhancementBonus = equipment.Armor.Magic.Bonus;
            var shieldEnhancementBonus = GetShieldEnhancementBonus(equipment.OffHand);
            return armorBonus + armorEnhancementBonus + shieldBonus + shieldEnhancementBonus;
        }

        private Int32 GetArmorBonus(Item armor)
        {
            var armorBonuses = adjustmentsSelector.SelectAdjustmentsFrom("ArmorBonuses");
            return armorBonuses[armor.Name];
        }

        private Int32 GetShieldBonus(Item offHand)
        {
            if (offHand.ItemType != ItemTypeConstants.Armor || !offHand.Attributes.Contains(AttributeConstants.Shield))
                return 0;

            var armorBonuses = adjustmentsSelector.SelectAdjustmentsFrom("ArmorBonuses");
            return armorBonuses[offHand.Name];
        }

        private Int32 GetShieldEnhancementBonus(Item offHand)
        {
            if (offHand.ItemType != ItemTypeConstants.Armor || !offHand.Attributes.Contains(AttributeConstants.Shield))
                return 0;

            return offHand.Magic.Bonus;
        }

        private Int32 GetSizeModifier(IEnumerable<String> feats)
        {
            var featAdjustments = adjustmentsSelector.SelectAdjustmentsFrom("FeatArmorAdjustments");
            var sizeModifiers = collectionsSelector.SelectFrom("ArmorClassModifiers", "Size");
            var modifier = 0;

            foreach (var feat in feats)
                if (sizeModifiers.Contains(feat))
                    modifier += featAdjustments[feat];

            return modifier;
        }

        private Int32 GetDeflectionBonus(IEnumerable<Item> items)
        {
            var deflectionBonuses = collectionsSelector.SelectFrom("ArmorClassModifiers", "Deflection");
            var itemsWithDeflectionBonuses = items.Where(i => deflectionBonuses.Contains(i.Name));

            if (!itemsWithDeflectionBonuses.Any())
                return 0;

            return itemsWithDeflectionBonuses.Max(i => i.Magic.Bonus);
        }

        private Int32 GetNaturalArmorBonus(IEnumerable<Item> items, IEnumerable<String> feats)
        {
            var thingsThatGrantNaturalArmorBonuses = collectionsSelector.SelectFrom("ArmorClassModifiers", "NaturalArmor");
            var itemsWithNaturalArmorBonuses = items.Where(i => thingsThatGrantNaturalArmorBonuses.Contains(i.Name));
            var itemNaturalArmorBonuses = itemsWithNaturalArmorBonuses.Select(i => i.Magic.Bonus);

            var featAdjustments = adjustmentsSelector.SelectAdjustmentsFrom("FeatArmorAdjustments");
            var featsWithNaturalArmorBonuses = feats.Where(f => thingsThatGrantNaturalArmorBonuses.Contains(f));
            var featNaturalArmorAdjustments = featAdjustments.Where(kvp => featsWithNaturalArmorBonuses.Contains(kvp.Key));
            var featNaturalArmorBonuses = featNaturalArmorAdjustments.Select(kvp => kvp.Value);

            var naturalArmorBonuses = featNaturalArmorBonuses.Union(itemNaturalArmorBonuses);
            if (!naturalArmorBonuses.Any())
                return 0;

            return naturalArmorBonuses.Max();
        }

        private Int32 GetDodgeBonus(IEnumerable<String> feats)
        {
            var featAdjustments = adjustmentsSelector.SelectAdjustmentsFrom("FeatArmorAdjustments");
            var dodgeBonuses = collectionsSelector.SelectFrom("ArmorClassModifiers", "Dodge");
            var bonus = 0;

            foreach (var feat in feats)
                if (dodgeBonuses.Contains(feat))
                    bonus += featAdjustments[feat];

            return bonus;
        }
    }
}