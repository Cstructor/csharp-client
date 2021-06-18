using HelloWorld.Models;
using Microsoft.Extensions.Caching.Memory; // add
using System.Collections.Generic;

namespace HelloWorld
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }

    public class ProductRepository : IProductRepository
    {
        private IMemoryCache memoryCache;

        public ProductRepository(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public IEnumerable<Product> Products
        {
            get
            {
                Product[] items;

                if (!memoryCache.TryGetValue("MyProducts", out items))
                {
                    items = new[]
                        {
                        new Product{ ProductId=101, Name = "Baseball", Description="balls", Price=14.20m},
                        new Product{ ProductId=102, Name="Football", Description="nfl", Price=9.24m},
                        new Product{ Name="Tennis ball"} ,
                        new Product{ Name="Golf ball"},
                    };

                    //memoryCache.Set("MyProducts", items,
                    //    new MemoryCacheEntryOptions()
                    //    .SetAbsoluteExpiration(System.TimeSpan.FromSeconds(30)));

                    // Exercise 1 - Caching
                    memoryCache.Set("MyProducts", items,
                     new MemoryCacheEntryOptions()
                     .SetSlidingExpiration(System.TimeSpan.FromSeconds(5)));

                }

                return (Product[])memoryCache.Get("MyProducts"); ;
            }
        }
    }
}