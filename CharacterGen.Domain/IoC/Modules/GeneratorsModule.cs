﻿using CharacterGen.Characters;
using CharacterGen.Domain.Generators;
using CharacterGen.Domain.Generators.Abilities;
using CharacterGen.Domain.Generators.Alignments;
using CharacterGen.Domain.Generators.Characters;
using CharacterGen.Domain.Generators.Classes;
using CharacterGen.Domain.Generators.Combats;
using CharacterGen.Domain.Generators.Feats;
using CharacterGen.Domain.Generators.Items;
using CharacterGen.Domain.Generators.Languages;
using CharacterGen.Domain.Generators.Magics;
using CharacterGen.Domain.Generators.Races;
using CharacterGen.Domain.Generators.Randomizers.Abilities;
using CharacterGen.Domain.Generators.Randomizers.Alignments;
using CharacterGen.Domain.Generators.Randomizers.CharacterClasses.ClassNames;
using CharacterGen.Domain.Generators.Randomizers.CharacterClasses.Levels;
using CharacterGen.Domain.Generators.Randomizers.Races.BaseRaces;
using CharacterGen.Domain.Generators.Randomizers.Races.Metaraces;
using CharacterGen.Domain.Generators.Skills;
using CharacterGen.Domain.Generators.Verifiers;
using CharacterGen.Leaders;
using CharacterGen.Randomizers.Abilities;
using CharacterGen.Randomizers.Alignments;
using CharacterGen.Randomizers.CharacterClasses;
using CharacterGen.Randomizers.Races;
using CharacterGen.Verifiers;
using Ninject;
using Ninject.Modules;

namespace CharacterGen.Domain.IoC.Modules
{
    internal class GeneratorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRandomizerVerifier>().To<RandomizerVerifier>();

            Bind<IHitPointsGenerator>().To<HitPointsGenerator>();
            Bind<ILeadershipGenerator>().To<LeadershipGenerator>();
            Bind<IArmorClassGenerator>().To<ArmorClassGenerator>();
            Bind<ISavingThrowsGenerator>().To<SavingThrowsGenerator>();
            Bind<IArmorGenerator>().To<ArmorGenerator>();
            Bind<IWeaponGenerator>().To<WeaponGenerator>();
            Bind<ISpellsGenerator>().To<SpellsGenerator>();
            Bind<IAnimalGenerator>().To<AnimalGenerator>();

