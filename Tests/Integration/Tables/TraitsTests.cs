﻿using System;
using NPCGen.Tables.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables
{
    [TestFixture]
    public class TraitsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Set.Percentile.Traits; }
        }

        [TestCase("Distinctive scar", 1)]
        [TestCase("Missing tooth", 2)]
        [TestCase("Missing finger", 3)]
        [TestCase("Bad breath", 4)]
        [TestCase("Strong body odor", 5)]
        [TestCase("Pleasant smelling (perfumed)", 6)]
        [TestCase("Sweaty", 7)]
        [TestCase("Hands shake", 8)]
        [TestCase("Unusual eye color", 9)]
        [TestCase("Hacking cough", 10)]
        [TestCase("Sneezes and sniffles", 11)]
        [TestCase("Particularly low voice", 12)]
        [TestCase("Particularly high voice", 13)]
        [TestCase("Slurs words", 14)]
        [TestCase("Lisps", 15)]
        [TestCase("Stutters", 16)]
        [TestCase("Enunciates very clearly", 17)]
        [TestCase("Speaks loudly", 18)]
        [TestCase("Whispers", 19)]
        [TestCase("Hard of hearing", 20)]
        [TestCase("Tattoo", 21)]
        [TestCase("Birthmark", 22)]
        [TestCase("Unusual skin color", 23)]
        [TestCase("Bald", 24)]
        [TestCase("Particularly long hair", 25)]
        [TestCase(EmptyContent, 26)]
        [TestCase("Unusual hair color", 27)]
        [TestCase("Walks with a limp", 28)]
        [TestCase("Distinctive jewelry", 29)]
        [TestCase("Wears flamboyant or outlandish clothes", 30)]
        [TestCase("Underdressed", 31)]
        [TestCase("Overdressed", 32)]
        [TestCase("Nervous eye twitch", 33)]
        [TestCase("Fiddles and fidgets nervously", 34)]
        [TestCase("Whistles a lot", 35)]
        [TestCase("Signs a lot", 36)]
        [TestCase("Flips a coin", 37)]
        [TestCase("Good posture", 38)]
        [TestCase("Stooped back", 39)]
        [TestCase("Tall", 40)]
        [TestCase("Short", 41)]
        [TestCase("Thin", 42)]
        [TestCase("Fat", 43)]
        [TestCase("Visible wounds or sores", 44)]
        [TestCase("Squints", 45)]
        [TestCase("Stares off into distance", 46)]
        [TestCase("Frequently chewing something", 47)]
        [TestCase("Dirty and unkempt", 48)]
        [TestCase("Clean", 49)]
        [TestCase("Distinctive nose", 50)]
        [TestCase("Selfish", 51)]
        [TestCase("Obsequious", 52)]
        [TestCase("Drowsy", 53)]
        [TestCase("Bookish", 54)]
        [TestCase("Observant", 55)]
        [TestCase("Not very observant", 56)]
        [TestCase("Overly critical", 57)]
        [TestCase("Passionate artist or art lover", 58)]
        [TestCase("Passionate hobbyist (fishing, hunting, gaming, animals, etc.)", 59)]
        [TestCase("Collector (books, trophies, coins, weapons, etc.)", 60)]
        [TestCase("Skinflint", 61)]
        [TestCase("Spendthrift", 62)]
        [TestCase("Pessimist", 63)]
        [TestCase("Optimist", 64)]
        [TestCase("Drunkard", 65)]
        [TestCase("Teetotaler", 66)]
        [TestCase("Well mannered", 67)]
        [TestCase("Rude", 68)]
        [TestCase("Jumpy", 69)]
        [TestCase("Foppish", 70)]
        [TestCase("Overbearing", 71)]
        [TestCase("Aloof", 72)]
        [TestCase("Proud", 73)]
        [TestCase("Individualist", 74)]
        [TestCase("Conformist", 75)]
        [TestCase("Hot tempered", 76)]
        [TestCase("Even tempered", 77)]
        [TestCase("Neurotic", 78)]
        [TestCase("Jealous", 79)]
        [TestCase("Brave", 80)]
        [TestCase("Cowardly", 81)]
        [TestCase("Careless", 82)]
        [TestCase("Curious", 83)]
        [TestCase("Truthful", 84)]
        [TestCase("Liar", 85)]
        [TestCase("Lazy", 86)]
        [TestCase("Energetic", 87)]
        [TestCase("Reverent or pious", 88)]
        [TestCase("Irreverent or irreligious", 89)]
        [TestCase("Strong opinions on politics or morals", 90)]
        [TestCase("Moody", 91)]
        [TestCase("Cruel", 92)]
        [TestCase("Uses flowery speech or long words", 93)]
        [TestCase("Uses the same phrase over and over", 94)]
        [TestCase("Sexist, racist, or otherwise prejudiced", 95)]
        [TestCase("Fascinated by magic", 96)]
        [TestCase("Distrustful of magic", 97)]
        [TestCase("Prefers members of one class over all others", 98)]
        [TestCase("Jokester", 99)]
        [TestCase("No sense of humor", 100)]
        public override void Percentile(String content, Int32 roll)
        {
            base.Percentile(content, roll);
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }
    }
}