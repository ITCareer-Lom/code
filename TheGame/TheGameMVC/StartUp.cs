namespace TheGameMVC
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using TheGameMVC.Controller;
    using TheGameMVC.Database;
    using TheGameMVC.Model.Characters;
    using TheGameMVC.Model.Game_Engine;
    using System;
    using TheGameMVC.Database.DataProcessor;

    public class StartUp
    {
        private static void ResetDatabase(GameContext context, bool shouldDropDatabase = false)
        {
            if (shouldDropDatabase)
            {
                context.Database.EnsureDeleted();
            }

            if (context.Database.EnsureCreated())
            {
                return;
            }
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
            Deserializer ds = new Deserializer();
            var map = JsonToMap("V Map");
            /*using (var context = new GameContext())
            {
                ResetDatabase(context, shouldDropDatabase: true);

                

                var maps = new List<Map>();
                maps.Add(map);

                ImportMap(context, maps, map.Heroes, map.Levels);

                foreach (var level in map.Levels)
                {
                    ImportEntities(context, level.Enemies, level.Helpers);
                }

                
            }*/
            ConsoleGameController controler = new ConsoleGameController(map);
        }

        private static void ImportMap(GameContext context, List<Map> maps, List<Hero> heroes, List<Level> levels)
        {
            var mapResult =
                Deserializer.ImportMaps(context,
                    maps);
            PrintEntity(mapResult);

            //var heroesResult =
            //   Deserializer.ImportHeroes(context,
            //       heroes);
            //PrintEntity(heroesResult);

            var levelsResult =
                Deserializer.ImportLevels(context,
                    levels);
            PrintEntity(levelsResult);
        }

        private static void ImportEntities(GameContext context, List<Enemy> enemies, List<Helper> helpers) // List<Item> items
        {
            var enemiesResult =
              Deserializer.ImportEnemies(context,
                   enemies);
            PrintEntity(enemiesResult);

            var helpersResult =
               Deserializer.ImportHelpers(context,
                   helpers);
            PrintEntity(helpersResult);

            //var itemsResult =
            //  Deserializer.ImportItems(context,
            //      items);
            //PrintEntity(itemsResult);
        }

        private static void PrintEntity(string entityOutput)
        {
            Console.WriteLine(entityOutput);

        }
    }
}