            BindDecoratedGenerators();
            BindRandomizers();
        }

        private void BindDecoratedGenerators()
        {
            Bind<ICharacterGenerator>().To<CharacterGenerator>().WhenInjectedInto<CharacterGeneratorEventGenDecorator>();
            Bind<ICharacterGenerator>().To<CharacterGeneratorEventGenDecorator>();

            Bind<IAlignmentGenerator>().To<AlignmentGenerator>().WhenInjectedInto<AlignmentGeneratorEventGenDecorator>();
            Bind<IAlignmentGenerator>().To<AlignmentGeneratorEventGenDecorator>();

            Bind<ICharacterClassGenerator>().To<CharacterClassGenerator>().WhenInjectedInto<CharacterClassGeneratorEventGenDecorator>();
            Bind<ICharacterClassGenerator>().To<CharacterClassGeneratorEventGenDecorator>();

            Bind<IRaceGenerator>().To<RaceGenerator>().WhenInjectedInto<RaceGeneratorEventGenDecorator>();
            Bind<IRaceGenerator>().To<RaceGeneratorEventGenDecorator>();

            Bind<IAbilitiesGenerator>().To<AbilitiesGenerator>().WhenInjectedInto<AbilitiesGeneratorEventGenDecorator>();
            Bind<IAbilitiesGenerator>().To<AbilitiesGeneratorEventGenDecorator>();

            Bind<ICombatGenerator>().To<CombatGenerator>().WhenInjectedInto<CombatGeneratorEventGenDecorator>();
            Bind<ICombatGenerator>().To<CombatGeneratorEventGenDecorator>();

            Bind<ISkillsGenerator>().To<SkillsGenerator>().WhenInjectedInto<SkillsGeneratorEventGenDecorator>();
            Bind<ISkillsGenerator>().To<SkillsGeneratorEventGenDecorator>();

            Bind<IFeatsGenerator>().To<FeatsGenerator>().WhenInjectedInto<FeatsGeneratorEventGenDecorator>();
            Bind<IFeatsGenerator>().To<FeatsGeneratorEventGenDecorator>();

            Bind<IAdditionalFeatsGenerator>().To<AdditionalFeatsGenerator>().WhenInjectedInto<AdditionalFeatsGeneratorEventGenDecorator>();
            Bind<IAdditionalFeatsGenerator>().To<AdditionalFeatsGeneratorEventGenDecorator>();

            Bind<IClassFeatsGenerator>().To<ClassFeatsGenerator>().WhenInjectedInto<ClassFeatsGeneratorEventGenDecorator>();
            Bind<IClassFeatsGenerator>().To<ClassFeatsGeneratorEventGenDecorator>();

            Bind<IRacialFeatsGenerator>().To<RacialFeatsGenerator>().WhenInjectedInto<RacialFeatsGeneratorEventGenDecorator>();
            Bind<IRacialFeatsGenerator>().To<RacialFeatsGeneratorEventGenDecorator>();

            Bind<IFeatFocusGenerator>().To<FeatFocusGenerator>().WhenInjectedInto<FeatFocusGeneratorEventGenDecorator>();
            Bind<IFeatFocusGenerator>().To<FeatFocusGeneratorEventGenDecorator>();

            Bind<ILanguageGenerator>().To<LanguageGenerator>().WhenInjectedInto<LanguageGeneratorEventGenDecorator>();
            Bind<ILanguageGenerator>().To<LanguageGeneratorEventGenDecorator>();

            Bind<IEquipmentGenerator>().To<EquipmentGenerator>().WhenInjectedInto<EquipmentGeneratorEventGenDecorator>();
            Bind<IEquipmentGenerator>().To<EquipmentGeneratorEventGenDecorator>();

            Bind<IMagicGenerator>().To<MagicGenerator>().WhenInjectedInto<MagicGeneratorEventGenDecorator>();
            Bind<IMagicGenerator>().To<MagicGeneratorEventGenDecorator>();
        }

        private void BindRandomizers()
        {
            Bind<IAlignmentRandomizer>().To<AnyAlignmentRandomizer>().Named(AlignmentRandomizerTypeConstants.Any);
            Bind<IAlignmentRandomizer>().To<ChaoticAlignmentRandomizer>().Named(AlignmentRandomizerTypeConstants.Chaotic);
            Bind<IAlignmentRandomizer>().To<EvilAlignmentRandomizer>().Named(AlignmentRandomizerTypeConstants.Evil);
            Bind<IAlignmentRandomizer>().To<GoodAlignmentRandomizer>().Named(AlignmentRandomizerTypeConstants.Good);
            Bind<IAlignmentRandomizer>().To<LawfulAlignmentRandomizer>().Named(AlignmentRandomizerTypeConstants.Lawful);
            Bind<IAlignmentRandomizer>().To<NeutralAlignmentRandomizer>().Named(AlignmentRandomizerTypeConstants.Neutral);
            Bind<IAlignmentRandomizer>().To<NonChaoticAlignmentRandomizer>().Named(AlignmentRandomizerTypeConstants.NonChaotic);
            Bind<IAlignmentRandomizer>().To<NonEvilAlignmentRandomizer>().Named(AlignmentRandomizerTypeConstants.NonEvil);
            Bind<IAlignmentRandomizer>().To<NonGoodAlignmentRandomizer>().Named(AlignmentRandomizerTypeConstants.NonGood);
            Bind<IAlignmentRandomizer>().To<NonLawfulAlignmentRandomizer>().Named(AlignmentRandomizerTypeConstants.NonLawful);
            Bind<IAlignmentRandomizer>().To<NonNeutralAlignmentRandomizer>().Named(AlignmentRandomizerTypeConstants.NonNeutral);

            Bind<IClassNameRandomizer>().To<AnyPlayerClassNameRandomizer>().Named(ClassNameRandomizerTypeConstants.AnyPlayer);
            Bind<IClassNameRandomizer>().To<AnyNPCClassNameRandomizer>().Named(ClassNameRandomizerTypeConstants.AnyNPC);
            Bind<IClassNameRandomizer>().To<DivineSpellcasterClassNameRandomizer>().Named(ClassNameRandomizerTypeConstants.DivineSpellcaster);
            Bind<IClassNameRandomizer>().To<ArcaneSpellcasterClassNameRandomizer>().Named(ClassNameRandomizerTypeConstants.ArcaneSpellcaster);
            Bind<IClassNameRandomizer>().To<NonSpellcasterClassNameRandomizer>().Named(ClassNameRandomizerTypeConstants.NonSpellcaster);
            Bind<IClassNameRandomizer>().To<SpellcasterClassNameRandomizer>().Named(ClassNameRandomizerTypeConstants.Spellcaster);
            Bind<IClassNameRandomizer>().To<StealthClassNameRandomizer>().Named(ClassNameRandomizerTypeConstants.Stealth);
            Bind<IClassNameRandomizer>().To<PhysicalCombatClassNameRandomizer>().Named(ClassNameRandomizerTypeConstants.PhysicalCombat);

            Bind<ILevelRandomizer>().To<AnyLevelRandomizer>().Named(LevelRandomizerTypeConstants.Any);
            Bind<ILevelRandomizer>().To<HighLevelRandomizer>().Named(LevelRandomizerTypeConstants.High);
            Bind<ILevelRandomizer>().To<LowLevelRandomizer>().Named(LevelRandomizerTypeConstants.Low);
            Bind<ILevelRandomizer>().To<MediumLevelRandomizer>().Named(LevelRandomizerTypeConstants.Medium);
            Bind<ILevelRandomizer>().To<VeryHighLevelRandomizer>().Named(LevelRandomizerTypeConstants.VeryHigh);

            Bind<RaceRandomizer>().To<AnyBaseRaceRandomizer>().Named(RaceRandomizerTypeConstants.BaseRace.AnyBase);
            Bind<RaceRandomizer>().To<AquaticBaseRaceRandomizer>().Named(RaceRandomizerTypeConstants.BaseRace.AquaticBase);
            Bind<RaceRandomizer>().To<MonsterBaseRaceRandomizer>().Named(RaceRandomizerTypeConstants.BaseRace.MonsterBase);
            Bind<RaceRandomizer>().To<NonMonsterBaseRaceRandomizer>().Named(RaceRandomizerTypeConstants.BaseRace.NonMonsterBase);
            Bind<RaceRandomizer>().To<NonStandardBaseRaceRandomizer>().Named(RaceRandomizerTypeConstants.BaseRace.NonStandardBase);
            Bind<RaceRandomizer>().To<StandardBaseRaceRandomizer>().Named(RaceRandomizerTypeConstants.BaseRace.StandardBase);

            Bind<IForcableMetaraceRandomizer>().To<AnyMetaraceRandomizer>().Named(RaceRandomizerTypeConstants.Metarace.AnyMeta);
            Bind<IForcableMetaraceRandomizer>().To<GeneticMetaraceRandomizer>().Named(RaceRandomizerTypeConstants.Metarace.GeneticMeta);
            Bind<IForcableMetaraceRandomizer>().To<LycanthropeMetaraceRandomizer>().Named(RaceRandomizerTypeConstants.Metarace.LycanthropeMeta);
            Bind<IForcableMetaraceRandomizer>().To<UndeadMetaraceRandomizer>().Named(RaceRandomizerTypeConstants.Metarace.UndeadMeta);

            Bind<RaceRandomizer>().ToMethod(c => c.Kernel.Get<IForcableMetaraceRandomizer>(RaceRandomizerTypeConstants.Metarace.AnyMeta)).Named(RaceRandomizerTypeConstants.Metarace.AnyMeta);
            Bind<RaceRandomizer>().ToMethod(c => c.Kernel.Get<IForcableMetaraceRandomizer>(RaceRandomizerTypeConstants.Metarace.GeneticMeta)).Named(RaceRandomizerTypeConstants.Metarace.GeneticMeta);
            Bind<RaceRandomizer>().ToMethod(c => c.Kernel.Get<IForcableMetaraceRandomizer>(RaceRandomizerTypeConstants.Metarace.LycanthropeMeta)).Named(RaceRandomizerTypeConstants.Metarace.LycanthropeMeta);
            Bind<RaceRandomizer>().ToMethod(c => c.Kernel.Get<IForcableMetaraceRandomizer>(RaceRandomizerTypeConstants.Metarace.UndeadMeta)).Named(RaceRandomizerTypeConstants.Metarace.UndeadMeta);
            Bind<RaceRandomizer>().To<NoMetaraceRandomizer>().Named(RaceRandomizerTypeConstants.Metarace.NoMeta);

            Bind<IAbilitiesRandomizer>().To<AverageAbilitiesRandomizer>().Named(AbilitiesRandomizerTypeConstants.Average);
            Bind<IAbilitiesRandomizer>().To<BestOfFourAbilitiesRandomizer>().Named(AbilitiesRandomizerTypeConstants.BestOfFour);
            Bind<IAbilitiesRandomizer>().To<GoodAbilitiesRandomizer>().Named(AbilitiesRandomizerTypeConstants.Good);
            Bind<IAbilitiesRandomizer>().To<HeroicAbilitiesRandomizer>().Named(AbilitiesRandomizerTypeConstants.Heroic);
            Bind<IAbilitiesRandomizer>().To<OnesAsSixesAbilitiesRandomizer>().Named(AbilitiesRandomizerTypeConstants.OnesAsSixes);
            Bind<IAbilitiesRandomizer>().To<PoorAbilitiesRandomizer>().Named(AbilitiesRandomizerTypeConstants.Poor);
            Bind<IAbilitiesRandomizer>().To<RawAbilitiesRandomizer>().Named(AbilitiesRandomizerTypeConstants.Raw);
            Bind<IAbilitiesRandomizer>().To<TwoTenSidedDiceAbilitiesRandomizer>().Named(AbilitiesRandomizerTypeConstants.TwoTenSidedDice);

            Bind<ISetAlignmentRandomizer>().To<SetAlignmentRandomizer>();
            Bind<ISetClassNameRandomizer>().To<SetClassNameRandomizer>();
            Bind<ISetLevelRandomizer>().To<SetLevelRandomizer>();
            Bind<ISetBaseRaceRandomizer>().To<SetBaseRaceRandomizer>();
            Bind<ISetMetaraceRandomizer>().To<SetMetaraceRandomizer>();
            Bind<ISetAbilitiesRandomizer>().To<SetAbilitiesRandomizer>();
        }
    }
}