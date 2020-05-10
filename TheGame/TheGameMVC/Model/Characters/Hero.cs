using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameMVC.Model.Characters
{
    public class Hero : Creature
    {
        // FIXME тези са за Creature и public
        private string Name{get; set; }
        private int Health{ get; set; } 
        private int Power{ get; set; } 
        private int Experience{ get; set; }  
        private int Gold{ get; set; } 
        private List<Item> Items;

        // FIXME тези са за Map и public
        private List<string> heroes = new List<string>();

        // TODO конструктор без параметри
        public Hero() 
        {
            // FIXME тези са за Creature 
            this.Name = name;
            this.Health = 100; 
            this.Power = power;
            this.Experience = 0;
            this.Gold = gold;
            this.Items = new List<Item>();
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
                case "Knight": result = (item.Name == "Sword") || 
                                        (item.Name == "Shield"); break;
                case "Magician": result = (item.Name == "Magic wand") || 
                                          (item.Name == "Holy water") || 
                                          (item.Name == "Magic book"); break;
                case "Dwarf": result = (item.Name == "Axe") || 
                                       (item.Name == "Sword") || 
                                       (item.Name == "Armor") || 
                                       (item.Name == "Herbs"); break;
                case "Princess": result = (item.Name == "Sword") || (item.Name == "Holy water"); break;
                case "Villager": result = (item.Name == "Gun"); break;
                case "Turtle": result = (item.Name == "Holy water") || (item.Name == "Food") || (item.Name == "Gold"); break;
                case "Goddes": result = (item.Name == "Axe") || (item.Name == "Sword") || (item.Name == "Armor") || (item.Name == "Gun"); break;

                default: break;
            }
            return result;
        }

        public void Validate()
        {
             //да има име на валиден герой в нашата игра
            foreach (var hero in heroes)
            {
                hero.Validate();
            }

            //дали силата е до 50!
            if (Power <= 0 || Power > 50) 
	        {
                throw new ArgumentOutOfRangeException("Power have to be in range (0, 50]");
	        }


            if (Health <= 0 || Health > 100)
            {
                throw new ArgumentOutOfRangeException("Health have to be in range (0, 100]");
            }
        }
    }
}
