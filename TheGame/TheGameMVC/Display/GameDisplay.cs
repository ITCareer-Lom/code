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
            List<Creature> opponents = new List<Creature>();
            opponents.AddRange(Game.CurrentLevel.Enemies);
            opponents.AddRange(Game.CurrentLevel.Helpers);
            
            Console.WriteLine("Choose someone you want to go to: ");
            Console.WriteLine();
            Console.WriteLine("0 End Game");
            Console.WriteLine();
            ShowEmenisAndHelpers(Game.CurrentLevel.Enemies,Game.CurrentLevel.Helpers);

            int chosenOponent;
            do
            {
                chosenOponent = int.Parse(Console.ReadLine());

                if (chosenOponent == 0)
                {
                    throw new GameStoppedException();
                }
                else if (chosenOponent < 1 || chosenOponent > opponents.Count)
                {
                    Console.WriteLine("Please choose an existing opponent!");
                    chosenOponent = int.Parse(Console.ReadLine());
                }
                else break;
            } while (true); 

            return opponents[chosenOponent - 1];
        }

        public void ShowOpponent(Creature opponent)
        {
            //показва ни характеристиките на който ни е избран за противник 
            Console.WriteLine("You meet " + opponent.Name + " he has " + opponent.Power + 
                " power and " + opponent.Experience + "XP");
            Console.WriteLine();
        }

        public HeroActionType SelectHeroAction(Creature opponent)
        {
            Console.WriteLine("Select what you want to do: (write the number before the action)");
            Console.WriteLine("1. Skip");
            if (opponent is Enemy)
                Console.WriteLine("2. Fight");
            if (opponent is Helper)
                Console.WriteLine("2. Deal");
            
            int action = 1;
            do
            {
                action = int.Parse(Console.ReadLine());
            } while (action < 0 || action > 3);

            switch (action)
            {
                case 1:
                    return HeroActionType.Skip;
                case 2:
                        if(opponent is Enemy)
                            return HeroActionType.Fight;
                        else
                            return HeroActionType.Deal;
                    
            }
            throw new GameStoppedException();
        }

        public void ShowHeroAction(Hero hero, HeroActionType action, Creature opponent)
        {
            switch (action)
            {
                case HeroActionType.Skip:
                    Console.WriteLine($"You skipped the {opponent.Name}");
                    Console.WriteLine();
                    break;
                case HeroActionType.Fight:
                    Console.WriteLine($"You fight with " + opponent.Name);
                    Console.WriteLine();
                    break;
                case HeroActionType.Deal:
                    Console.WriteLine($"You deal with {opponent.Name}");
                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        }

        public void ShowHeroActionResult(HeroActionType action, Creature opponent, bool success)
        {
            if (success)
            {
                Console.WriteLine("Meeting with " + opponent.Name + " was successfull");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Meeting with " + opponent.Name + " was not successfull");
                Console.WriteLine();
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
        public int ShowEmenisAndHelpers(IEnumerable<Creature> enemies, IEnumerable<Creature> helpers)
        {
            int number = 1;
            Console.WriteLine("Enemies:");
            foreach (var enemy in enemies)
            {
                Console.WriteLine($"{number} {enemy}");
                number++;
            }
            Console.WriteLine();
            Console.WriteLine("Helpers:");
            foreach (var helper in helpers)
            {
                Console.WriteLine($"{number} {helper}");
                number++;
            }
            int count = number - 1;
            return count;
        }
    }
}
