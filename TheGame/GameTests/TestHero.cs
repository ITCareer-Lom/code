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
        public void TestValidateIfPowerIsInRange()
        {
            // тестова ситуация
            var hero = new Hero() { Name = "Knight", Power = 51 };
            // извикване на метода

            // проверка дали е коректна ситуацията
            Assert.That(() => hero.Validate(), Throws.ArgumentException, "Hero's power has to be in range to 50.");
        }

        [Test]
        public void TestValidateIfHealthIsInRange()
        {
            //HELP така ли трябва да е 
            // тестова ситуация
            var hero = new Hero() { Name = "Knight", Health = 101 };
            // извикване на метода

            // проверка дали е коректна ситуацията
            Assert.That(() => hero.Validate(), Throws.ArgumentException, "Hero's health has to be in range to 100.");
        }

       [Test]
        public void TestFightDecreaseVictimPower()
        {
            // тестова ситуация
            var hero = new Hero() { Name = "Knight", Gold = 0, Health = 100, Power = 50 };
            var victim = new Enemy() { Name = "Zombie", Gold = 0, Health = 200 ,Power = 100 };
            
            // извикване на метода
            hero.Fight(victim);

            // проверка дали е коректна ситуацията
            Assert.That(victim.Power, Is.EqualTo(victim.Health - hero.Power), "Victim's power does not decrease after being attacked");
        }

        [Test]
        public void TestDealIsMadeDecreaseHeroGold()
        {
            // тестова ситуация
            //const int heroGold = 200;
            //const int sellerPrice = 100;
            var hero = new Hero() { Name = "Knight", Gold = 200};
            var seller = new Helper() { Name = "Seller", Price = 100};

            // извикване на метода
            hero.Deal(seller);

            // проверка дали е коректна ситуацията
            Assert.That(hero.Gold, Is.EqualTo(hero.Gold - seller.Price), "Hero's gold does not decrease after deal");
        }

        [Test]
        public void TestDealIsMadeIncreareSellerGold()
        {
            // тестова ситуация
            //const int heroGold = 200;
            //const int sellerPrice = 100;
            var hero = new Hero() { Name = "Knight", Gold = 200 };
            var seller = new Helper() { Name = "Seller", Price = 100 };

            // извикване на метода
            hero.Deal(seller);

            // проверка дали е коректна ситуацията
            Assert.That(seller.Gold, Is.EqualTo(hero.Gold + seller.Price ), "Seller's gold does not increase after deal");
        }
    }
}
