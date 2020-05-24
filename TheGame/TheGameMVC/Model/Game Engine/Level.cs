using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGameMVC.Model.Characters;

namespace TheGameMVC.Model.Game_Engine
{
    public class Level
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Helper> Helpers { get; set; }

        // за връзка с таблицата с картата
        public int MapId { get; set; }
        public virtual Map Map { get; set; }

        public Level()
        {
            this.Id = 0;
            this.Name = "";
            Enemies = new List<Enemy>();
            Helpers = new List<Helper>();
        }

        //опитът, които е нужен за минаване на нивото
        public int ExperienceNeededToPass()
        {
            var result = 100 * Id;
            return result;
        }

        //проверяваме дали нивото е завършено 
        public bool IsCompleted(Hero hero)
        {
            var result = (hero.Health > 0) && (hero.Experience >= ExperienceNeededToPass());
            return result;
        }

        public void Validate()
        {
            // да има поне един злодей
            if (Enemies.Count == 0)
                throw new ArgumentOutOfRangeException("Level must contain at least one enemy");
        }
    }
  }
