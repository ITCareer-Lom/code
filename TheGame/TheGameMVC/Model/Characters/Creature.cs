using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameMVC.Model.Characters
{
    public class Creature
    {
        public string Name { get; set; } // името на съществото
        public int Health { get; set; } // здравето му
        public int Power { get; set; } // силата му
        public int Experience { get; set; } // опита, който има
        public int Gold { get; set; } // парите му
        public List<Item> Items { get ; set; }  // предметите, които притежава
        public string Message { get; set; } // съобщението, което носи това същество

        public Creature(string name, int power, int experience, int gold, string message)
        {
            Name = name;
            Health = 100;
            Power = power;
            Experience = experience;
            Gold = gold;
            Items = new List<Item>();
            Message = message;
        }

        bool IsDead() // дали е умрял
        {
            return Health <= 0;
        }

        bool IsVictimOf(Creature attacker) // дали може да бъде победен от друг
        {
            return Health <= attacker.Power;
        }

        public virtual void WonVictoryOver(Creature victim) // какво става като победи друг            
        {
            Gold += victim.Gold;
            foreach (Item item in victim.Items)
            {
                AcquireItem(item);
            }
            //TODO взима Gold, Experience и Items(с AcquireItem и LoseItem) на victim
        }

        void Fight(Creature opponent)
        {
            while (opponent.Health > 0 && Health > 0) // това продължава, докато един от двамата не умре 
            {
                opponent.Health -= Power; // бием се с някой намалява victim.Health със нашия Power 
            }
            //TODO WonVictoryOver(opponent); за победителя викаме WonVictoryOver()
        }

        void Deal(Creature seller) //TODO търгуваме с някой         
        {
            // намали нашия Gold (ако сме направили покупка)
            // получаваме един или повече от Items(с AcquireItem и LoseItem) от seller
        }

        public virtual bool CanHaveItem(Item item) //TODO дали това същество може да има този предмет
        {
            return false;
        }

        void AcquireItem(Item item) // придобиваме предмет
        {
            if (CanHaveItem(item)) // първо проверяваме дали може да го притежаваме с CanHaveItem
            {
                Items.Add(item); // добавя се към нашите Items
                //TODO увеличава нашите Health, Power, Gold
                //TODO Може да намали нашия Gold(ако сме направили покупка)
            }
            else
            {
                throw new ArgumentException("You can't have this item!");
                // (може и да не можем! - тогава хвърляме изключение или връщаме false)
            }
        }

        void LoseItem(Item item) // разделяме се с предмет
        {
            //TODO намалява нашите Health, Power, Gold
            Items.Remove(item); // изтрива се от нашите Items
        }

        void Validate() //TODO
        {
            // проверка дали е валидно, ако не - хвърляме изключение
            // да има име на съществото и то да е валидно име за играта
            // да има здраве 100
            // да има заредени първоначално само валидни предмети(проверяваме с CanHaveItem)
        }
    }
}
