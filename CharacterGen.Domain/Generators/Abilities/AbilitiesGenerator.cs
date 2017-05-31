﻿using CharacterGen.Abilities;
using CharacterGen.CharacterClasses;
using CharacterGen.Domain.Selectors.Collections;
using CharacterGen.Domain.Selectors.Percentiles;
using CharacterGen.Domain.Tables;
using CharacterGen.Races;
using CharacterGen.Randomizers.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterGen.Domain.Generators.Abilities
{
    internal class AbilitiesGenerator : IAbilitiesGenerator
    {
        private IBooleanPercentileSelector booleanPercentileSelector;
        private IAbilityAdjustmentsSelector abilityAdjustmentsSelector;
        private IAdjustmentsSelector adjustmentsSelector;
        private ICollectionsSelector collectionsSelector;

        public AbilitiesGenerator(IBooleanPercentileSelector booleanPercentileSelector, IAbilityAdjustmentsSelector abilityAdjustmentsSelector, IAdjustmentsSelector adjustmentsSelector, ICollectionsSelector collectionsSelector)
        {
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.abilityAdjustmentsSelector = abilityAdjustmentsSelector;
            this.adjustmentsSelector = adjustmentsSelector;
            this.collectionsSelector = collectionsSelector;
        }

        public Dictionary<string, Ability> GenerateWith(IAbilitiesRandomizer abilitiesRandomizer, CharacterClass characterClass, Race race)
        {
            var abilities = abilitiesRandomizer.Randomize();

            if (CanAdjustAbilities(abilitiesRandomizer))
            {
                abilities = PrioritizeAbilities(abilities, characterClass);
                abilities = AdjustAbilities(race, abilities);
                abilities = SetMinimumAbilities(abilities);
                abilities = IncreaseAbilities(abilities, characterClass, race);
            }
            else
            {
                abilities = SetMinimumAbilities(abilities);
            }

            var undead = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.MetaraceGroups, GroupConstants.Undead);

            if (undead.Contains(race.Metarace))
                abilities.Remove(AbilityConstants.Constitution);

            return abilities;
        }

        private bool CanAdjustAbilities(IAbilitiesRandomizer abilitiesRandomizer)
        {
            if ((abilitiesRandomizer is ISetAbilitiesRandomizer) == false)
                return true;

            var setAbilitiesRandomizer = abilitiesRandomizer as ISetAbilitiesRandomizer;
            return setAbilitiesRandomizer.AllowAdjustments;
        }

        private Dictionary<string, Ability> PrioritizeAbilities(Dictionary<string, Ability> abilities, CharacterClass characterClass)
        {
            var abilityPriorities = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.AbilityPriorities, characterClass.Name);
            if (abilityPriorities.Any() == false)
                return abilities;

            var firstPriority = abilityPriorities.First();
            var max = abilities.Values.Max(s => s.Value);
            var maxAbility = abilities.Keys.First(k => abilities[k].Value == max);
            abilities = SwapAbilityValues(abilities, firstPriority, maxAbility);

            var secondPriorities = abilityPriorities.Skip(1);
            var nonPriorityAbilityNames = abilities.Keys.Except(abilityPriorities);

            while (secondPriorities.Any())
            {
                var priority = secondPriorities.First();
                var nonPriorityAbilities = abilities.Where(kvp => nonPriorityAbilityNames.Contains(kvp.Key));

                max = nonPriorityAbilities.Max(kvp => kvp.Value.Value);

                if (max > abilities[priority].Value)
                {
                    maxAbility = nonPriorityAbilityNames.First(s => abilities[s].Value == max);
                    abilities = SwapAbilityValues(abilities, priority, maxAbility);
                }

                secondPriorities = secondPriorities.Skip(1);
            }

            return abilities;
        }

        private Dictionary<string, Ability> SwapAbilityValues(Dictionary<string, Ability> abilities, string priorityAbility, string otherAbility)
        {
            var temp = abilities[otherAbility].Value;
            abilities[otherAbility].Value = abilities[priorityAbility].Value;
            abilities[priorityAbility].Value = temp;

            return abilities;
        }

        private Dictionary<string, Ability> AdjustAbilities(Race race, Dictionary<string, Ability> abilities)
        {
            var abilityAdjustments = abilityAdjustmentsSelector.SelectFor(race);

            foreach (var ability in abilities.Keys)
                abilities[ability].Value += abilityAdjustments[ability];

            return abilities;
        }

        private Dictionary<string, Ability> SetMinimumAbilities(Dictionary<string, Ability> abilities)
        {
            foreach (var ability in abilities.Values)
                ability.Value = Math.Max(ability.Value, 3);

            return abilities;
        }

        private Dictionary<string, Ability> IncreaseAbilities(Dictionary<string, Ability> abilities, CharacterClass characterClass, Race race)
        {
            var count = characterClass.Level / 4;

            while (count-- > 0)
            {
                var abilityToIncrease = GetAbilityToIncrease(abilities, race, characterClass);
                abilities[abilityToIncrease].Value++;
            }

            return abilities;
        }

        private string GetAbilityToIncrease(Dictionary<string, Ability> abilities, Race race, CharacterClass characterClass)
        {
            var abilityPriorities = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.AbilityPriorities, characterClass.Name);
            var undead = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.MetaraceGroups, GroupConstants.Undead);

            if (undead.Contains(race.Metarace))
                abilityPriorities = abilityPriorities.Except(new[] { AbilityConstants.Constitution });

            if (abilityPriorities.Any() == false)
            {
                var ability = collectionsSelector.SelectRandomFrom(abilities.Keys);

                while (undead.Contains(race.Metarace) && ability == AbilityConstants.Constitution)
                    ability = collectionsSelector.SelectRandomFrom(abilities.Keys);

                return ability;
            }

            var secondPriorityAbilities = abilityPriorities.Skip(1);
            if (secondPriorityAbilities.Any() == false)
                return abilityPriorities.First();

            var increaseFirst = booleanPercentileSelector.SelectFrom(TableNameConstants.Set.TrueOrFalse.IncreaseFirstPriorityAbility);

            if (increaseFirst)
                return abilityPriorities.First();

            return collectionsSelector.SelectRandomFrom(secondPriorityAbilities);
        }
    }
}