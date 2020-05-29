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
    public class TestLevel
    {
        [Test]
        public void TestLevelFinished()
        {
            //тестова ситуация
            const int LevelId = 1;
            var enemy = new Enemy() { Name = "Dragon", Id = 0 };
            // var hero = new Hero() { Name = "Knight", Id = LevelId };

            // извикване на метода
            // level.IsCompleted();

            // проверка дали е коректна ситуацията
            //Assert.That(Level.Id, Is.EqualTo(LevelId), "The level is not finished");
        }
    }
}
