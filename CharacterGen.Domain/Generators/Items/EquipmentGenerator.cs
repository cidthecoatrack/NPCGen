﻿using CharacterGen.Abilities.Feats;
using CharacterGen.CharacterClasses;
using CharacterGen.Domain.Selectors.Collections;
using CharacterGen.Domain.Tables;
using CharacterGen.Items;
using CharacterGen.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Generators;
using TreasureGen.Items;

namespace CharacterGen.Domain.Generators.Items
{
    internal class EquipmentGenerator : IEquipmentGenerator
    {
        private ICollectionsSelector collectionsSelector;
        private IArmorGenerator armorGenerator;
        private IWeaponGenerator weaponGenerator;
        private ITreasureGenerator treasureGenerator;
        private Generator generator;

        public EquipmentGenerator(ICollectionsSelector collectionsSelector, IWeaponGenerator weaponGenerator,
            ITreasureGenerator treasureGenerator, IArmorGenerator armorGenerator, Generator generator)
        {
            this.collectionsSelector = collectionsSelector;
            this.armorGenerator = armorGenerator;
            this.weaponGenerator = weaponGenerator;
            this.treasureGenerator = treasureGenerator;
            this.generator = generator;
        }

        public Equipment GenerateWith(IEnumerable<Feat> feats, CharacterClass characterClass, Race race)
        {
            var equipment = new Equipment();
            var effectiveLevel = (int)Math.Max(1, characterClass.EffectiveLevel);

            equipment.Treasure = treasureGenerator.GenerateAtLevel(effectiveLevel);
            equipment.Armor = armorGenerator.GenerateArmorFrom(feats, characterClass, race);

            var twoWeaponFeats = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.FeatGroups, GroupConstants.TwoHanded);
            var hasTwoWeaponFeats = feats.Any(f => twoWeaponFeats.Contains(f.Name));

            if (hasTwoWeaponFeats)
            {
                equipment.PrimaryHand = weaponGenerator.GenerateOneHandedMeleeFrom(feats, characterClass, race);
                equipment.OffHand = weaponGenerator.GenerateOneHandedMeleeFrom(feats, characterClass, race);
            }

            if (equipment.PrimaryHand == null)
            {
                equipment.PrimaryHand = weaponGenerator.GenerateFrom(feats, characterClass, race);
            }

            if (equipment.PrimaryHand != null)
            {
                var ammunitionType = GetRequiredAmmunition(equipment.PrimaryHand);
                if (!string.IsNullOrEmpty(ammunitionType))
                {
                    var ammunition = weaponGenerator.GenerateAmmunition(characterClass, race, ammunitionType);

                    if (ammunition != null)
                        equipment.Treasure.Items = equipment.Treasure.Items.Union(new[] { ammunition });
                }

                if (equipment.PrimaryHand.Attributes.Contains(AttributeConstants.TwoHanded))
                    equipment.OffHand = equipment.PrimaryHand;

                if (equipment.PrimaryHand.Attributes.Contains(AttributeConstants.Melee) == false)
                {
                    var meleeWeapon = weaponGenerator.GenerateMeleeFrom(feats, characterClass, race);
                    if (meleeWeapon != null)
                    {
                        equipment.Treasure.Items = equipment.Treasure.Items.Union(new[] { meleeWeapon });

                        if (meleeWeapon.Attributes.Contains(AttributeConstants.TwoHanded) == false)
                        {
                            var shield = armorGenerator.GenerateShieldFrom(feats, characterClass, race);
                            if (shield != null)
                                equipment.Treasure.Items = equipment.Treasure.Items.Union(new[] { shield });
                        }
                    }
                }
                else
                {
                    var rangedWeapon = weaponGenerator.GenerateRangedFrom(feats, characterClass, race);
                    if (rangedWeapon != null)
                    {
                        equipment.Treasure.Items = equipment.Treasure.Items.Union(new[] { rangedWeapon });

                        ammunitionType = GetRequiredAmmunition(rangedWeapon);
                        if (!string.IsNullOrEmpty(ammunitionType))
                        {
                            var ammunition = weaponGenerator.GenerateAmmunition(characterClass, race, ammunitionType);

                            if (ammunition != null)
                                equipment.Treasure.Items = equipment.Treasure.Items.Union(new[] { ammunition });
                        }
                    }
                }
            }

            if (equipment.OffHand == null && (equipment.PrimaryHand == null || equipment.PrimaryHand.Attributes.Contains(AttributeConstants.Melee)))
                equipment.OffHand = armorGenerator.GenerateShieldFrom(feats, characterClass, race);

            return equipment;
        }

        private string GetRequiredAmmunition(Weapon weapon)
        {
            var arrowWeapons = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.ItemGroups, WeaponConstants.Arrow);
            if (arrowWeapons.Any(w => weapon.NameMatches(w)))
                return WeaponConstants.Arrow;

            var crossbowWeapons = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.ItemGroups, WeaponConstants.CrossbowBolt);
            if (crossbowWeapons.Any(w => weapon.NameMatches(w)))
                return WeaponConstants.CrossbowBolt;

            var slingWeapons = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.ItemGroups, WeaponConstants.SlingBullet);
            if (slingWeapons.Any(w => weapon.NameMatches(w)))
                return WeaponConstants.SlingBullet;

            return string.Empty;
        }
    }
}