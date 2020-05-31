using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameMVC.Model.Characters
{
    public class Helper : Creature 
    {
        public int Price { get; set; }

        public Helper() : base()
        {
            Price = 0;
        }
    }
}
