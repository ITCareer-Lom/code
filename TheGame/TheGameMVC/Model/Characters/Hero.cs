using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameMVC.Model.Characters
{
    public class Hero : Creature
    {
        public static string characteristics { get; private set; }

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
            var result = false;
            switch (Power && Money)
            {
                //Experience не е ли част от характеристиките?
                //HELP 
                case "Knight":
                    result = (Creature.Power == [200...250]) ||
                             (Creature.Money == 250); break;
                case "Magician":
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
            }
        }
    }
}
