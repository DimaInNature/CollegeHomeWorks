using System;
using System.Collections.Generic;
using Work2.Models.Base;

namespace Work2.Models
{
    public class ShopModel : BaseModel
    {
        public int ConsumerId { get; set; }
        public string Name { get; set; }
        public int DiscountInPercentage { get; set; }

        public ShopModel() => Id = RandomizeNewId();

        public static List<ShopModel> Create (int count)
        {
            var shops = new List<ShopModel>();

            count = count < 0 ? 0 : count;

            for (int i = 0; i < count; i++)
            {
                shops.Add(CreateRandom());
            }

            return shops;
        }

        public static List<ShopModel> EnumerableCreate(int count)
        {
            var shops = new List<ShopModel>();

            count = count < 0 ? 0 : count;

            for (int i = 0; i < count; i++)
            {
                var shop = CreateRandom(i);
                shops.Add(shop);
            }

            return shops;
        }

        public static ShopModel Create(int consumerId,
            string name, int discount) => new()
        {
            ConsumerId = consumerId,
            DiscountInPercentage = discount,
            Name = name
        };

        public override string ToString() =>
            $"Consumer id is {ConsumerId}, name is {Name}, " +
            $"Discount (in percentage) is {DiscountInPercentage}";

        private static ShopModel CreateRandom() => new()
        {
            Name = RandomNewName(),
            DiscountInPercentage = RandomNewDiscount(),
            ConsumerId = RandomNewConsumerId()
        };

        private static ShopModel CreateRandom(int id) => new()
        {
            Id = id,
            Name = RandomNewName(),
            DiscountInPercentage = RandomNewDiscount(),
            ConsumerId = RandomNewConsumerId()
        };

        private static string RandomNewName() =>
            $"Shop {new Random().Next(1,10)}";

        private static int RandomNewDiscount() =>
            new Random().Next(0, 100);

        private static int RandomNewConsumerId() =>
            new Random().Next(0, 10);
    }
}