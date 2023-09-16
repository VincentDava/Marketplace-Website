
using Nusama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nusama.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail CreateTransactionDetail(int nextId, int tranId, int productId, int qty)
        {
            return new TransactionDetail
            {
                transactionId = tranId,
                productId = productId,
                quantity = qty,
                transactionDetailId = nextId
            };
        }
    }
}