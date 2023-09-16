using Nusama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nusama.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader CreateTransactionHeader(int nextId, DateTime date, int id, string add, string method)
        {
            return new TransactionHeader
            {
                transactionId = nextId,
                transactionDate = date,
                customerId = id,
                address = add,
                paymentMethod = method
            };
        }
    }
}