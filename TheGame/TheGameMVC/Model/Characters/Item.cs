using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameMVC.Model.Characters
{
    public class Item
    {
        public class ItemGroupPower
        {
          
            string name = "Sword";
            string name = "Magic Stick";
            string name = "Gun";
            string name = "Cannon";
            string name = "Axe";

           
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

            int PurseWithMoney = +200;
            int Gold = +400;
            int Silver;
        }
        public class ItemGroupOther
        {
            string name = "Holy water";
            string name = "Spike";
            string name = "Book with Magic";

           
        }
    } 
}
