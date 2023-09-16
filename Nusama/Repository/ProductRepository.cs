using Nusama.Controller;
using Nusama.Factory;
using Nusama.Handler;
using Nusama.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Nusama.Repository
{
    public class ProductRepository
    {
        public static DatabaseEntities db = SingletonDatabase.GetInstance();
        public static Product findProductByID(int id)
        {
            Product productFound = (from x in db.Products where x.productId == id select x).FirstOrDefault();
            return productFound;
        }

        public static List<Product> getAllProductByCustomerID(int id)
        {
            List<Product> productFound = new List<Product>();

            var data = (from x in db.Products where x.customerId == id select x).ToList();

            productFound.AddRange(data);
            return productFound;
        }

        public static List<string> GetColorOptionsForProduct (int id)
        {
            List<string> colorList = new List<string>();

            var colors = db.ColorOptions.Where(c => c.productId == id).Select(c => c.colorName).ToList();
            colorList.AddRange(colors);

            return colorList;
        }

        public static List<ColorOption> GetColorOption(int id)
        {
            List<ColorOption> target = (from x in db.ColorOptions where x.productId == id select x).ToList();
            return target;
        }

        public static List<string> GetSizeOptionsForProduct(int id)
        {
            List<string> sizeList = new List<string>();

            var sizes = db.SizeOptions.Where(c => c.productId == id).Select(c => c.productSize).ToList();
            sizeList.AddRange(sizes);

            return sizeList;
        }

        public static List<SizeOption> GetSizeOption(int id)
        {
            List<SizeOption> target = (from x in db.SizeOptions where x.productId == id select x).ToList();
            return target;
        }

        public static void registerNewProduct(int id, int productid, string name, int price, string desc, string category, string path)
        {
            Product newProduct = ProductFactory.CreateProduct(id, productid, name, price, desc, category, path);
            db.Products.Add(newProduct);
            db.SaveChanges();
        }

        public static void deleteProduct(int id)
        {
            Product targetProduct = (from x in db.Products where x.productId == id select x).FirstOrDefault();

            List<ColorOption> clist = (from x in db.ColorOptions where x.productId == id select x).ToList();
            List<SizeOption> slist = (from x in db.SizeOptions where x.productId == id select x).ToList();
            List<Comment> commentList = (from x in db.Comments where x.productId == id select x).ToList();

            foreach (var x in clist)
            {
                ColorOption target = (from i in db.ColorOptions where i.productId == x.productId select i).FirstOrDefault();
                db.ColorOptions.Remove(target);
                db.SaveChanges();
            }

            foreach (var x in slist)
            {
                SizeOption target = (from i in db.SizeOptions where i.productId == x.productId select i).FirstOrDefault();
                db.SizeOptions.Remove(target);
                db.SaveChanges();
            }

            foreach (var x in commentList)
            {
                Comment target = (from i in db.Comments where i.productId == x.productId select i).FirstOrDefault();
                db.Comments.Remove(target);
                db.SaveChanges();
            }

            db.Products.Remove(targetProduct);
            db.SaveChanges();
        }


        public static void deleteCart(int id)
        {
            Cart targetCart = (from x in db.Carts where x.cartId == id select x).FirstOrDefault();
            db.Carts.Remove(targetCart);
            db.SaveChanges();
        }

        //COMMENT

        public static List<CommentContent> GetCommentsOfProduct(int id)
        {
            List<CommentContent> comments = new List<CommentContent>();
            
            var komen = (from x in db.Comments join c in db.Customers on x.customerId equals c.customerId
                            where x.productId == id
                            select new CommentContent
                            {
                                customerName = c.customerName,
                                commentTitle = x.commentTitle,
                                commentContent = x.commentContent,
                                commentRating = x.commentRating
                            }).ToList();
            comments.AddRange(komen);

            return comments;
        }

        public static List<CartContent> GetCartProduct(int id)
        {
            List<CartContent> cartContents = new List<CartContent>();

            var cart = (from x in db.Carts
                         join p in db.Products on x.productId equals p.productId
                         join c in db.Customers on x.customerId equals c.customerId
                         where x.customerId == id
                         select new CartContent
                         {
                             productName = p.productName,
                             productImage = p.productImage,
                             productPrice = p.productPrice,
                             productQuantity = x.quantity,
                             productColor = x.productColor,
                             productSize = x.productSize,
                             cartId = x.cartId
                         }).ToList();
            cartContents.AddRange(cart);

            return cartContents;
        }

        public static void addNewCart(int customerId, int productId, int Qty, string Color, string Size)
        {
            Customer cust = CustomerRepository.findCustomerByID(customerId);
            if (cust != null && ProductValidation.validateCart(Qty, Color, Size))
            {
                int nextId = IdGenerator.GenerateCartID();
                Cart newCart = CartFactory.CreateCart(customerId, productId, Qty, Color, Size, nextId);
                db.Carts.Add(newCart);
                db.SaveChanges();
            }
        }

        public static void updateProduct(int id, string name, int price, string desc, string path)
        {
            Product currentProduct = (from x in db.Products where x.productId == id select x).FirstOrDefault();
            currentProduct.productName = name;
            currentProduct.productPrice = price;
            currentProduct.productDesc = desc;
            currentProduct.productImage = path;
            
            db.SaveChanges();
        }

        public static void deleteOldPicture(int id)
        {
            Product currentProduct = (from x in db.Products where x.productId == id select x).FirstOrDefault();
            string path = "~" + currentProduct.productImage;
            string physicalPath = HttpContext.Current.Server.MapPath(path);

            if (File.Exists(physicalPath))
            {
                File.Delete(physicalPath);
            }

        }

        public static string getProductImage(int id)
        {
            Product currentProduct = (from x in db.Products where x.productId == id select x).FirstOrDefault();
            return currentProduct.productImage;
        }

        public static void addColorOption(int productId, string colorName)
        {
            int nextId = IdGenerator.GenerateColorID();
            ColorOption newColor = ColorFactory.CreateColor(productId, colorName, nextId);
            db.ColorOptions.Add(newColor);
            db.SaveChanges();
        }

        public static void deleteColorOption(int productId, string colorName)
        {
            ColorOption target = (from x in db.ColorOptions where x.productId == productId && x.colorName == colorName select x).FirstOrDefault();
            db.ColorOptions.Remove(target);
            db.SaveChanges();
        }

        public static void addSizeOption(int productId, string size)
        {
            int nextId = IdGenerator.GenerateSizeID();
            SizeOption newSize = SizeFactory.CreateColor(productId, size, nextId);
            db.SizeOptions.Add(newSize);
            db.SaveChanges();
        }

        public static void deleteSizeOption(int productId, string sizeName)
        {
            SizeOption target = (from x in db.SizeOptions where x.productId == productId && x.productSize == sizeName select x).FirstOrDefault();
            db.SizeOptions.Remove(target);
            db.SaveChanges();
        }

        public static List<Product> findProduct(string keyword)
        {
            List<Product> list = (from x in db.Products where x.productName.Contains(keyword) select x).ToList();
            return list;
        }

        public static void addNewComment(int custId, int prodId, string title, string content, float rating)
        {
            int nextId = IdGenerator.GenerateCommentID();
            Comment newComment = CommentFactory.CreateCart(nextId, custId, prodId, title, content, rating);
            db.Comments.Add(newComment);
            db.SaveChanges();
        }
    }
    
    public class CartContent
    {
        public string productName { get; set; }
        public string productImage { get; set; }
        public int? productPrice { get; set; }
        public int? productQuantity { get; set; }
        public string productColor { get; set; }
        public string productSize { get; set; }
        public int cartId { get; set; }
    }

    public class CommentContent
    {
        public string customerName { get; set; }
        public string commentTitle { get; set; }
        public string commentContent { get; set; }
        public double? commentRating { get; set; }
    }
}