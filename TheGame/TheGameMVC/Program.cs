using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGameMVC.Controller;
using TheGameMVC.Model.Characters;
using TheGameMVC.Model.Game_Engine;

namespace TheGameMVC
{
    class Program
    {
        // с програмен код създаваме картата 
        static public Map CodeToMap()
        {
            var map = new Map
            {
                Name = "Simple Game"
            };
            var hero = new Hero() { Id = 1, Name = "Knight" };
            map.Heroes.Add(hero);
            var level1 = new Level { Id = 1, Name = "Първо ниво" };
            var helper1 = new Helper { Name = "Trader", Price = 10 };
            helper1.Items.AddRange(new List<Item>() {
                new Item() { Name = "Sheild", Type = ItemType.Power, UpgradeValue = 65},
                new Item() { Name = "Herbs", Type = ItemType.Health, UpgradeValue = 10}
            });
            level1.Helpers.Add(helper1);
            map.Levels.Add(level1);
            return map;
        }

        // с програмен код създаваме картата в JSON формат
        static public Map JsonToMap(string mapFileName)
        {
            // зареждаме картата на играта
            var json = File.ReadAllText("..\\..\\Maps\\" + mapFileName + ".json");
            var map = JsonConvert.DeserializeObject<Map>(json);
            return map;
        }

        static void Main(string[] args)
        {
            // създаваме програмно картата
            // var map = CodeToMap();

            // зареждаме картата от JSON формат
            var map = JsonToMap("plain");
            //MapToDb(map);

            // създаваме контролера и той задейства играта
            ConsoleGameController controler = new ConsoleGameController(map);
        }
    }
}
