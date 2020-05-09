using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TheGameMVC.Display;
using TheGameMVC.Model;

namespace TheGameMVC.Controller
{
    public class ConsoleGameController
    {
        private GameDisplay display;
        private Game game;

        public ConsoleGameController(Map map)
        {
            //създаваме модела game със тази карта
            game = new Game(map);

            //създаваме display с този модел game
            display = new Display();

            // display: коя карта е заредена
            display.MapLoaded(this.map);

            //display: избор на герой
            display.SelectHero();

            //game: играта започва
            game.Started();

            //повтаряме докато не приключи играта:
            while (game.IsCompleted() == false && game.IsOver() == false)
            {
                //display: съобщаваме в кое ниво сме влезли и кой го населява, колко опит ни е нужен за преминаване и т.н.
                display.ShowLevel();

                //повтаряме докато състоянието на играта е Playing
                while (game.GameState == 1) //по - късно трябва да се замести е enum
                {
                    //няма такъв метод//game: преминаваме на следващ ход, ако можем(т.е.ако не сме убити, ако не сме завършили и т.н.), иначе прекъсва цикъла

                    //display: оповестяваме на кой ход от играта сме
                    display.ShowMove();

                    //HELP //game: проверяваме CanSelectMove - дали ходът е Съдба или Избор

                    //display: извежда дали сме ход Съдба или ход Избор
                    display.ShowMove();

                    //???? // ако сме на ход избор:   //не знам как рзбираме че е избор ХЕЛП

                    if (true)
                    {
                        //display: избираме с кой искаме да се срещнем
                        //game: записваме кой е нашия Opponent
                        game.Opponent = display.SelectOpponent();

                        //display: показва ни характеристиките на който ни е избран за противник
                        display.ShowOpponent(game.Opponent);

                        //display: избираме какво действие ще извърши нашия герой
                        HeroActionType action = display.SelectHeroAction();

                        //???? //display: съобщаваме какво действие ще се извърши, срещу кого и т.н.

                        //game: изиграваме хода и определяме какъв е резултата
                        bool success = game.Play(action);

                        //display: съобщаваме резултата от играта //AMI NE E HUBAVO OPISANO
                        display.ShowHeroActionResult(action, game.Opponent, success);//NE ZNAM

                        //display: съобщава характеристиките на героя
                        display.ShowHero();
                    }
                }

                //ако състоянието е LevelCompleted:
                if (game.GameState == 2) //по - късно трябва да се замести е enum
                {
                    //display: съобщаваме, че е преминато нивото
                    display.LevelFinished(game.CurrentLevel);

                    //game: преминаваме на следващо ниво
                    game.NextLevel();
                }

                //ако game.State e GameOver
                else if (game.GameState == 3) //по - късно трябва да се замести е enum
                {
                    //display: играта завърши със загуба
                    display.GameOver();
                }

                //ако game.State e GameStopped
                else if (game.GameState == 4) //по - късно трябва да се замести е enum
                {
                    //display: играта е прекъсната
                    display.GameStopped();
                }

                //ако game.State e GameCompleted
                else if (game.GameState == 5) //по - късно трябва да се замести е enum
                {
                    //display: играта завърши с победа
                    display.GameCompleted();
                }
            }
        }
    }
}
