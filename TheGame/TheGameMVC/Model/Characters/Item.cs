using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameMVC.Model.Characters
{
    // Sword - меч
    // Shield - щит
    public class Item
    {
     [Key]
    public int ItemId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int UpgradeValue { get; set; }

     public ItemGroup Type { get; set; }
        
        public enum ItemGroup
        {
            Power =0,
            Health = 1,
            Gold = 2,
            Other = 3
        }
        
        public class ItemGroupPower
        {
          
            string name = "Sword";
            string name = "Magic Stick";
            string name = "Gun";
            string name = "Cannon";
            string name = "Axe";

           // тези предмети увеличават силата на героите
            int Sword;
            int MagicStick =  +55;
            int Gun;
            int Cannon = +65;
            int Axe = +70;

      
        }
        public class ItemGroupHealth
        {
            string name = "Armor";
            string name = "Medicinal Decoction";
            string name = "Herbs";
            string name = "Food";

            // тези предмети увеличават здравето на героите
            int Armor;
            int MedicinalDecoction = +50;
            int Herbs = +10;
            int Food = +25;
        }
        public class ItemGroupGold
        {

            string name = "Purse with Money";
            string name = "Gold";
            string name = "Silver";

            // тези предмети увеличават парите на героите
            int PurseWithMoney = +200;
            int Gold = +400;
            int Silver;
        }
        public class ItemGroupOther
        {
            //тези предмети са необхадими за убиване на някой злодей
            string name = "Holy water";
            string name = "Spike";
            string name = "Book with Magic";

           
        }
    
    } 
}
