using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameMVC.Model.Game_Engine
{
    public class Map
    {
        private List Levels;
        private List Heroes;

        public List levels{get;set;}
        public List Heroes{get;set;}

        public Map()
        {
            this.Levels = new List<Levels>();
            this.Heroes = new List<Heroes>();
        }
        void Validate() 
        {
            if (Heroes <= 0)
	        {
                throw new ArgumentOutOfRangeException("There must be some heroes!");
	        }

            if (Hero.Validate() == true)
	        {
                return("It's okay.");
	        }
            else
            {
                throw new ArgumentOutOfRangeException("Heroes are not validate!");
            }

            if (Levels <= 0)
	        {
                throw new ArgumentOutOfRangeException("There must be some levels!");
	        }

            if (Level.Validate == true)
	        {
                return("It's okay.");
	        }
            else
            {
                throw new ArgumentOutOfRangeException("Levels are not validate!");
            }
        }
        // проверка дали е валидна, ако не - хвърляме изключение
        //да нямаме никакви герои
        //дали героите са валидни
        //да нямаме никакви нива
        //дали всяко от нивата е валидно
    }
}
