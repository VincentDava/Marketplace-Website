using Nusama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nusama.Factory
{
    public class CommentFactory
    {
        public static Comment CreateCart(int nextId, int custId, int prodId, string title, string content, float rating)
        {
            return new Comment
            {
                customerId = custId,
                productId = prodId,
                commentId = nextId,
                commentTitle = title,
                commentContent = content,
                commentRating = rating
            };
        }
    }
}