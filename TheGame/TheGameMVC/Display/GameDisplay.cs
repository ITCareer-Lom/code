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
        public GameDisplay(Game game)
        {
            Game = game;
        }

        public Game Game { get; set; }

        public void MapLoaded(Map map)
        {
            Console.WriteLine("Map loaded: "  + map.Name);
        }

        public Hero SelectHero() // избор на герой
        {
            Console.WriteLine("Choose your hero:");
            Console.WriteLine("0 End Game");
            ShowCreatures(Game.Map.Heroes);
            int myHero = int.Parse(Console.ReadLine());
            if (myHero == 0)
            {
                throw new GameStoppedException();
            }
            else if (myHero < 1 || myHero > Game.Map.Heroes.Count)
            {
                Console.WriteLine("Please choose an existing hero!");
                myHero = int.Parse(Console.ReadLine());
            }
            return Game.Map.Heroes[myHero-1];
        }

        //съобщаваме в кое ниво сме влезли и кой го населява, колко опит ни е нужен за преминаване и т.н.
        public void ShowLevel(Level level)
        {
            Console.WriteLine("You are in level: " + level.Name + 
                ", there are " + level.Enemies.Count + " enemies, " +
                + level.Helpers.Count + " helpers " +
                "and you need " + level.ExperienceNeededToPass() + "XP to go to the next level.");
            Console.WriteLine();
        }

        //оповестяваме на кой ход от играта сме
        public void ShowMove(int moveNo)
        {
            Console.WriteLine("Your turn: " + Game.MoveNo);
            Console.WriteLine();
        }

        // ако е true, e Избор, иначе е Съдба
        public void ShowMove(bool canSelectMove)  
        {
            if (canSelectMove)
            {
                Console.WriteLine("You are on turn Choice");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("You are on turn Destiny");
                Console.WriteLine();
            }
        }

        internal Creature SelectOpponent()
        {
            List<Creature> oponents = new List<Creature>();
            oponents.AddRange(Game.CurrentLevel.Enemies);
            oponents.AddRange(Game.CurrentLevel.Helpers);
            Console.WriteLine("Choose someone you want to go to: ");

            Console.WriteLine("0 End Game");
            ShowCreatures(oponents);

            int chosenOponent;
            do
            {
                chosenOponent = int.Parse(Console.ReadLine());

                if (chosenOponent == 0)
                {
                    throw new GameStoppedException();
                }
                else if (chosenOponent < 1 || chosenOponent > oponents.Count)
                {
                    Console.WriteLine("Please choose an existing opponent!");
                    chosenOponent = int.Parse(Console.ReadLine());
                }
                else break;
            } while (true); 

            return oponents[chosenOponent - 1];
        }

        public void ShowOpponent(Creature opponent)
        {
            //показва ни характеристиките на който ни е избран за противник 
            Console.WriteLine("You meet " + opponent.Name + " he has " + opponent.Power + 
                " power and " + opponent.Experience + "XP");
            Console.WriteLine();
        }

        internal HeroActionType SelectHeroAction()
        {
            throw new NotImplementedException(); // TODO
        }

        internal void ShowHeroAction(HeroActionType action, Creature opponent)
        {
            throw new NotImplementedException(); // TODO
        }

        public void ShowHeroActionResult(HeroActionType action, Creature opponent, bool success)
        {
            if (success)
            {
                Console.WriteLine("Meeting with " + opponent.Name + " was successfull");
            }
            else
            {
                Console.WriteLine("Meeting with " + opponent.Name + " was not successfull");
            }
        }

        public void ShowHero(Hero myHero)
        {
            Console.WriteLine(myHero);
            Console.WriteLine();
        }

        public void LevelFinished(Level currentLevel)
        {
            Console.WriteLine("Level " + currentLevel.Name + " is finished, congratulations!");
            Console.WriteLine();
        }

        public void GameOver() // играта завършва със загуба
        {
            Console.WriteLine("Game is Over :-(");
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
        public int SelectOption(string[] choises) 
        {
            int number = 1;
            foreach (var choise in choises)
	        {
                Console.WriteLine($"{number} {choise}");
                number++;
	        }
            int count = number-1;

            Console.WriteLine($"Select option from 1 to {choises.Length}, or 0 to quit the game: ");
            int selectedChoise;
            do
	        {
                selectedChoise = int.Parse(Console.ReadLine());
	        } while (selectedChoise <= choises.Length && selectedChoise >= 0);
            if (selectedChoise == 0)
            {
                throw new GameStoppedException();
            }
            return selectedChoise-1;
        }

        // показване на всички същества от даден вид
        public int ShowCreatures(IEnumerable<Creature> creatures)
        {
            int number = 1;
            foreach (var creature in creatures)
	        {
                Console.WriteLine($"{number} {creature}");
                number++;
	        }
            int count = number-1;
            return count;
        }
       //показва всички герой 
        /*public int ShowHeroes(IEnumerable<Creature> heroes)
        {
            int number = 1;
            foreach (var hero in heros)
            {
                Console.WriteLine($"{number} {heroes}");
                number++;
            }
            int count = number - 1;
            retrun count;
        }*/
    }
}
