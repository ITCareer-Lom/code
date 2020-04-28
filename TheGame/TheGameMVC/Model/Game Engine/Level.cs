using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameMVC.Model.Game_Engine
{
    public class Level
    {
        int id = 1;
        int id = 2;
        int id = 3;
        int id = 4;
        int id = 5;

        //опитът, които е нужен за минаване на нивата
        int ExperienceNeededToPass()
        {
            100 * id;
        }

        //проверяваме дали нивото е завършено 
        bool IsCompleted(Hero hero) => hero.Experience >= ExperienceNeededToPass();



    }
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
