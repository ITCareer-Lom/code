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
        public int LevelNo { get; private set; } // TODO номера на нивото в картата
        public int MoveNo { get; private set; } //
        public Level CurrentLevel { get; private set; } // TODO кое от всичките Нива в момента сме, с get ни връща някой от нивата в картата
        public Creature Opponent { get; set; } // с кой сме се срещнали в момента
        public GameState State { get; set; } // в какво състояние е играта в момента

        public Game(Map map)
        {
            Map = map;
            State = GameState.NotStarted;
        }

        internal void Started() // TODO
        {
            Validate(); // играта започва извикваме Validate
            // определяме CanSelectMove дали началният ход е Съдба или Избор
            // активното ниво е първото ниво от картата
            LevelNo = 1;
            // състоянето на играта е Playing
            State = GameState.Playing;
        }

        public bool NextMove() // TODO преминаваме на следващ ход, ако можем(т.е.ако не сме убити, ако не сме завършили и т.н.), иначе прекъсва цикъла
        {
            return false;
        }

        bool OpponentSelection() // TODO Ники играта избира кой е нашия Opponent, връща дали дали тя ни е избрала противник
        {
            return false;
        }

        public bool Play(HeroActionType action) // TODO изиграваме хода и определяме какъв е резултата
        {
            bool success = true;
            switch (action)
            {
                case HeroActionType.Fight:
                    success = MyHero.Fight(Opponent);
                    break;
                case HeroActionType.Deal:
                    success = MyHero.Deal(Opponent);
                    break;
                case HeroActionType.Speak:
                    break;
            }
            return success;
        }

        public bool NextLevel() // TODO преминаваме на следващо ниво(и връща дали е възможно)
        {
            return false;
        }

        void Validate() // TODO проверка дали е валидна, ако не - хвърляме изключение 
        {
            // да имаме избран герой 
        }

        public void LoadLevel()
        {
            MyHero.Experience = 0; // TODO и ти трябва опит 100 * нивото за да преминеш нивото
        }

        public bool IsCompleted() // TODO играта завършва с победа ако е завършено последното ниво
        {
            return State == GameState.GameCompleted;
        }

        public bool IsOver() // TODO играта завършва със загуба ако героят ни умре
        {
            return false;
        }
    }
}
