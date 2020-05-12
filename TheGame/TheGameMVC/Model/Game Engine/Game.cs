using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGameMVC.Model.Characters;

namespace TheGameMVC.Model.Game_Engine
{
    enum GameState
    {
        NotStarted = 0, // още не е избран герой
        Playing = 1, // играем някакво ниво
        LevelCompleted = 2, // приключили сме нивото
        GameOver = 3, // играта е приключила със загуба
        GameStopped = 4, // играта е спряна
        GameCompleted = 5 // играта е приключила с победа
    }

    public class Game
    {
        public Map Map { get; set; }
        public Hero MyHero { get; set; }

        public Game(Map map)
        {
            Map = map;
        }

        internal void Started()
        {
            throw new NotImplementedException();
        }
    }
}
