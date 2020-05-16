using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGameMVC.Model.Characters;

namespace TheGameMVC.Model.Game_Engine
{
    public enum GameState
    {
        NotStarted = 0, // още не е избран герой
        Playing = 1, // играем някакво ниво
        LevelCompleted = 2, // приключили сме нивото
        GameOver = 3, // играта е приключила със загуба
        GameStopped = 4, // играта е спряна
        GameCompleted = 5 // играта е приключила с победа
    }

    public enum HeroActionType
    {
        Skip = 0,
        Fight = 1,
        Deal = 2,
        Speak = 3
    }

    public class Game
    {
        public Map Map { get; set; } // картата, която е заредена в играта
        public Hero MyHero { get; set; } // нашия герой
        public bool CanSelectMove { get; set; } // дали ходът е Съдба или Избор
        public int LevelNo { get; set; } // номера на нивото в картата
        public Level CurrentLevel { get; set; } // кое от всичките Нива в момента сме, с get ни връща някой от нивата в картата
        public Creature Opponent { get; set; } // с кой сме се срещнали в момента
        public GameState State { get; set; } // в какво състояние е играта в момента

        public Game() { }

        public Game(Map map)
        {
            Map = map;
        }

        public Game(Hero myhero, Map map, int levelNo, Level currentLevel, Creature opponent, GameState state)
        {
            MyHero = myhero;
            Map = map;
            CanSelectMove = false;
            LevelNo = levelNo;
            CurrentLevel = currentLevel;
            Opponent = opponent;
            State = state;
        }

        internal void Started() // TODO
        {
            Validate(); // играта започва извикваме Validate
            // определяме CanSelectMove дали началният ход е Съдба или Избор
            // активното ниво е първото ниво от картата
            // състоянето на играта е Playing

            throw new NotImplementedException();
        }

        bool NextMove() // TODO преминаваме на следващ ход, ако можем(т.е.ако не сме убити, ако не сме завършили и т.н.), иначе прекъсва цикъла
        {
            return false;
        }

        bool OpponentSelection() // TODO играта избира кой е нашия Opponent, връща дали дали тя ни е избрала противник
        {
            return false;
        }

        bool Play(HeroActionType action) // TODO изиграваме хода и определяме какъв е резултата
        {
            return false;
        }

        bool NextLevel() // TODO преминаваме на следващо ниво(и връща дали е възможно)
        {
            return false;
        }

        void Validate() // TODO проверка дали е валидна, ако не - хвърляме изключение да имаме избран герой да е заредена карта картата да е валидна
        {

        }

        void LoadLevel(Level level)
        {
            MyHero.Experience = 0; // TODO и ти трябва опит 100 * нивото за да преминеш нивото
        }

        bool IsCompleted() // TODO играта завършва с победа ако е завършено последното ниво
        {
            return false;
        }

        bool IsOver() // TODO играта завършва със загуба ако героят ни умре
        {
            return false;
        }
    }
}
