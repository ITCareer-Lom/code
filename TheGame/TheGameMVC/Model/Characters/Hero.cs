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
                        throw new ArgumentOutOfRangeException("Knight power have to be in [20..50]");
                    }
                    if (!(Gold == 250))
                    {
                        throw new ArgumentOutOfRangeException("Knight gold have to be 250");
                    }
                    break;
/*                case "Magician":
                    result = (Creature.Power == [10...50]) ||
                             (Creature.Money == 200) break;
                case "Dwarf":
                    result = (Creature.Power == [15...25]) ||
                             (Creature.Money == 100) break;
                case "Princess":
                    result = (Creature.Power == [10...30]) ||
                             (Creature.Money == 250) break;
                case "Villager":
                    result = (Creature.Power == [10...40]) ||
                             (Creature.Money == 130) break;
                case "Turtle":
                    result = (Creature.Power == [20...50]) ||
                             (Creature.Money == 250) break;
                case "Goddes":
                    result = (Creature.Power == [20...50]) ||
                             (Creature.Money == 100) break;

                default: break;
*/            }                 
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
                    if(CanHaveItem(i))
                    {
                        AcquireItem(i);
                        seller.LoseItem(i);
                        hasBoughtItems = true;
                    }
                }
                if(hasBoughtItems)
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
