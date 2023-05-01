
using BookStore.Core.Enum;
using BookStore.Core.Models.Base;

namespace BookStore.Core.Models
{
    public class Book:BaseModels
    {
        private  static int _id;  
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public BookCategory Category { get; set; }
        public BookWriter Writer { get; set; }
        public bool BookInStock { get;set; }

        public Book(string name,double price,double discountPrice,BookCategory category,BookWriter writer,bool bookInStock)
        {
            _id++;
            Id = _id;

            Name = name;
            Price = price;
            DiscountPrice = discountPrice;
            Category = category;
            Writer = writer;
            BookInStock = bookInStock;
            CreatedTime = DateTime.UtcNow.AddHours(4);
            
        }

        public override string ToString()
        {
            if (DiscountPrice < Price)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                return $"There is Discount Price:{" "}{Price-DiscountPrice} {" "}, Name:{Name},Category:{" "}{Category}{" "},DateTime:{" "}{CreatedTime}{" "},UpDate:{" "}{UpdatedTime}{" "},BookINStock:{" "}{BookInStock}";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                return $"Name:{" "}{Name}{" "},Price:{" "}{Price}{" "},Category:{" "}{Category}{" "},BookINStock:{" "}{BookInStock},DateTime:{" "}{CreatedTime}{" "},UpDate:{" "}{UpdatedTime}";
            } 
           
        }
    }
}

