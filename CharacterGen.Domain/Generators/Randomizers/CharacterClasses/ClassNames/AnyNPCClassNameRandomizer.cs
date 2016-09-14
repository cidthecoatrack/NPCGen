﻿using CharacterGen.Alignments;
using CharacterGen.Domain.Selectors.Collections;
using CharacterGen.Domain.Tables;
using CharacterGen.Randomizers.CharacterClasses;
using System.Collections.Generic;

namespace CharacterGen.Domain.Generators.Randomizers.CharacterClasses.ClassNames
{
    internal class AnyNPCClassNameRandomizer : IClassNameRandomizer
    {
        private ICollectionsSelector collectionsSelector;

        public AnyNPCClassNameRandomizer(ICollectionsSelector collectionsSelector)
        {
            this.collectionsSelector = collectionsSelector;
        }

        public string Randomize(Alignment alignment)
        {
            var npcs = GetAllPossibleResults(alignment);
            return collectionsSelector.SelectRandomFrom(npcs);
        }

        public IEnumerable<string> GetAllPossibleResults(Alignment alignment)
        {
            return collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.ClassNameGroups, GroupConstants.NPCs);
        }
    }
}