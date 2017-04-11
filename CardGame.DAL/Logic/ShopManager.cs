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

        public static void OrderExec(int userID, int packID)
        {
            using (var db = new ClonestoneFSEntities())
            {
                tblorder order = new tblorder();
                tblcollection col = new tblcollection();
                Random r = new Random();

                order.fkpack = packID;
                order.fkperson = userID;
                order.orderdate = DateTime.Now;
                db.tblorder.Add(order);
                db.SaveChanges();

                int orderID = (from o in db.tblorder
                               orderby o.idorder descending
                               select o.idorder).ToList().FirstOrDefault();

                int cardq = (from p in db.tblpack
                                where p.idpack == packID
                                select p.cardquantity).ToList().FirstOrDefault();


                if (cardq != 0)
                {
                    try
                    {
                        var UpdatePerson = (from up in db.tblperson
                                            where up.idperson == userID
                                            select up);

                        var PriceForPack = (from pfp in db.tblpack
                                            where pfp.idpack == packID
                                            select pfp.packprice).ToList().FirstOrDefault();

                        foreach (var item in UpdatePerson)
                        {
                            item.currencybalance -= (int)PriceForPack;
                        }
                        db.SaveChanges();

                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    for (int i = 0; i < cardq; i++)
                    {
                        int rng = r.Next(1, 698);
                        var card = (from c in db.tblcard
                                    where c.idcard == rng
                                    select c).FirstOrDefault();

                        if (card != null)
                        {
                            col.fkperson = userID;
                            col.fkorder = orderID;
                            col.fkcard = card.idcard;

                            db.tblcollection.Add(col);
                            db.SaveChanges();
                        }
                        else
                        {
                            i = i - 1;
                        }
                    }

                    

                }

                else
                {
                    tblperson person = new tblperson();
                    var UpdatePerson = (from up in db.tblperson
                                        where up.idperson == userID
                                        select up);

                    var rupeeValue = (from rv in db.tblpack
                                      where rv.idpack == packID
                                      select rv.goldquantity).FirstOrDefault();

                    foreach (var item in UpdatePerson)
                    {
                        item.currencybalance += (int)rupeeValue;
                    }
                    db.SaveChanges();
                }

            }
        }


    }
}
