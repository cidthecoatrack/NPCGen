﻿using CharacterGen.Characters;
using CharacterGen.Randomizers.Abilities;
using CharacterGen.Randomizers.Alignments;
using CharacterGen.Randomizers.CharacterClasses;
using CharacterGen.Randomizers.Races;
using EventGen;

namespace CharacterGen.Domain.Generators.Characters
{
    internal class CharacterGeneratorEventGenDecorator : ICharacterGenerator
    {
        private readonly GenEventQueue eventQueue;
        private readonly ICharacterGenerator innerGenerator;

        public CharacterGeneratorEventGenDecorator(ICharacterGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.innerGenerator = innerGenerator;
            this.eventQueue = eventQueue;
        }

        public CharacterPrototype GeneratePrototypeWith(IAlignmentRandomizer alignmentRandomizer, IClassNameRandomizer classNameRandomizer, ILevelRandomizer levelRandomizer, RaceRandomizer baseRaceRandomizer, RaceRandomizer metaraceRandomizer)
        {
            var prototype = innerGenerator.GeneratePrototypeWith(alignmentRandomizer, classNameRandomizer, levelRandomizer, baseRaceRandomizer, metaraceRandomizer);

            return prototype;
        }

        public Character GenerateWith(IAlignmentRandomizer alignmentRandomizer, IClassNameRandomizer classNameRandomizer, ILevelRandomizer levelRandomizer, RaceRandomizer baseRaceRandomizer, RaceRandomizer metaraceRandomizer, IAbilitiesRandomizer statsRandomizer)
        {
            eventQueue.Enqueue("CharacterGen", "Generating character");
            var character = innerGenerator.GenerateWith(alignmentRandomizer, classNameRandomizer, levelRandomizer, baseRaceRandomizer, metaraceRandomizer, statsRandomizer);
            eventQueue.Enqueue("CharacterGen", $"Generated {character.Summary}");

            return character;
        }
    }
}
