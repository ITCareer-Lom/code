using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameMVC.Model.Characters
{
    public class Hero : Creature
    {
        // TODO с главни букви и да са свойства
        //private string name; в Creature + Id
        private int health; 
        private int power; 
        private int experience; 
        private int gold;
        // TODO List<Item>
        private List items;

        public int Power
        {
            get => power;
            set => value;
        }

        public int gold
        {
            get => gold;
            set => value;
        }

       // List<string> heroes = new List<string>();
        // TODO конструктор без параметри
        public Hero(string name,  int power, int gold, List items) 
        {
            this.name = name;
            this.health = 100; 
            this.power = power;
            this.experience = 0;
            this.gold = gold;
            this.items = new List<Item>();
        }

        public void WonVictoryOver(Creature victim)
        {
            //увеличава Experience с victim.Experience
            experience = experience + victim.Experience;
        }

        //ToDo: проверка за всеки герой по отделно дали може да притежава даден предмет
        public override bool CanHaveItem(Item item)
        {
            var result = false;
            switch (Name)
            {
                case "Knight": result = (item.Name == "Sword") || (item.Name == "Shield"); break;
                // TODO същото за останалите типове герои
                default: break;
            }
            return result;
        }

        public void Validate()
        {
             //да има име на валиден герой в нашата игра
            //дали силата е до 50!
            // TODO както в класа Map
            Power <= 50;
            health <= 100; 
        }

    }
}
