using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGameMVC.Model.Characters;
using TheGameMVC.Model.Game_Engine;

namespace TheGameMVC.Display
{
    public class GameDisplay
    {
        public Game Game { get; set; }

        public void MapLoaded(Map map) // коя карта е заредена
        {
            Console.WriteLine("Заредена е карта "  + map.Name );
            Console.WriteLine();
        }

        public Hero SelectHero()
        {
            return null;
        }

        internal void ShowLevel(Level level)
        {
            throw new NotImplementedException();
        }

        internal void ShowMove(int moveNo)
        {
            throw new NotImplementedException();
        }

        internal void ShowMove(bool canSelectMove)  // ако е true, e Избор, иначе е Съдба
        {
            throw new NotImplementedException();
        }

        internal Creature SelectOpponent()
        {
            // HELP
            throw new NotImplementedException();
        }

        internal void ShowOpponent(Creature opponent)
        {
            throw new NotImplementedException();
        }

        internal HeroActionType SelectHeroAction()
        {
            throw new NotImplementedException();
        }

        internal void ShowHeroAction(HeroActionType action, Creature opponent)
        {
            throw new NotImplementedException();
        }

        internal void ShowHeroActionResult(HeroActionType action, Creature opponent, bool success)
        {
            throw new NotImplementedException();
        }

        internal void ShowHero(Hero myHero)
        {
            throw new NotImplementedException();
        }

        internal void LevelFinished(Level currentLevel)
        {
            throw new NotImplementedException();
        }

        public void GameOver() // играта завършва със загуба
        {
            Console.WriteLine("Game Over");
            Console.WriteLine();
        }

        public void GameStopped() // играта е прекъсната
        {
            Console.WriteLine("The Game stopped.");
            Console.WriteLine();
        }

        public void GameCompleted() // играта завършва с победа
        {
            Console.WriteLine("The Game completed. You win!");
            Console.WriteLine();
        }

        // избор на една от няколко възможности 
        int SelectOption(string[] choises) 
        {
            int number = 1;
            foreach (var choise in choises)
	        {
                Console.WriteLine($"{number} {choise}");
                number++;
	        }
            int count = number-1;
            return count;
        }

        // показване на всички същества от даден вид
        int ShowCreatures(IEnumerable<Creature> creatures)
        {
            int number = 1;
            foreach (var cteature in creatures)
	        {
                Console.WriteLine($"{number} {creatures}");
                number++;
	        }
            int count = number-1;
            return count;
        }
    }
}
