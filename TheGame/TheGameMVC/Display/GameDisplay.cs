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

        public void MapLoaded(Map map)
        {
            Console.WriteLine("Заредена е карта "  + map.Name);
        }

        public Hero SelectHero()
        {
            return null;
        }

        //съобщаваме в кое ниво сме влезли и кой го населява, колко опит ни е нужен за преминаване и т.н.
        public void ShowLevel(Level level)
        {
            Console.WriteLine("Вие сте на ниво " + level.Name + 
                ", то се населява от " + level.Enemies.Count + " злодея, " +
                + level.Helpers.Count + " добряка " +
                "и ви е нужен опит " + level.ExperienceNeededToPass() + " за да го преминете.");
            Console.WriteLine();
        }

        //оповестяваме на кой ход от играта сме
        public void ShowMove(int moveNo)
        {
            Console.WriteLine("Вие сте на ход " + Game.MoveNo);
            Console.WriteLine();
        }

        // ако е true, e Избор, иначе е Съдба
        public void ShowMove(bool canSelectMove)  
        {
            if (canSelectMove)
            {
                Console.WriteLine("Вие сте на ход Избор");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Вие сте на ход Съдба");
                Console.WriteLine();
            }
        }

        internal Creature SelectOpponent()
        {
            List<Creature> oponents = new List<Creature>();
            oponents.AddRange(Game.CurrentLevel.Enemies);
            oponents.AddRange(Game.CurrentLevel.Helpers);
            Console.WriteLine("Choose someone you want to go to: ");

            int i = 1;
            foreach (var oponent in oponents)
            {
                Console.WriteLine($"{i++}    " + oponent);
            }

            int chosenOponent = int.Parse(Console.ReadLine());

            while (chosenOponent < 1 || chosenOponent > oponents.Count)
            {
                Console.WriteLine("Please choose an existing opponent!");
                chosenOponent = int.Parse(Console.ReadLine());
            }

            return oponents[chosenOponent - 1];
        }

        public void ShowOpponent(Creature opponent)
        {
            //показва ни характеристиките на който ни е избран за противник 
            Console.WriteLine("Вие срешнахте опонент " + opponent.Name + " той има сила " + opponent.Power + 
                " и опит " + opponent.Experience);
            Console.WriteLine();
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

            Console.WriteLine($"Select option from 1 to {choises.Length}, or 0 to quit the game: ");
            do
	        {
                int selectedChoise = int.Parse(Console.ReadLine());
	        } while (selecedChoise <= choises.Length && selectedChoise >= 0);

            return selectedChoise;
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
       //показва всички герой 
        int ShowHero(IEnumarable<Hero> hero)
        {
            int number = 1;
            foreach (var hero in heros)
            {
                Console.WriteLine($"{number} {heroes}");
                number++;
            }
            int count = number - 1;
            retrun count;
        }
        void ShowHeroActionResult(HeroActionType action, Creature opponent , bool success)
        {
            if (action = success)
            {
                Console.WriteLine("Героят успешно премина");
            }
            else
            {
                Console.WriteLine("Героят не успя да премине");
            }
            return action;
        }

    }
}
