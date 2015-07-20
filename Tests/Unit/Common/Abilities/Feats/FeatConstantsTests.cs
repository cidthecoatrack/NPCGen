﻿using System;
using NPCGen.Common.Abilities.Feats;
using NUnit.Framework;

namespace NPCGen.Tests.Unit.Common.Abilities.Feats
{
    [TestFixture]
    public class FeatConstantsTests
    {
        [TestCase(FeatConstants.AbundantStep, "Abundant Step")]
        [TestCase(FeatConstants.Acrobatic, "Acrobatic")]
        [TestCase(FeatConstants.Agile, "Agile")]
        [TestCase(FeatConstants.Alertness, "Alertness")]
        [TestCase(FeatConstants.AlternateForm, "Alternate Form")]
        [TestCase(FeatConstants.AnimalAffinity, "Animal Affinity")]
        [TestCase(FeatConstants.ArmorBonus, "Armor Bonus")]
        [TestCase(FeatConstants.Athletic, "Athletic")]
        [TestCase(FeatConstants.AttackBonus, "Attack Bonus")]
        [TestCase(FeatConstants.AugmentSummoning, "Augment Summoning")]
        [TestCase(FeatConstants.BardicKnowledge, "Bardic Knowledge")]
        [TestCase(FeatConstants.BardicMusic, "Bardic Music")]
        [TestCase(FeatConstants.BlindFight, "Blind-Fight")]
        [TestCase(FeatConstants.Camouflage, "Camouflage")]
        [TestCase(FeatConstants.CastSpellBonus, "Cast Spell Bonus")]
        [TestCase(FeatConstants.ChangeShape, "Change Shape")]
        [TestCase(FeatConstants.Cleave, "Cleave")]
        [TestCase(FeatConstants.CombatCasting, "Combat Casting")]
        [TestCase(FeatConstants.CombatExpertise, "Combat Expertise")]
        [TestCase(FeatConstants.CombatReflexes, "Combat Reflexes")]
        [TestCase(FeatConstants.CombatStyle, "Combat Style")]
        [TestCase(FeatConstants.CombatStyleMastery, "Combat Style Mastery")]
        [TestCase(FeatConstants.Countersong, "Countersong")]
        [TestCase(FeatConstants.CripplingStrike, "Crippling Strike")]
        [TestCase(FeatConstants.DamageReduction, "Damage Reduction")]
        [TestCase(FeatConstants.Darkvision, "Darkvision")]
        [TestCase(FeatConstants.DeathTouch, "Death Touch")]
        [TestCase(FeatConstants.Deceitful, "Deceitful")]
        [TestCase(FeatConstants.DefensiveRoll, "Defensive Roll")]
        [TestCase(FeatConstants.DeflectArrows, "Deflect Arrows")]
        [TestCase(FeatConstants.DeftHands, "Deft Hands")]
        [TestCase(FeatConstants.DiamondBody, "Diamond Body")]
        [TestCase(FeatConstants.DiamondSoul, "Diamond Soul")]
        [TestCase(FeatConstants.Diehard, "Diehard")]
        [TestCase(FeatConstants.Diligent, "Diligent")]
        [TestCase(FeatConstants.Disease, "Disease")]
        [TestCase(FeatConstants.Dodge, "Dodge")]
        [TestCase(FeatConstants.DodgeBonus, "Dodge Bonus")]
        [TestCase(FeatConstants.ElvenBlood, "Elven Blood")]
        [TestCase(FeatConstants.Empathy, "Empathy")]
        [TestCase(FeatConstants.EmpowerSpell, "Empower Spell")]
        [TestCase(FeatConstants.EmptyBody, "Empty Body")]
        [TestCase(FeatConstants.Endurance, "Endurance")]
        [TestCase(FeatConstants.EnlargeSpell, "Enlarge Spell")]
        [TestCase(FeatConstants.EschewMaterials, "Eschew Materials")]
        [TestCase(FeatConstants.Evasion, "Evasion")]
        [TestCase(FeatConstants.ExoticWeaponProficiency, "Exotic Weapon Proficiency")]
        [TestCase(FeatConstants.ExtendSpell, "Extend Spell")]
        [TestCase(FeatConstants.ExtraTurning, "Extra Turning")]
        [TestCase(FeatConstants.Extract, "Extract")]
        [TestCase(FeatConstants.FarShot, "Far Shot")]
        [TestCase(FeatConstants.Fascinate, "Fascinate")]
        [TestCase(FeatConstants.FastMovement, "Fast Movement")]
        [TestCase(FeatConstants.FavoredEnemy, "Favored Enemy")]
        [TestCase(FeatConstants.Ferocity, "Ferocity")]
        [TestCase(FeatConstants.Flight, "Flight")]
        [TestCase(FeatConstants.FlurryOfBlows, "Flurry of Blows")]
        [TestCase(FeatConstants.GoodFortune, "Good Fortune")]
        [TestCase(FeatConstants.GreatCleave, "Great Cleave")]
        [TestCase(FeatConstants.GreatFortitude, "Great Fortitude")]
        [TestCase(FeatConstants.GreaterRage, "Greater Rage")]
        [TestCase(FeatConstants.GreaterSpellFocus, "Greater Spell Focus")]
        [TestCase(FeatConstants.GreaterSpellPenetration, "Greater Spell Penetration")]
        [TestCase(FeatConstants.GreaterTurning, "Greater Turning")]
        [TestCase(FeatConstants.GreaterTwoWeaponFighting, "Greater Two-Weapon Fighting")]
        [TestCase(FeatConstants.GreaterWeaponFocus, "Greater Weapon Focus")]
        [TestCase(FeatConstants.GreaterWeaponSpecialization, "Greater Weapon Specialization")]
        [TestCase(FeatConstants.HeavyArmorProficiency, "Heavy Armor Proficiency")]
        [TestCase(FeatConstants.HeightenSpell, "Heighten Spell")]
        [TestCase(FeatConstants.HideInPlainSight, "Hide in Plain Sight")]
        [TestCase(FeatConstants.HoldBreath, "Hold Breath")]
        [TestCase(FeatConstants.Illiteracy, "Illiteracy")]
        [TestCase(FeatConstants.ImmuneToEffect, "Immune to Effect")]
        [TestCase(FeatConstants.ImprovedBullRush, "Improved Bull Rush")]
        [TestCase(FeatConstants.ImprovedCombatStyle, "Improved Combat Style")]
        [TestCase(FeatConstants.ImprovedCounterspell, "Improved Counterspell")]
        [TestCase(FeatConstants.ImprovedCritical, "Improved Critical")]
        [TestCase(FeatConstants.ImprovedDisarm, "Improved Disarm")]
        [TestCase(FeatConstants.ImprovedEvasion, "Improved Evasion")]
        [TestCase(FeatConstants.ImprovedFamiliar, "Improved Familiar")]
        [TestCase(FeatConstants.ImprovedFeint, "Improved Feint")]
        [TestCase(FeatConstants.ImprovedGrab, "Improved Grab")]
        [TestCase(FeatConstants.ImprovedGrapple, "Improved Grapple")]
        [TestCase(FeatConstants.ImprovedInitiative, "Improved Initiative")]
        [TestCase(FeatConstants.ImprovedOverrun, "Improved Overrun")]
        [TestCase(FeatConstants.ImprovedPreciseShot, "Improved Precise Shot")]
        [TestCase(FeatConstants.ImprovedShieldBash, "Improved Shield Bash")]
        [TestCase(FeatConstants.ImprovedSpell, "Improved Spell")]
        [TestCase(FeatConstants.ImprovedSunder, "Improved Sunder")]
        [TestCase(FeatConstants.ImprovedTrip, "Improved Trip")]
        [TestCase(FeatConstants.ImprovedTurning, "Improved Turning")]
        [TestCase(FeatConstants.ImprovedTwoWeaponFighting, "Improved Two-Weapon Fighting")]
        [TestCase(FeatConstants.ImprovedUnarmedStrike, "Improved Unarmed Strike")]
        [TestCase(FeatConstants.ImprovedUncannyDodge, "Improved Uncanny Dodge")]
        [TestCase(FeatConstants.IndomitableWill, "Indomitable Will")]
        [TestCase(FeatConstants.InspireCompetence, "Inspire Competence")]
        [TestCase(FeatConstants.InspireCourage, "Inspire Courage")]
        [TestCase(FeatConstants.InspireGreatness, "Inspire Greatness")]
        [TestCase(FeatConstants.InspireHeroics, "Inspire Heroics")]
        [TestCase(FeatConstants.Investigator, "Investigator")]
        [TestCase(FeatConstants.IronWill, "Iron Will")]
        [TestCase(FeatConstants.KiStrike, "Ki Strike")]
        [TestCase(FeatConstants.Leadership, "Leadership")]
        [TestCase(FeatConstants.LightArmorProficiency, "Light Armor Proficiency")]
        [TestCase(FeatConstants.LightBlindness, "Light Blindness")]
        [TestCase(FeatConstants.LightSensitivity, "Light Sensitivity")]
        [TestCase(FeatConstants.LightningReflexes, "Lightning Reflexes")]
        [TestCase(FeatConstants.LowLightVision, "Low-Light Vision")]
        [TestCase(FeatConstants.Lycanthropy, "Lycanthropy")]
        [TestCase(FeatConstants.Madness, "Madness")]
        [TestCase(FeatConstants.MagicalAptitude, "Magical Aptitude")]
        [TestCase(FeatConstants.MagicNaturalWeapons, "Magic Natural Weapons")]
        [TestCase(FeatConstants.Manyshot, "Manyshot")]
        [TestCase(FeatConstants.MartialWeaponProficiency, "Martial Weapon Proficiency")]
        [TestCase(FeatConstants.MassSuggestion, "Mass Suggestion")]
        [TestCase(FeatConstants.MaximizeSpell, "Maximize Spell")]
        [TestCase(FeatConstants.MediumArmorProficiency, "Medium Armor Proficiency")]
        [TestCase(FeatConstants.MightyRage, "Mighty Rage")]
        [TestCase(FeatConstants.MindBlast, "Mind Blast")]
        [TestCase(FeatConstants.Mobility, "Mobility")]
        [TestCase(FeatConstants.MonkBonusFeat, "Monk Bonus Feat")]
        [TestCase(FeatConstants.MonkUnarmedStrike, "Monk Unarmed Strike")]
        [TestCase(FeatConstants.MountedArchery, "Mounted Archery")]
        [TestCase(FeatConstants.MountedCombat, "Mounted Combat")]
        [TestCase(FeatConstants.NaturalArmor, "Natural Armor")]
        [TestCase(FeatConstants.NaturalCunning, "Natural Cunning")]
        [TestCase(FeatConstants.NaturalSpell, "Natural Spell")]
        [TestCase(FeatConstants.NaturalWeapon, "Natural Weapon")]
        [TestCase(FeatConstants.Negotiator, "Negotiator")]
        [TestCase(FeatConstants.NimbleFingers, "Nimble Fingers")]
        [TestCase(FeatConstants.Opportunist, "Opportunist")]
        [TestCase(FeatConstants.OrcBlood, "Orc Blood")]
        [TestCase(FeatConstants.PassWithoutTrace, "Pass Without Trace")]
        [TestCase(FeatConstants.PassiveSecretDoorSearch, "Passive Secret Door Search")]
        [TestCase(FeatConstants.PerfectSelf, "Perfect Self")]
        [TestCase(FeatConstants.Persuasive, "Persuasive")]
        [TestCase(FeatConstants.PointBlankShot, "Point Blank Shot")]
        [TestCase(FeatConstants.PoisonUse, "Poison Use")]
        [TestCase(FeatConstants.Pounce, "Pounce")]
        [TestCase(FeatConstants.PowerAttack, "Power Attack")]
        [TestCase(FeatConstants.PowerfulCharge, "Powerful Charge")]
        [TestCase(FeatConstants.PreciseShot, "Precise Shot")]
        [TestCase(FeatConstants.PurityOfBody, "Purity of Body")]
        [TestCase(FeatConstants.QuickDraw, "Quick Draw")]
        [TestCase(FeatConstants.QuickenSpell, "Quicken Spell")]
        [TestCase(FeatConstants.QuiveringPalm, "Quivering Palm")]
        [TestCase(FeatConstants.Rage, "Rage")]
        [TestCase(FeatConstants.Rake, "Rake")]
        [TestCase(FeatConstants.RapidReload, "Rapid Reload")]
        [TestCase(FeatConstants.RapidShot, "Rapid Shot")]
        [TestCase(FeatConstants.Regeneration, "Regeneration")]
        [TestCase(FeatConstants.Resistance, "Resistance")]
        [TestCase(FeatConstants.RideByAttack, "Ride-By Attack")]
        [TestCase(FeatConstants.Run, "Run")]
        [TestCase(FeatConstants.SaveBonus, "Save Bonus")]
        [TestCase(FeatConstants.Scent, "Scent")]
        [TestCase(FeatConstants.ScribeScroll, "Scribe Scroll")]
        [TestCase(FeatConstants.SelfSufficient, "Self-Sufficient")]
        [TestCase(FeatConstants.ShieldProficiency, "Shield Proficiency")]
        [TestCase(FeatConstants.ShotOnTheRun, "Shot On The Run")]
        [TestCase(FeatConstants.SilentSpell, "Silent Spell")]
        [TestCase(FeatConstants.SimpleWeaponProficiency, "Simple Weapon Proficiency")]
        [TestCase(FeatConstants.SkillBonus, "Skill Bonus")]
        [TestCase(FeatConstants.SkillFocus, "Skill Focus")]
        [TestCase(FeatConstants.SkillMastery, "Skill Mastery")]
        [TestCase(FeatConstants.SlipperyMind, "Slippery Mind")]
        [TestCase(FeatConstants.SlowFall, "Slow Fall")]
        [TestCase(FeatConstants.Smite, "Smite")]
        [TestCase(FeatConstants.SmiteEvil, "Smite Evil")]
        [TestCase(FeatConstants.SmiteGood, "Smite Good")]
        [TestCase(FeatConstants.SnatchArrows, "Snatch Arrows")]
        [TestCase(FeatConstants.SneakAttack, "Sneak Attack")]
        [TestCase(FeatConstants.SongOfFreedom, "Song of Freedom")]
        [TestCase(FeatConstants.SpellFocus, "Spell Focus")]
        [TestCase(FeatConstants.SpellLikeAbility, "Spell-Like Ability")]
        [TestCase(FeatConstants.SpellMastery, "Spell Mastery")]
        [TestCase(FeatConstants.SpellPenetration, "Spell Penetration")]
        [TestCase(FeatConstants.SpellResistance, "Spell Resistance")]
        [TestCase(FeatConstants.SpellStrength, "Spell Strength")]
        [TestCase(FeatConstants.SpiritedCharge, "Spirited Charge")]
        [TestCase(FeatConstants.SpringAttack, "Spring Attack")]
        [TestCase(FeatConstants.Stability, "Stability")]
        [TestCase(FeatConstants.Stealthy, "Stealthy")]
        [TestCase(FeatConstants.Stench, "Stench")]
        [TestCase(FeatConstants.StillMind, "Still Mind")]
        [TestCase(FeatConstants.StillSpell, "Still Spell")]
        [TestCase(FeatConstants.Stonecunning, "Stonecunning")]
        [TestCase(FeatConstants.StunningFist, "Stunning Fist")]
        [TestCase(FeatConstants.Suggestion, "Suggestion")]
        [TestCase(FeatConstants.SupernaturalStrength, "Supernatural Strength")]
        [TestCase(FeatConstants.SwiftTracker, "Swift Tracker")]
        [TestCase(FeatConstants.TimelessBody, "Timeless Body")]
        [TestCase(FeatConstants.TirelessRage, "Tireless Rage")]
        [TestCase(FeatConstants.TongueOfSunAndMoon, "Tongue of Sun and Moon")]
        [TestCase(FeatConstants.Toughness, "Toughness")]
        [TestCase(FeatConstants.TowerShieldProficiency, "Tower Shield Proficiency")]
        [TestCase(FeatConstants.Track, "Track")]
        [TestCase(FeatConstants.Trample, "Trample")]
        [TestCase(FeatConstants.Trapfinding, "Trapfinding")]
        [TestCase(FeatConstants.TrapSense, "Trap Sense")]
        [TestCase(FeatConstants.Trip, "Trip")]
        [TestCase(FeatConstants.Turn, "Turn")]
        [TestCase(FeatConstants.TwoWeaponFighting, "Two-Weapon Fighting")]
        [TestCase(FeatConstants.TwoWeaponDefense, "Two-Weapon Defense")]
        [TestCase(FeatConstants.UncannyDodge, "Uncanny Dodge")]
        [TestCase(FeatConstants.UseMagicDeviceAsWizard, "Use Magic Device as Wizard")]
        [TestCase(FeatConstants.VulnerabilityToSunlight, "Vulnerability to Sunlight")]
        [TestCase(FeatConstants.WeaponFamiliarity, "Weapon Familiarity")]
        [TestCase(FeatConstants.WeaponFinesse, "Weapon Finesse")]
        [TestCase(FeatConstants.WeaponFocus, "Weapon Focus")]
        [TestCase(FeatConstants.WeaponProficiency, "Weapon Proficiency")]
        [TestCase(FeatConstants.WeaponSpecialization, "Weapon Specialization")]
        [TestCase(FeatConstants.WhirlwindAttack, "Whirlwind Attack")]
        [TestCase(FeatConstants.WholenessOfBody, "Wholeness of Body")]
        [TestCase(FeatConstants.WidenSpell, "Widen Spell")]
        [TestCase(FeatConstants.WildEmpathy, "Wild Empathy")]
        [TestCase(FeatConstants.WildShape, "Wild Shape")]
        [TestCase(FeatConstants.WoodlandStride, "Woodland Stride")]
        [TestCase(FeatConstants.Frequencies.Constant, "Constant")]
        [TestCase(FeatConstants.Frequencies.AtWill, "At Will")]
        [TestCase(FeatConstants.Frequencies.Day, "Day")]
        [TestCase(FeatConstants.Frequencies.Round, "Round")]
        [TestCase(FeatConstants.Foci.Acid, "Acid")]
        [TestCase(FeatConstants.Foci.Archery, "Archery")]
        [TestCase(FeatConstants.Foci.Cold, "Cold")]
        [TestCase(FeatConstants.Foci.Electricity, "Electricity")]
        [TestCase(FeatConstants.Foci.Fire, "Fire")]
        [TestCase(FeatConstants.Foci.Sonic, "Sonic")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}