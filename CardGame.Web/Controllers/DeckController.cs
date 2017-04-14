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
    public class DeckController : Controller
    {
        // GET: Deckbuilder
        public ActionResult Index()
        {
            List<CollectionCard> CardList = new List<CollectionCard>();

            var dbCardList = DeckManager.GetCollectionCards(UserManager.GetUserByEmail(User.Identity.Name).idperson);

            foreach (var cl in dbCardList)
            {
                CollectionCard card = new CollectionCard();
                card.FkOrder = cl.fkorder;
                
                card.IdCard = cl.idcard;
                card.Pic = cl.pic;

                CardList.Add(card);
            }

            return View(CardList );
        }
    }
}