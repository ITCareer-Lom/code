// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TheGameMVC.Model.Characters;

namespace GameTests
{
    [TestFixture]
    public class TestCreature
    {
        [Test]
        public void TestWonVictoryOverAddsGold()
        {
            // тестова ситуация
            const int MyGold = 50;
            var hero = new Hero() { Name = "Knight", Gold = 0 };
            var victim = new Enemy() { Name = "Zombie", Gold = MyGold };

            // извикване на метода
            hero.WonVictoryOver(victim);

            // проверка дали е коректна ситуацията
            Assert.That(hero.Gold, Is.EqualTo(MyGold), "On victory gold of the winner does not increase");
        }
    }
}
