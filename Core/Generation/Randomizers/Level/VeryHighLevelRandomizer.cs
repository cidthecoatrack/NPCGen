﻿using D20Dice.Dice;

namespace NPCGen.Core.Generation.Randomizers.Level
{
    public class VeryHighLevelRandomizer : RangedLevelRandomizer
    {
        public VeryHighLevelRandomizer(IDice dice)
            : base(dice)
        {
            rollBonus = 15;
        }
    }
}