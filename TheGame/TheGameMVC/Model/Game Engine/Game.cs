using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGameMVC.Model.Characters;

namespace TheGameMVC.Model.Game_Engine
{
    public class GameStoppedException : Exception { };
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
        public int LevelNo { get; private set; } // номера на нивото в картата
        public int MoveNo { get; private set; } //
        public Level CurrentLevel
        {
            get
            {
                if (Map == null || LevelNo < 1 )
                    return null;
                else
                    return Map.Levels[LevelNo - 1];
            }
        } // кое от всичките Нива в момента сме, с get ни връща някой от нивата в картата
        public Creature Opponent { get; set; } // с кой сме се срещнали в момента
        public GameState State { get; set; } // в какво състояние е играта в момента

        private Random random = new Random();

        public Game(Map map)
        {
            Map = map;
            State = GameState.NotStarted;
        }

        internal void Started()
        {
            Validate(); // играта започва извикваме Validate
            // определяме CanSelectMove дали началният ход е Съдба или Избор
            CanSelectMove = random.Next(2) == 1;
            LevelNo = 1; // активното ниво е първото ниво от картата            
            State = GameState.Playing; // състоянето на играта е Playing
        }

        public bool NextMove() /* преминаваме на следващ ход, ако можем
            (т.е.ако не сме убити, ако не сме завършили и т.н.), иначе прекъсва цикъла*/
        {
            if (MyHero.Health == 0)
                State = GameState.GameOver;
            else if (CurrentLevel.IsCompleted(MyHero) && LastLevel())
                State = GameState.GameCompleted;
            else if (CurrentLevel.IsCompleted(MyHero) && !LastLevel())
                State = GameState.LevelCompleted;
            else if (State == GameState.Playing)
            {
                MoveNo++;
                CanSelectMove = !CanSelectMove;
                OpponentSelection();
                return true;
            }
            return false;
        }

        bool OpponentSelection() // TODO Ники играта избира кой е нашия Opponent, връща дали дали тя ни е избрала противник
        {
            bool selected = false;
            if (CanSelectMove)
            {
                bool enemyIsSelected = random.Next(2) == 1; // true = enemy | false = helper
                if (enemyIsSelected)
                {
                    Opponent = CurrentLevel.Enemies[random.Next(0, CurrentLevel.Enemies.Count)];
                }
                else
                {
                    Opponent = CurrentLevel.Helpers[random.Next(0, CurrentLevel.Helpers.Count)];
                }
                selected = true;
            }
            return selected;
        }

        public bool Play(HeroActionType action) // изиграваме хода и определяме какъв е резултата
        {
            bool success = true;
            switch (action)
            {
                case HeroActionType.Fight:
                    success = MyHero.Fight(Opponent as Enemy);
                    break;
                case HeroActionType.Deal:
                    success = MyHero.Deal(Opponent as Helper);
                    break;
            }
            return success;
        }

        public bool NextLevel() // преминаваме на следващо ниво(и връща дали е възможно)
        {
            if (!LastLevel() && CurrentLevel.IsCompleted(MyHero))
            {
                LevelNo++;
                State = GameState.Playing;
            }
            else
                State = GameState.GameCompleted;
            return !LastLevel();
        }

        void Validate() // проверка дали е валидна, ако не - хвърляме изключение 
        {
            if (MyHero == null) // да имаме избран герой 
            {
                State = GameState.NotStarted;
                throw new ArgumentNullException("No Hero selected.");
            }
        }

        public void LoadLevel() // и ти трябва опит 100 * нивото за да преминеш нивото
        {
            MyHero.Experience = 0; 
        }
        
        public bool IsCompleted() // играта завършва с победа ако е завършено последното ниво
        {
            return State == GameState.GameCompleted;
        }

        public bool IsOver() // играта завършва със загуба ако героят ни умре
        {
            return State == GameState.GameOver;
        }

        public bool LastLevel() // Проверява дали сме на последното ниво
        {
            return LevelNo == Map.Levels.Count;
        }
    }
}
