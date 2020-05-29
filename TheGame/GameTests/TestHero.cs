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

        [Test]
        public void ValidateIfPowerIsInRange()
        {
            // тестова ситуация
            var hero = new Hero() { Name = "Knight", Power = 50 };
            // извикване на метода
            hero.Validate();

            // проверка дали е коректна ситуацията
            Assert.That(hero.Experience, Is.EqualTo(50), "Hero's power has to be in range to 50.");
        }

        [Test]
        public void ValidateIfHealthIsInRange()
        {
            // тестова ситуация
            var hero = new Hero() { Name = "Knight", Health = 100 };
            // извикване на метода
            hero.Validate();

            // проверка дали е коректна ситуацията
            Assert.That(hero.Health, Is.EqualTo(100), "Hero's health has to be in range to 50.");
        }

       [Test]
        public void TestFightDecreaseVictimPower()
        {
            // тестова ситуация
            const int heroHealth = 50;
            const int victimPower = 100;
            var hero = new Hero() { Name = "Knight", Gold = 0, Health = 100, Power = heroHealth };
            var victim = new Enemy() { Name = "Zombie", Gold = 0, Power = victimPower };
            
            // извикване на метода
            hero.Fight(victim);

            // проверка дали е коректна ситуацията
            Assert.That(victim.Power, Is.EqualTo(victimPower - heroHealth), "Victim's power does not decrease after being attacked");
        }

        [Test]
        public void TestDealIsMadeDecreaseHeroGold()
        {
            // тестова ситуация
            const int heroGold = 200;
            const int sellerPrice = 100;
            var hero = new Hero() { Name = "Knight", Gold = heroGold };
            var seller = new Helper() { Name = "Seller", Price = sellerPrice };

            // извикване на метода
            hero.Deal(seller);

            // проверка дали е коректна ситуацията
            Assert.That(hero.Gold, Is.EqualTo(heroGold - sellerPrice ), "Hero's gold does not decrease after deal");
        }

        [Test]
        public void TestDealIsMadeIncreareSellerGold()
        {
            // тестова ситуация
            const int heroGold = 200;
            const int sellerPrice = 100;
            var hero = new Hero() { Name = "Knight", Gold = heroGold };
            var seller = new Helper() { Name = "Seller", Price = sellerPrice };

            // извикване на метода
            hero.Deal(seller);

            // проверка дали е коректна ситуацията
            Assert.That(seller.Gold, Is.EqualTo(heroGold + sellerPrice ), "Seller's gold does not increase after deal");
        }
    }
}
