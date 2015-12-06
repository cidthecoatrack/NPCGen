﻿using CharacterGen.Common.Abilities.Feats;
using CharacterGen.Common.CharacterClasses;
using CharacterGen.Common.Races;
using System.Collections.Generic;
using TreasureGen.Common.Items;

namespace CharacterGen.Generators.Items
{
    public interface IArmorGenerator
    {
        Item GenerateArmorFrom(IEnumerable<Feat> feats, CharacterClass characterClass, Race race);
        Item GenerateShieldFrom(IEnumerable<Feat> feats, CharacterClass characterClass, Race race);
    }
}