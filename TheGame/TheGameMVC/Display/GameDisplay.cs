﻿using System;
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
            Console.WriteLine("Заредена е карта "  + map.Name );
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

        internal void GameOver()
        {
            throw new NotImplementedException();
        }

        internal void GameStopped()
        {
            throw new NotImplementedException();
        }

        internal void GameCompleted()
        {
            throw new NotImplementedException();
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
            int selectedChoise = int.Parse(Console.ReadLine());

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
    }
}
