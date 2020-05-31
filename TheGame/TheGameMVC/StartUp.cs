using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TheGameMVC.Controller;
using TheGameMVC.Database;
using TheGameMVC.Model.Characters;
using TheGameMVC.Model.Game_Engine;
using System;

namespace TheGameMVC
{
    public class StartUp
    {
        // с програмен код създаваме картата в JSON формат
        static public Map JsonToMap(string mapFileName)
        {
            // зареждаме картата на играта
            var json = File.ReadAllText("..\\..\\Maps\\" + mapFileName + ".json");
            var map = JsonConvert.DeserializeObject<Map>(json);
            return map;
        }

        // записваме картата в JSON format
        static public void MapToJson(Map map, string mapFileName)
        {
            var json = JsonConvert.SerializeObject(map);
            File.WriteAllText("..\\..\\Maps\\" + mapFileName + ".json", json);
        }

        // записваме картата в JSON format
        static public void MapToDb(Map map)
        {
            using (var gameContext = new GameContext())
            {
                gameContext.ResetDatabase(shouldDropDatabase: true);
                gameContext.Maps.Add(map);
                gameContext.SaveChanges();
            }
        }

        static public Map DbToMap(int mapNo = 0)
        {
            var maps = new List<Map>();
            using (var gameContext = new GameContext())
            {
                maps = gameContext.Maps.ToList();
            }
            return maps[mapNo]; 
        }

        static void Main(string[] args)
        {
            var map = JsonToMap("V Map"); // зареждаме от JSON файл
            MapToDb(map); // записваме да го има и в базата
            
            // или може да заредим карта от базата:
            //var dbMap = DbToMap();
            
            ConsoleGameController controler = new ConsoleGameController(map);
        }

    }
}
