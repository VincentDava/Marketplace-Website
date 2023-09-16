using Nusama.Model;
using Nusama.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nusama.Handler
{
    public class IdGenerator
    {
        public static DatabaseEntities db = SingletonDatabase.GetInstance();
        public static int GenerateProductID()
        {
            bool isTableEmpty = !db.Products.Any();
            if (isTableEmpty)
            {
                return 0;
            }
            else
            {
                int nextId = (db.Products.Max(c => c.productId)) + 1;
                return nextId;
            }
        }

        public static int GenerateCustomerID()
        {
            bool isTableEmpty = !db.Customers.Any();
            if (isTableEmpty)
            {
                return 0;
            }
            else
            {
                int nextId = (db.Customers.Max(c => c.customerId)) + 1;
                return nextId;
            }
        }

        public static int GenerateCartID()
        {
            bool isTableEmpty = !db.Carts.Any();
            if (isTableEmpty)
            {
                return 0;
            }
            else
            {
                int nextId = (db.Carts.Max(c => c.cartId)) + 1;
                return nextId;
            }
        }

        public static int GenerateColorID()
        {
            bool isTableEmpty = !db.ColorOptions.Any();
            if (isTableEmpty)
            {
                return 0;
            }
            else
            {
                int nextId = (db.ColorOptions.Max(c => c.optionId)) + 1;
                return nextId;
            }
        }

        public static int GenerateSizeID()
        {
            bool isTableEmpty = !db.SizeOptions.Any();
            if (isTableEmpty)
            {
                return 0;
            }
            else
            {
                int nextId = (db.SizeOptions.Max(c => c.optionId)) + 1;
                return nextId;
            }
        }

        public static int GenerateTransactionID()
        {
            bool isTableEmpty = !db.TransactionHeaders.Any();
            if (isTableEmpty)
            {
                return 0;
            }
            else
            {
                int nextId = (db.TransactionHeaders.Max(c => c.transactionId)) + 1;
                return nextId;
            }
        }

        public static int GenerateTransactionItemID()
        {
            bool isTableEmpty = !db.TransactionDetails.Any();
            if (isTableEmpty)
            {
                return 0;
            }
            else
            {
                int nextId = (db.TransactionDetails.Max(c => c.transactionDetailId)) + 1;
                return nextId;
            }
        }

        public static int GenerateCommentID()
        {
            bool isTableEmpty = !db.Comments.Any();
            if (isTableEmpty)
            {
                return 0;
            }
            else
            {
                int nextId = (db.Comments.Max(c => c.commentId)) + 1;
                return nextId;
            }
        }
    }
}