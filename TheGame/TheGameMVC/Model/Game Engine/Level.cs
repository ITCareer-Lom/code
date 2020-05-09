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
        public List<Helpers> Helpers { get; set; }
        

        public Level()
        {
            Enemies = new List<Enemy>();
            Helpers = new List<Helpers>();
            
        }

        // за връзка с таблицата с картата
        public int MapId { get; set; }
        public virtual Map Map { get; set; }

        //опитът, които е нужен за минаване на нивата
        public int ExperienceNeededToPass()
        {
            var result = 100 * Id;
            return result;
        }

        //проверяваме дали нивото е завършено 
        public bool IsCompleted(Hero hero)
        {
            var result = hero.Experience >= ExperienceNeededToPass();
            return result;
        }

        public void Validate()
        {
            // TODO да има поне един злодей
            throw new NotImplementedException();
        }
    }
  }
