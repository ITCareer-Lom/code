using NUnit.Framework;
using System.Collections.Generic;
using TheGameMVC.Model.Characters;
using TheGameMVC.Model.Game_Engine;
using Moq;

namespace GameTests
{
    [TestFixture]
    public class TestGame
    {
        Game game;
        
        [SetUp]
        public void SetUp()
        {
            game = new Game(new Map());
        }

        [Test]
        public void ValidateThrowsExceptionIfHeroIsNull()
        {
            Assert.That(() => game.Started(), Throws.ArgumentNullException, "Game allows our hero to be null!");
        }

        [Test]
        public void LoadLevelSetsHeroExperienceToZero()
        {
            const int correct = 0;
            Game game = new Game(new Map());
            game.MyHero = new Hero() { Health = 100, Experience = 100 };

            game.LoadLevel();
            Assert.That(game.MyHero.Experience, Is.EqualTo(correct), "Hero experience does not reset upon loading new level!");
        }

        [Test]
        public void StartGameSetsStateToPlaying()
        {
            Game game = new Game(new Map());
            game.MyHero = new Hero() { Health = 100, Experience = 100 };
            game.Started();

            Assert.That(game.State, Is.EqualTo(GameState.Playing), "Start game does not indicate the started game!");
        }

        [Test]
        public void NextMoveSetsStateToOverIfHeroIsDead()
        {
            Game game = new Game(new Map());
            game.MyHero = new Hero() { Health = 0, Experience = 0};
            game.NextMove();

            Assert.That(game.State, Is.EqualTo(GameState.GameOver), "Next move does not set game to over if hero is dead!");
        }

        [Test]
        public void NextMoveSetsStateToGameCompletedIfHeroHasEnoughExperience()
        {
            Game game = new Game(new Map() { Levels = new List<Level>() { new Level() { Id = 1, Name = "p" } } });
            game.MyHero = new Hero() { Health = 100, Experience = 100 };
            game.Started();
            game.NextMove();

            Assert.That(game.State, Is.EqualTo(GameState.GameCompleted), "Next move does not set game to Completed if hero has enough experience!");
        }

        [Test]
        public void NextMoveSetsStateToLevelCompletedIfHeroHasEnoughExperience()
        {
            Game game = new Game(new Map() { Levels = new List<Level>() { new Level() { Id = 1, Name = "p" }, new Level() { Id = 2, Name = "f" } } });
            game.MyHero = new Hero() { Health = 100, Experience = 100 };
            game.Started();
            game.NextMove();

            Assert.That(game.State, Is.EqualTo(GameState.LevelCompleted), "Next move does not set level to Completed if hero has enough experience!");
        }

        [Test]
        public void NextMoveReturnsTrueIfHeroContinuesToBeInCurrentLevel()
        {
            Game game = new Game(new Map() { Levels = new List<Level>() { new Level() { Id = 1, Name = "p", Enemies = new List<Enemy>() { new Enemy() { Name = "f" } }, Helpers = new List<Helper>() { new Helper() { Name = "n" } } }, new Level() { Id = 2, Name = "f" } } });

            game.MyHero = new Hero() { Health = 100, Experience = 0 };
            game.Started();

            Assert.That(game.NextMove(), Is.EqualTo(true), "Next move does not return true if hero continues to be in same level!");
        }

        [Test]
        public void OpponentSelectionReturnsFalseIfCanSelectMoveIsTrue()
        {
            const bool correct = false;
            Game game = new Game(new Map());
            game.CanSelectMove = true;

            Assert.That(game.OpponentSelection(), Is.EqualTo(correct), "Opponent selection select random enemy/helper when we should select!");
        }


        [Test]
        public void NextLevelGoesToNextLevel()
        {
            const int correct = 2;
            Game game = new Game(new Map() { Levels = new List<Level>() { new Level() { Id = 1, Name = "p" }, new Level() { Id = 2, Name = "f" } } });
            game.MyHero = new Hero() { Health = 100, Experience = 100 };
            game.Started();
            game.NextLevel();


            Assert.That(game.LevelNo, Is.EqualTo(correct), "Does not move to next level if current is finished!");
        }

        [Test]
        public void NextLevelGoesToNextLevelAndSetsGameStateToPlaying()
        {
            Game game = new Game(new Map() { Levels = new List<Level>() { new Level() { Id = 1, Name = "p" }, new Level() { Id = 2, Name = "f" } } });
            game.MyHero = new Hero() { Health = 100, Experience = 100 };
            game.Started();
            game.NextLevel();


            Assert.That(game.State, Is.EqualTo(GameState.Playing), "Does not set game state to playing if current is finished!");
        }

        [Test]
        public void NextLevelSetsGameStateCompletedIfFinishedLastLevel ()
        {
            Game game = new Game(new Map() { Levels = new List<Level>() { new Level() { Id = 1, Name = "p" }} });
            game.MyHero = new Hero() { Health = 100, Experience = 100 };
            game.Started();
            game.NextLevel();


            Assert.That(game.State, Is.EqualTo(GameState.GameCompleted), "Does not set game state to completed if last level is finished!");
        }

        [Test]
        public void PlayReturnFalseIfHeroDiesWhenFightsEnemy()
        {
            const bool correct = false;
            Game game = new Game(new Map());
            game.MyHero = new Hero() { Health = 10, Power = 10, Experience = 0 };
            game.Opponent = new Enemy() { Health = 100, Power = 100, Experience = 0 };


            Assert.That(game.Play(HeroActionType.Fight), Is.EqualTo(correct), "Play does not return false when hero fights enemy and dies!");
        }

    }
}
