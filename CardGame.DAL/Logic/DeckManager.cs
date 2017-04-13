using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.DAL.Model;
using CardGame.Log;

namespace CardGame.DAL.Logic
{
    public class DeckManager
    {
        public static List<vCollectionCards> GetCollectionCards(int UserId)
        {
            List<vCollectionCards> ReturnList = null;
            using (var db = new ClonestoneFSEntities())
            {
                ReturnList = (from c in db.vCollectionCards
                              where c.fkperson == UserId
                              select c).ToList();
            }
            return ReturnList;
        }



    }
}
