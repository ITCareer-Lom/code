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
        // TODO същото и за Helpers

        public Level()
        {
            Enemies = new List<Enemy>();
            // TODO
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
    // TODO това надолу се маха, но го разнеси като имена по другите файлове и го запази някъде за после
    public class Level1
    {
        int id = 1;
        string name = "The Wonder World";

        //Това са злодеите, които могат да се паднат в първо ниво 
        string enemies = "Dragon";
        string enemies = "Serpent";

        //Това са добряците които могат да се паднат в първо ниво 
        string helpers = "Gnome";
        string helpers = "Elf";

    }
    public class Level2
    {
        int id = 2;
        string name = "The Prisoner Grotto";

        //Това са злодеите, които могат да се паднат във второ ниво 
        string enemies = "Robber";
        string enemies = "Nija";
        string enemies = "Zombie";

        //Това са добряците които могат да се паднат във второ ниво 
        string helpers = "Merchant";
        string heplers = "Wise Man";

    }
    public class Level3
    {
        int id = 3;
        string name = "The Apocalypse";

        //Това са злодеите, които могат да се паднат в трето ниво 
        string enemies = "Zombie";
        string enemies = "Vampire";


        //Това са добряците които могат да се паднат в трето ниво 
        string helpers = "Doctor";
        string helpers = "Spirit";
    }
    public class Level4
    {
        int id = 4;
        string name = "Maze of death`s marsh";

        //Това са злодеите, които могат да се паднат в четвърто ниво 
        string enemies = "Witch";
        string enemies = "Vampire";

        //Това са злодеите, които могат да се паднат в четвърто ниво 
        string helpers = "Unicorn";
        string helpers = "Elf";
    }
    public class Level5
    {
        int id = 5;
        string name = "The end of the glowing vault";


        //Това са злодеите, които могат да се паднат в пето ниво 
        string enemies = "Robber";
        string enemies = "Dragon";
        string enemies = "Ninja";
        string enemies = "Serpent";


        //Това са злодеите, които могат да се паднат в пето ниво 
        string helpers = "Merchant";
        string helpers = "Gnome";

    }
   
}
