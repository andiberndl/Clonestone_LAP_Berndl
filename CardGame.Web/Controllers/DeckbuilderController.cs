using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardGame.Web.Models;
using CardGame.DAL.Logic;
using CardGame.DAL.Model;
using CardGame.Log;

namespace CardGame.Web.Controllers
{
    public class DeckbuilderController : Controller
    {
        // GET: Deckbuilder
        public ActionResult Index(int UserId)
        {
            List<CollectionCard> CardList = new List<CollectionCard>();

            var dbCardList = DeckManager.GetCollectionCards(UserId);

            foreach (var cl in dbCardList)
            {
                CollectionCard card = new CollectionCard();
                card.Pic = cl.pic;

                CardList.Add(card);
            }

            return View(CardList );
        }
    }
}