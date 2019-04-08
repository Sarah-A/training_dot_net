﻿using System.Collections.Generic;
using DutchTreat.Data.Entities;

namespace AspDotNetCoreFromScratch.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
    }
}