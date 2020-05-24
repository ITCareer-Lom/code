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
        public List<Item> Items { get; set; }  // предметите, които притежава
        public string Message { get; set; } // съобщението, което носи това същество

        public Creature() : this("", 0, 0, 0, "") { }

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

        public virtual void WonVictoryOver(Creature victim) // какво става като победи друг            
        {
            Gold += victim.Gold;
            victim.Gold = 0;
            foreach (Item item in victim.Items)
            {
                if (CanHaveItem(item)) // първо проверяваме дали може да го притежаваме с CanHaveItem
                {
                    AcquireItem(item);
                    victim.LoseItem(item);
                }
            }
        }

        public bool Fight(Creature opponent)
        {
            while (opponent.Health > 0 || Health > 0) // това продължава, докато един от двамата не умре 
            {
                opponent.Health -= Power; // бием се с някой намалява victim.Health със нашия Power 
                Health -= opponent.Power;
            }
            var success = Health > 0;
            if(success) // за победителя викаме WonVictoryOver()
                WonVictoryOver(opponent);
            else opponent.WonVictoryOver(this);
            return success;
        }

        public bool Deal(Creature seller) // търгуваме с някой         
        {
            if (Gold < seller.Gold)
                return false;
            else
            {
                // преглеждаме дали има предмети които можем да притежаваме
                // получаваме един или повече от Items(с AcquireItem и LoseItem) от seller
                foreach (Item i in seller.Items)
                {
                    CanHaveItem(i);
                    AcquireItem(i);
                    seller.LoseItem(i);
                }
                Gold -= seller.Gold; // намали нашия Gold (ако сме направили покупка)
                return true;
            }
        }

        public virtual bool CanHaveItem(Item item) // дали това същество може да има този предмет
        {
            return false;
        }

        void AcquireItem(Item item) // придобиваме предмет
        {
            Items.Add(item); // добавя се към нашите Items
            switch(item.Type)
            {
                // увеличава нашите Health, Power, Gold
                case ItemType.Health:
                    Health += item.UpgradeValue;
                    break;
                case ItemType.Gold:
                    Gold += item.UpgradeValue;
                    break;
                case ItemType.Power:
                    Power += item.UpgradeValue;
                    break;
                // HELP case ItemType.Other: 
            }
        }

        void LoseItem(Item item) // разделяме се с предмет
        {
            Items.Remove(item); // изтрива се от нашите Items
            switch (item.Type)
            {
                // намалява нашите Health, Power, Gold
                case ItemType.Health:
                    Health -= item.UpgradeValue;
                    break;
                case ItemType.Gold:
                    Gold -= item.UpgradeValue;
                    break;
                case ItemType.Power:
                    Power -= item.UpgradeValue;
                    break;
                // HELP case ItemType.Other:
            }
        }

        void Validate() //проверка дали е валидно, ако не - хвърляме изключение
        {
            if (Name == "") // да има име на съществото и то да е валидно име за играта
                throw new ArgumentException("The Creature has no name.");
            if (Health != 100) // да има здраве 100
                throw new ArgumentException("Тhe Creature must have health 100.");
            // да има заредени първоначално само валидни предмети(проверяваме с CanHaveItem)
            foreach (Item i in Items)
            {
                if (!CanHaveItem(i))
                    throw new ArgumentException($"The Creature can't have {i} item.");
            }
        }
    }
}