// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TheGameMVC.Model.Characters;

namespace GameTests
{
    [TestFixture]
    public class TestHero
    {
        [Test]
        public void TestWonVictoryIncreaseExperience()
        {
            // тестова ситуация
            const int heroExperience = 200;
            const int victimExperience = 100;
            var hero = new Hero() { Name = "Knight", Experience = heroExperience };
            var victim = new Enemy() { Name = "Zombie", Experience = victimExperience };

            // извикване на метода
            hero.WonVictoryOver(victim);

            // проверка дали е коректна ситуацията
            Assert.That(hero.Experience, Is.EqualTo(heroExperience + victimExperience), "Hero's experience doesn't increase after beating victim");
        }
    }
}
