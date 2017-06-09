﻿using CharacterGen.Alignments;
using CharacterGen.CharacterClasses;
using CharacterGen.Races;
using CharacterGen.Randomizers.CharacterClasses;
using EventGen;
using System.Collections.Generic;

namespace CharacterGen.Domain.Generators.Classes
{
    internal class CharacterClassGeneratorEventGenDecorator : ICharacterClassGenerator
    {
        private readonly GenEventQueue eventQueue;
        private readonly ICharacterClassGenerator innerGenerator;

        public CharacterClassGeneratorEventGenDecorator(ICharacterClassGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.innerGenerator = innerGenerator;
            this.eventQueue = eventQueue;
        }

        public CharacterClass GenerateWith(Alignment alignment, ILevelRandomizer levelRandomizer, IClassNameRandomizer classNameRandomizer)
        {
            eventQueue.Enqueue("CharacterGen", $"Beginning class generation for {alignment.Full}");
            var characterClass = innerGenerator.GenerateWith(alignment, levelRandomizer, classNameRandomizer);
            eventQueue.Enqueue("CharacterGen", $"Completed generation of {characterClass.Summary}");

            return characterClass;
        }

        public IEnumerable<string> RegenerateSpecialistFields(Alignment alignment, CharacterClass characterClass, Race race)
        {
            eventQueue.Enqueue("CharacterGen", $"Regenerating specialist fields for {alignment.Full} {characterClass.Summary} {race.Summary}");
            var specialistFields = innerGenerator.RegenerateSpecialistFields(alignment, characterClass, race);
            eventQueue.Enqueue("CharacterGen", $"Completed regeneration of specialist fields: {string.Join(", ", specialistFields)}");

            return specialistFields;
        }
    }
}