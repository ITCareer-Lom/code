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

        internal void MapLoaded(object map)
        {
            throw new NotImplementedException();
        }

        internal Hero SelectHero()
        {
            return null;
        }
    }
}
