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
using TheGameMVC.Model.Characters;
using TheGameMVC.Model.Game_Engine;

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
            display = new GameDisplay(game);
            // коя карта е заредена
            display.MapLoaded(game.Map);
            game.Map.Validate();

            try
            {
                // избор на герой
                game.MyHero = display.SelectHero();

                // играта започва
                game.Started();

                //повтаряме докато не приключи играта:
                while (!game.IsCompleted() && !game.IsOver())
                {
                    game.LoadLevel();
                    // съобщаваме в кое ниво сме влезли и кой го населява, колко опит ни е нужен за преминаване и т.н.
                    display.ShowLevel(game.CurrentLevel);
                    //повтаряме докато състоянието на играта е Playing
                        while (game.State == GameState.Playing) 
                    {
                        //преминаваме на следващ ход, ако можем(т.е.ако не сме убити, ако не сме завършили и т.н.), иначе прекъсва цикъла
                        if (!game.NextMove()) break; 

                        // оповестяваме на кой ход от играта сме
                        display.ShowMove(game.MoveNo);

                        // проверяваме CanSelectMove - дали ходът е Съдба или Избор
                        var canSelect = game.CanSelectMove;

                        // извежда дали сме ход Съдба или ход Избор
                        display.ShowMove(game.CanSelectMove);

                        // ако сме на ход избор: 
                        if (canSelect)
                        {
                            // избираме с кой искаме да се срещнем и записваме кой е нашия Opponent
                            game.Opponent = display.SelectOpponent();
                        }

                        // ход съдба се избира нашия опонент
                        if (!game.OpponentSelection() && canSelect == false)
                        {
                            continue;
                            // ако не е успяло да ни избере противник
                        }
                        

                        // показва ни характеристиките на който ни е избран за противник
                        display.ShowOpponent(game.Opponent);

                        // избираме какво действие ще извърши нашия герой
                        HeroActionType action = display.SelectHeroAction(game.Opponent);

                        // съобщаваме какво действие ще се извърши, срещу кого и т.н.
                        display.ShowHeroAction(game.MyHero, action, game.Opponent);

                        // изиграваме хода и определяме какъв е резултата
                        bool success = game.Play(action);

                        // премахваме вече победен злодей или добряк, с който сме направили сделка
                        if (success)
                        {
                            if (game.Opponent is Enemy && action is HeroActionType.Fight)
                                game.CurrentLevel.Enemies.Remove(game.Opponent as Enemy);
                            else if(game.Opponent is Helper && action is HeroActionType.Deal)
                                game.CurrentLevel.Helpers.Remove(game.Opponent as Helper);
                        }

                        // съобщаваме резултата от играта 
                        display.ShowHeroActionResult(action, game.Opponent, success);
                    
                        // съобщава новите характеристики на героя
                        display.ShowHero(game.MyHero);
                    }

                    //ако състоянието е LevelCompleted:
                    if (game.State == GameState.LevelCompleted)
                    {
                        // съобщаваме, че е преминато нивото
                        display.LevelFinished(game.CurrentLevel);

                        // преминаваме на следващо ниво
                        game.NextLevel();
                    }

                    //ако game.State e GameOver
                    else if (game.State == GameState.GameOver)
                    {
                        //display: играта завърши със загуба
                        display.GameOver();
                        break;
                    }

                    //ако game.State e GameCompleted
                    else if (game.State == GameState.GameCompleted) 
                    {
                        //display: играта завърши с победа
                        display.GameCompleted();
                    }
                }
            }
	        catch (GameStoppedException)
	        {
                // display: играта е прекъсната
                game.State = GameState.GameStopped;
                display.GameStopped();
	        }
        }
    }
}
