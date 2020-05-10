﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameMVC.Model.Characters
{
    public class Creature
    {
        // TODO да са public и да са свойства, а не полета
        public string Name; // името на съществото
        int Health; // здравето му
        int Power; // силата му
        public int Experience; // опита, който има
        int Gold; // парите му
        List<Item> Items; // предметите, които притежава
        string Message; // съобщението, което носи това същество

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
            Health <= 0;  // FIXME добави return, и надолу има такива
        }

        bool IsVictimOf(Creature attacker) // дали може да бъде победен от друг
        {
            Health <= attacker.Power;
        }

        public virtual void WonVictoryOver(Creature victim) // какво става като победи друг            
        {
            Gold += victim.Gold;
            AcquireItem(victim.Items);
            // взима Gold, Experience и Items(с AcquireItem и LoseItem) на victim
        }

        void Fight(Creature opponent)
        {
            while (opponent.Health > 0 && Health > 0) // това продължава, докато един от двамата не умре 
            {
                opponent.Health -= Power; // бием се с някой намалява victim.Health със нашия Power 
            }
            // WonVictoryOver(opponent); за победителя викаме WonVictoryOver()
        }

        void Deal(Creature seller) // търгуваме с някой         
        {
            // намали нашия Gold (ако сме направили покупка)
            // получаваме един или повече от Items(с AcquireItem и LoseItem) от seller
        }

        public virtual bool CanHaveItem(Item item) // дали това същество може да има този предмет
        {
            return false;
        }

        void AcquireItem(Item item) // придобиваме предмет
        {
            if (CanHaveItem(item)) // първо проверяваме дали може да го притежаваме с CanHaveItem
            {
                Items.Add(item); // добавя се към нашите Items
                // увеличава нашите Health, Power, Gold
            }
            else
            {
                throw new ArgumentException("You can't have this item!");
                // (може и да не можем! - тогава хвърляме изключение или връщаме false)
            }
            // Може да намали нашия Gold(ако сме направили покупка)
        }

        void LoseItem(Item item) // разделяме се с предмет
        {
            // намалява нашите Health, Power, Gold
            Items.Remove(item); // изтрива се от нашите Items
        }

        void Validate()
        {
            // проверка дали е валидно, ако не - хвърляме изключение
            // да има име на съществото и то да е валидно име за играта
            // да има здраве 100
            // да има заредени първоначално само валидни предмети(проверяваме с CanHaveItem)
        }
    }
}
