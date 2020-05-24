using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameMVC.Model.Characters
{
    public class Hero : Creature
    {
        // конструктор без параметри
        public Hero() : base()
        {
        }

        // победили сме някакъв противник
        public override void WonVictoryOver(Creature victim)
        {
            base.WonVictoryOver(victim);
            //увеличава Experience с victim.Experience
            Experience = Experience + victim.Experience;
        }

        // проверка за всеки герой по отделно дали може да притежава даден предмет
        public override bool CanHaveItem(Item item)
        {
            var result = false;
            switch (Name)
            {
                case "Knight":
                    result = (item.Name == "Sword") ||
                             (item.Name == "Shield"); break;
                case "Magician":
                    result = (item.Name == "Magic wand") ||
                             (item.Name == "Holy water") ||
                             (item.Name == "Magic book"); break;
                case "Dwarf":
                    result = (item.Name == "Axe") ||
                             (item.Name == "Sword") ||
                             (item.Name == "Armor") ||
                             (item.Name == "Herbs"); break;
                case "Princess":
                    result = (item.Name == "Sword") ||
                             (item.Name == "Holy water"); break;
                case "Villager":
                    result = (item.Name == "Gun"); break;
                case "Turtle":
                    result = (item.Name == "Holy water") ||
                             (item.Name == "Food") ||
                             (item.Name == "Gold"); break;
                case "Goddes":
                    result = (item.Name == "Axe") ||
                             (item.Name == "Sword") ||
                             (item.Name == "Armor") ||
                             (item.Name == "Gun"); break;

                default: break;
            }
            return result;
        }

        public void Validate()
        {
            //дали силата е до 50!
            if (Power <= 0 || Power > 50)
            {
                throw new ArgumentOutOfRangeException("Power have to be in range (0, 50]");
            }


            if (Health != 100)
            {
                throw new ArgumentOutOfRangeException("Health have to be 100");
            }

            //проверка за валидни характеристики:
            switch (Name)
            {
                case "Knight":
                    if (!(Power >= 20 && Power <= 50))
                    {
                        throw new ArgumentOutOfRangeException("Knight power have to be in range (20..50]");
                    }
                    if (!(Gold == 250))
                    {
                        throw new ArgumentOutOfRangeException("Knight's gold have to be 250");
                    }
                    break;

                case "Magician":
                    if (!(Power >= 10 && Power <= 50))
                    {
                        throw new ArgumentOutOfRangeException("Magician power have to be in range (10..50]");
                    }
                    if (!(Gold == 200))
                    {
                        throw new ArgumentOutOfRangeException("Magician's gold have to be 200");
                    }
                    break;

                case "Dwarf":
                    if (!(Power >= 15 && Power <= 25))
                    {
                        throw new ArgumentOutOfRangeException("Dwarf power have to be in range (15..25]");
                    }
                    if (!(Gold == 100))
                    {
                        throw new ArgumentOutOfRangeException("Dwarf's gold have to be 100");
                    }
                    break;

                case "Princess":
                    if (!(Power >= 10 && Power <= 30))
                    {
                        throw new ArgumentOutOfRangeException("Princess power have to be in range (10..30]");
                    }
                    if (!(Gold == 250))
                    {
                        throw new ArgumentOutOfRangeException("Princess's gold have to be 250");
                    }
                    break;

                case "Villager":
                    if (!(Power >= 10 && Power <= 40))
                    {
                        throw new ArgumentOutOfRangeException("Villager power have to be in range (10..40]");
                    }
                    if (!(Gold == 130))
                    {
                        throw new ArgumentOutOfRangeException("Villager's gold have to be 130");
                    }
                    break;

                case "Turtle":
                    if (!(Power >= 20 && Power <= 50))
                    {
                        throw new ArgumentOutOfRangeException("Turtle power have to be in range (20..50]");
                    }
                    if (!(Gold == 250))
                    {
                        throw new ArgumentOutOfRangeException("Turtle's gold have to be 250");
                    }
                    break;

                case "Goddes":
                    if (!(Power >= 20 && Power <= 50))
                    {
                        throw new ArgumentOutOfRangeException("Goddes power have to be in range (20..50]");
                    }
                    if (!(Gold == 100))
                    {
                        throw new ArgumentOutOfRangeException("Goddes's gold have to be 100");
                    }
                    break;

            }
        }

        public bool Fight(Enemy opponent)
        {
            while (opponent.Health > 0 || Health > 0) // това продължава, докато един от двамата не умре 
            {
                opponent.Health -= Power; // бием се с някой намалява victim.Health със нашия Power 
                Health -= opponent.Power;
            }
            var success = Health > 0;
            if (success) // за победителя викаме WonVictoryOver()
                WonVictoryOver(opponent);
            else opponent.WonVictoryOver(this);
            return success;
        }

        public bool Deal(Helper seller) // търгуваме с някой         
        {
            if (Gold < seller.Price)
                return false;  // ако не ни стигат парите - чао
            else
            {
                // преглеждаме дали има предмети които можем да притежаваме
                // получаваме един или повече от Items(с AcquireItem и LoseItem) от seller
                var hasBoughtItems = false;
                foreach (Item i in seller.Items)
                {
                    if (CanHaveItem(i))
                    {
                        AcquireItem(i);
                        seller.LoseItem(i);
                        hasBoughtItems = true;
                    }
                }
                if (hasBoughtItems)
                {
                    Gold -= seller.Price;
                    seller.Gold += seller.Price;
                }
                // намали нашия Gold (ако сме направили покупка)
                return hasBoughtItems;
            }
        }
    }
}
