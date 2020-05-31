using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameMVC.Model.Characters
{
    public enum ItemType
    {
        Power = 0,
        Health = 1,
        Gold = 2
    }

    // Sword - меч
    // Shield - щит
    //Gun - меч 
    //Magic Stick - магическа пръчка 
    //Axe - брадва  - Увеличава силата с 70
    //Food - храна
    //Herbs - билки 
    //Armor - броня
    //Medicinal Decoction - лечебна отвара
    //Purse with money - кисия с пари 
    // Gold - злато
    //Silver - сребро
    //Holy Water - светена вода 
    //Spike - острие 
    // Book with magic - книга с магии
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int UpgradeValue { get; set; }
        public ItemType Type { get; set; }
    } 
}
