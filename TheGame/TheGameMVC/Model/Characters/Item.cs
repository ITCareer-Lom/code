using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameMVC.Model.Characters
{
    // Sword - меч
    // Shield - щит
    //Gun - меч 
    //Magic Stick - магическа пръчка 
    //Axe - брадва 
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
    } 
}
