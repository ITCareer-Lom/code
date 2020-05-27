using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TheGameMVC.Model.Characters;
using TheGameMVC.Model.Game_Engine;

namespace TheGameMVC.Database.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportHero
            = "Successfully imported hero with health {0}, power {1}, experience {2}, money {3} and type {4}!";
        private const string SuccessfulImportEnemy
            = "Successfully imported enemy with health {0}, power {1}, money reward {2}!";
        private const string SuccessfulImportItem
            = "Successfully imported item with name {0}, upgrade value {1} and type {2}!";
        private const string SuccessfulImportLevel
           = "Successfully imported level with name {0}!";
        private const string SuccessfulImportHelper
          = "Successfully imported adventurer with name {0}!";
        private const string SuccessfulImportMap
         = "Successfully imported map with name {0}!";


        public static string ImportMaps(GameContext context, List<Map> maps)
        {
            var sb = new StringBuilder();

            foreach (var map in maps)
            {
                sb.AppendLine(string.Format(SuccessfulImportMap, map.Name));
            }

            context.Maps.AddRange(maps);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportHeroes(GameContext context, List<Hero> heroes)
        {
            var sb = new StringBuilder();

            foreach (var hero in heroes)
            {
                sb.AppendLine(string.Format(SuccessfulImportHero, hero.Health, hero.Power, hero.Experience, hero.Gold, hero.Name));
            }

            context.Heros.AddRange(heroes);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }


        public static string ImportLevels(GameContext context, List<Level> levels)
        {
            var sb = new StringBuilder();

            foreach (var level in levels)
            {
                sb.AppendLine(string.Format(SuccessfulImportLevel,  level.Name));
            }

            context.Levels.AddRange(levels);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }
        public static string ImportHelpers(GameContext context, List<Helper> helpers)
        {
            var sb = new StringBuilder();

            foreach (var helper in helpers)
            {
                sb.AppendLine(string.Format(SuccessfulImportHelper, helper.Name));
            }

            context.Helpers.AddRange(helpers);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportEnemies(GameContext context, List<Enemy> enemies)
        {
            var sb = new StringBuilder();

            foreach (var enemy in enemies)
            {
                sb.AppendLine(string.Format(SuccessfulImportEnemy, enemy.Name, enemy.Power, enemy.Gold));
            }

            context.Enemies.AddRange(enemies);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportItems(GameContext context, List<Item> items)
        {
            var sb = new StringBuilder();

            foreach (var item in items)
            {
                sb.AppendLine(string.Format(SuccessfulImportItem, item.Name, item.UpgradeValue, item.Type));
            }

            context.Items.AddRange(items);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }
    }
}
