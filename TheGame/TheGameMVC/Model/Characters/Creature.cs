using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGameMVC.Model.Game_Engine;

namespace TheGameMVC.Model.Characters
{
    public class Creature
    {
        public int Id { get; set; }
        public string Name { get; set; } // името на съществото
        [NotMapped]
        public int Health { get; set; } // здравето му
        public int Power { get; set; } // силата му
        public int Experience { get; set; } // опита, който има
        public int Gold { get; set; } // парите му
        public virtual List<Item> Items { get; set; }  // предметите, които притежава
        [ForeignKey("LevelId")]
        public virtual int? LevelId { get; set; }
        public virtual Level Level { get; set; }

        public Creature() : this("", 0, 0, 0, "") { }

        public Creature(string name, int power, int experience, int gold, string message)
        {
            Name = name;
            Health = 100;
            Power = power;
            Experience = experience;
            Gold = gold;
            Items = new List<Item>();
        }

        bool IsDead() // дали е умрял
        {
            return Health <= 0;
        }

        public virtual void WonVictoryOver(Creature victim) // TEST какво става като победи друг            
        {
            Gold += victim.Gold; 
            victim.Gold = 0; 
            for(var i = 0; i<victim.Items.Count; i++)
            {
                var item = victim.Items[i];
                if (CanHaveItem(item)) // първо проверяваме дали може да го притежаваме с CanHaveItem
                {
                    AcquireItem(item);
                    victim.LoseItem(item);
                    i--;
                }
            }
        }

        public virtual bool CanHaveItem(Item item) // дали това същество може да има този предмет
        {
            return false;
        }

        public void AcquireItem(Item item) // TEST придобиваме предмет
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
            }
        }

        public void LoseItem(Item item) // TEST разделяме се с предмет
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
            }
        }

        void Validate() // TEST проверка дали е валидно, ако не - хвърляме изключение
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

        public override string ToString()
        {
            return $"{Name}: {Health} HP, {Experience} XP, {Power} DMG and {Items.Count} items";
        }
    }
}