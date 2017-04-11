using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.Web.Models
{
    public class CollectionCard
    {
        public int IdCard { get; set; }
        public int FkPerson { get; set; }
        public int FkOrder { get; set; }
        public int FkCard { get; set; }
        public string Cardname { get; set; }
        public int Attack { get; set; }
        public int Mana { get; set; }
        public int Life { get; set; }


    }
}