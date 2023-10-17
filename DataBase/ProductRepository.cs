﻿using Core.Entities;
using Core.Interface;
using Core.Interface.Repository;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataBase
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMemoryCache _memoryCache;
        private const string productKey = "productKey";

        public ProductRepository(IMemoryCache memoryCache) =>
            _memoryCache = memoryCache;
        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            if (!_memoryCache.TryGetValue(productKey, out IEnumerable<Product>? data))
            {
                using var client = new HttpClient();
                using HttpResponseMessage response = await client.GetAsync("https://dummyjson.com/products?limit=200");

                var str = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<ProductsDb>(str, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });
                data = result?.Products;
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1));
                _memoryCache.Set(productKey, data, cacheEntryOptions);
            }
            return data;
        }
    }
}
