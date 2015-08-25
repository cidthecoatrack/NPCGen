﻿using CharacterGen.Common.Alignments;
using CharacterGen.Selectors;
using System;

namespace CharacterGen.Generators.Domain.Randomizers.Alignments
{
    public class NeutralAlignmentRandomizer : BaseAlignmentRandomizer
    {
        public NeutralAlignmentRandomizer(IPercentileSelector innerSelector)
            : base(innerSelector)
        { }

        protected override Boolean AlignmentIsAllowed(Alignment alignment)
        {
            return alignment.Goodness == AlignmentConstants.Neutral || alignment.Lawfulness == AlignmentConstants.Neutral;
        }
    }
}