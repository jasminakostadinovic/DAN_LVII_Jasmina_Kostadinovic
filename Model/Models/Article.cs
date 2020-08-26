using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Model.Models
{
    [DataContract]
    public class Article 
    {   
        public Article(string name, int remainingQuantity, decimal price)
        {
            Name = name;
            RemainingQuantity = remainingQuantity;
            Price = price;
            Id = GenerateId();
        }

        [DataMember]
        public string Id { get; protected set; }

        [DataMember]
        public string Name { get; protected set; }

        [DataMember]
        public int RemainingQuantity { get; protected set; }

        [DataMember]
        public decimal Price { get; protected set; }

        private string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }

        public override string ToString()
        {
            return ($"Article: {Name}, Remaining quantity: {RemainingQuantity},"
                + $"Price: {Price.ToString("C", CultureInfo.CurrentCulture)}");
        }

        public void UpdateArticlePrice(decimal price)
        {
            Price = price;
        }

    }
}
