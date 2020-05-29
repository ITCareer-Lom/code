using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [Test]
        public void TestWonVictoryOverVictimHasNoGold()
        {
            // тестова ситуация
            const int MyGold = 50;
            var hero = new Hero() { Name = "Knight", Gold = 0 };
            var victim = new Enemy() { Name = "Zombie", Gold = MyGold };

            // извикване на метода
            hero.WonVictoryOver(victim);

            // проверка дали е коректна ситуацията
            Assert.That(victim.Gold, Is.EqualTo(0), "Victim still has some gold after losing fight");
        }

        [Test]
        public void TestWonVictoryOverAcquareAllowedItemIncreaseCount()
        {
            // тестова ситуация
            var hero = new Hero() { Name = "Knight", Gold = 0, Health = 100, Power = 50 };
            var victim = new Enemy() { Name = "Zombie", Gold = 0 };
            victim.Items.Add(new Item { Name = "Sword", Type = ItemType.Power, UpgradeValue = 50 });
            victim.Items.Add(new Item { Name = "Shield", Type = ItemType.Health, UpgradeValue = 50 });

            // извикване на метода
            hero.WonVictoryOver(victim);

            // проверка дали е коректна ситуацията
            Assert.That(hero.Items.Count, Is.EqualTo(2), "Hero does not acquare allowed item from victim");
        }

        [Test]
        public void TestWonVictoryOverLoseAllowedItemDecreaseCount()
        {
            // тестова ситуация
            var hero = new Hero() { Name = "Knight", Gold = 0, Health = 100, Power = 50 };
            var victim = new Enemy() { Name = "Zombie", Gold = 0 };
            victim.Items.Add(new Item { Name = "Sword", Type = ItemType.Power, UpgradeValue = 50 });
            victim.Items.Add(new Item { Name = "Shield", Type = ItemType.Health, UpgradeValue = 50 });

            // извикване на метода
            hero.WonVictoryOver(victim);

            // проверка дали е коректна ситуацията
            Assert.That(victim.Items.Count, Is.EqualTo(0), "Victim does not lose item allowed for the hero");
        }

        [Test]
        public void TestWonVictoryOverAllowedItemIncreasePower()
        {
            // тестова ситуация
            const int SomePower = 35;
            var hero = new Hero() { Name = "Knight", Gold = 0, Health = 100, Power = SomePower };
            var victim = new Enemy() { Name = "Zombie", Gold = 0 };
            victim.Items.Add(new Item { Name = "Sword", Type = ItemType.Power, UpgradeValue = SomePower });
            victim.Items.Add(new Item { Name = "Shield", Type = ItemType.Health, UpgradeValue = 50 });

            // извикване на метода
            hero.WonVictoryOver(victim);

            // проверка дали е коректна ситуацията
            Assert.That(hero.Power, Is.EqualTo(2*SomePower), "Hero's power doesn't increase on after beating victim with power items");
        }

        [Test]
        public void TestWonVictoryOverAllowedItemIncreaseHealth()
        {
            // тестова ситуация
            const int SomeHealth = 100;
            var hero = new Hero() { Name = "Knight", Gold = 0, Health = SomeHealth, Power = 0 };
            var victim = new Enemy() { Name = "Zombie", Gold = 0 };
            victim.Items.Add(new Item { Name = "Sword", Type = ItemType.Power, UpgradeValue = 50 });
            victim.Items.Add(new Item { Name = "Shield", Type = ItemType.Health, UpgradeValue = SomeHealth });

            // извикване на метода
            hero.WonVictoryOver(victim);

            // проверка дали е коректна ситуацията
            Assert.That(hero.Health, Is.EqualTo(2 * SomeHealth), "Hero's health doesn't increase on after beating victim with health items");
        }

         [Test]
        public void TestWonVictoryOverAllowedItemIncreaseGold()
        {
            // тестова ситуация
            const int VictimGold = 100;
            const int HeroGold = 50;
            var hero = new Hero() { Name = "Knight", Gold = HeroGold };
            var victim = new Enemy() { Name = "Zombie", Gold = VictimGold };

            // извикване на метода
            hero.WonVictoryOver(victim);

            // проверка дали е коректна ситуацията
            Assert.That(hero.Gold, Is.EqualTo(HeroGold + VictimGold), "Hero's gold doesn't increase after beating victim");
        }
    }
}
