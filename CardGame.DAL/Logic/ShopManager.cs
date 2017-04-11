using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.DAL.Model;

namespace CardGame.DAL.Logic
{
    public class ShopManager
    {
        public static List<tblpack> GetAllPacks()
        {
            List<tblpack> returnList = null;
            using (var db = new ClonestoneFSEntities())
            {
                returnList = db.tblpack.ToList();
            }
            return returnList;
        }

        public static void OrderExec()
        {

        }


    }
}
