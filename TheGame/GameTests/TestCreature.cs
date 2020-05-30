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

        [Test]
        public void TestLoseItemRemovesItem()
        {
            // тестова ситуация
            var hero = new Hero() { Name = "Knight", Gold = 0, Health = 100, Power = 0 };
            var item = new Item { Name = "Sword", Type = ItemType.Power, UpgradeValue = 50 };
            var item1 = new Item { Name = "Sword", Type = ItemType.Power, UpgradeValue = 50 };
            hero.Items.Add(item);
            hero.Items.Add(item1);
            int itemsCount = hero.Items.Count;

            // извикване на метода
            hero.LoseItem(item);
            hero.LoseItem(item1);

            // проверка дали е коректна ситуацията
            Assert.That(hero.Items.Count, Is.EqualTo(0), "Hero doen't lose item after lost victory.");
        }

        [Test]
        public void TestLoseItemDecreasePower()
        {
            // тестова ситуация
            const int SomePower = 35;
            var hero = new Hero() { Name = "Knight", Gold = 0, Health = 100, Power = SomePower };
            var item = new Item { Name = "Sword", Type = ItemType.Power, UpgradeValue = SomePower };
            hero.Items.Add(item);

            // извикване на метода
            hero.LoseItem(item);

            // проверка дали е коректна ситуацията
            Assert.That(hero.Power, Is.EqualTo(0), "Hero's power doesn't decrease after losing items");
        }

        [Test]
        public void TestLoseItemDecreaseHealth()
        {
            // тестова ситуация
            const int SomeHealth = 100;
            var hero = new Hero() { Name = "Knight", Gold = 0, Health = SomeHealth, Power = 0 };
            var item = new Item { Name = "Shield", Type = ItemType.Health, UpgradeValue = SomeHealth };
            hero.Items.Add(item);

            // извикване на метода
            hero.LoseItem(item);

            // проверка дали е коректна ситуацията
            Assert.That(hero.Health, Is.EqualTo(0), "Hero's health doesn't decrease after losing health items");
        }

        [Test]
        public void TestLoseItemDecreaseGold()
        {
            // тестова ситуация
            const int HeroGold = 50;
            var hero = new Hero() { Name = "Knight", Gold = HeroGold };
            var item = new Item { Name = "Shield", Type = ItemType.Gold, UpgradeValue = HeroGold };

            // извикване на метода
            hero.LoseItem(item);

            // проверка дали е коректна ситуацията
            Assert.That(hero.Gold, Is.EqualTo(0), "Hero's gold doesn't decrease after losing items");
        }


       /* //Връща Exception за power
        [Test]
        public void TestValidateIfHealthIs100()
        {
            // тестова ситуация
            var hero = new Hero() { Name = "Knight", Health = 50 };
            // извикване на метода
            hero.Validate();

            // проверка дали е коректна ситуацията
            Assert.That(hero.Health, Is.EqualTo(100), "Hero's health has to be 100!");
        }*/
    }
}
