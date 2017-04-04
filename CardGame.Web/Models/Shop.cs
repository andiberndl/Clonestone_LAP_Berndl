using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.Web.Models
{
    public class Shop
    {
        public int PackID { get; set; }

        public string Packname { get; set; }

        public int Packprice { get; set; }

        public int Cardquantity { get; set; }

        public string Picturename { get; set; }

        public int Gold { get; set; }
    }
}