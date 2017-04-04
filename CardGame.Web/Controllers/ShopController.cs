using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardGame.DAL.Model;
using CardGame.DAL.Logic;
using CardGame.Web.Models;

namespace CardGame.Web.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            List<Shop> Packlist = new List<Shop>();
            var dbPacklist = ShopManager.GetAllPacks();

            foreach (var p in dbPacklist)
            {
                Shop Pack = new Shop();
                Pack.PackID = p.idpack;
                Pack.Packname = p.packname;
                Pack.Packprice = (int)p.packprice;
                Pack.Gold = p.gold;
                Pack.Cardquantity = p.cardquantity;

                Packlist.Add(Pack);
            }            

            return View(Packlist);
        }
    }
}