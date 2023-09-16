using Nusama.Factory;
using Nusama.Handler;
using Nusama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nusama.Repository
{
    public class TransactionRepository
    {
        public static DatabaseEntities db = SingletonDatabase.GetInstance();
        public static void CreateNewTransaction(int tranId, DateTime date, int custId, string method, string add)
        {
            TransactionHeader th = TransactionHeaderFactory.CreateTransactionHeader(tranId, date, custId, add, method);
            db.TransactionHeaders.Add(th);
            db.SaveChanges();

            List<Cart> clist = (from x in db.Carts where x.customerId == custId select x).ToList();

            foreach (Cart c in clist)
            {
                int nextId = IdGenerator.GenerateTransactionItemID();
                TransactionDetail td = TransactionDetailFactory.CreateTransactionDetail(nextId, tranId, Convert.ToInt32(c.productId), Convert.ToInt32(c.quantity));
                db.TransactionDetails.Add(td);
                db.SaveChanges();
            }

            foreach(Cart c in clist)
            {
                db.Carts.Remove(c);
                db.SaveChanges();
            }
        }

        public static List<TransactionHeader> GetAllTransaction(int customerId)
        {
            List<TransactionHeader> th = (from x in db.TransactionHeaders where x.customerId == customerId select x).ToList();
            return th;
        }

        public static TransactionHeader GetTransactionHeader(int tranId)
        {
            TransactionHeader th = (from x in db.TransactionHeaders where x.transactionId == tranId select x).FirstOrDefault();
            return th;
        }

        public static List<TransactionItem> GetAllTransactionItem(int id)
        {
            List<TransactionItem> td = (from t in db.TransactionDetails
                                        join p in db.Products on t.productId equals p.productId
                                        where t.transactionId == id
                                        select new TransactionItem
                                        {
                                            productId = t.productId,
                                            quantity = t.quantity,
                                            productName = p.productName,
                                            price = p.productPrice,
                                            image = p.productImage
                                        }).ToList();
            return td;
        }
    }

    public class TransactionItem
    {
        public int? productId { get; set; }
        public int? quantity { get; set; }
        public string productName { get; set; }
        public int? price { get; set; }
        public string image { get; internal set; }
    }
}