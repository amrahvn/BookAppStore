﻿
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

        public Book(string name,double price,double discountPrice,BookCategory category,BookWriter writer)
        {
            _id++;
            Id = _id;

            Name = name;
            Price = price;
            DiscountPrice = discountPrice;
            Category = category;
            Writer = writer;
            CreatedTime = DateTime.UtcNow.AddHours(4);
            
        }

        public override string ToString()
        {
            if (DiscountPrice < Price)
            {
                return $"There is: {Price-DiscountPrice} discount, Name:{Name},Price:{DiscountPrice},Category:{Category},Author:{Writer},DateTime:{CreatedTime},UpDate:{UpdatedTime}";
            }
            return $"Name:{Name},Price:{Price},Category:{Category},Author:{Writer},DateTime:{CreatedTime},UpDate{UpdatedTime}";
        }
    }
}