using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGameMVC.Model.Characters;

namespace TheGameMVC.Model.Game_Engine
{
    // картата на нашата игра
    public class Map
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // нивата в картата
        public List<Level> Levels{ get; set; }
        // героите, от които можем да избираме
        public List<Hero> Heroes{get;set;}

        public Map()
        {
            this.Levels = new List<Level>();
            this.Heroes = new List<Hero>();
        }

        // проверка дали е валидна, ако не - хвърляме изключение
        public void Validate() 
        {
            //да нямаме никакви герои
            if (Heroes.Count == 0)
	        {
                throw new ArgumentOutOfRangeException("There must be some heroes!");
	        }

            //дали героите са валидни
            foreach(var hero in Heroes)
            {
                hero.Validate();
            }
            
            //да нямаме никакви нива
            if (Levels.Count == 0)
	        {
                throw new ArgumentOutOfRangeException("There must be some levels!");
	        }

            //дали всяко от нивата е валидно
            foreach (var level in Levels)
            {
                level.Validate();
            }
        }
    }
}
