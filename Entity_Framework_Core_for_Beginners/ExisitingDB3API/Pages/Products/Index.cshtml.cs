﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExisitingDB3API.Data;
using ExisitingDB3API.Models;

namespace ExisitingDB3API.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ExisitingDB3API.Data.ContosoPizzaPart1Context _context;

        public IndexModel(ExisitingDB3API.Data.ContosoPizzaPart1Context context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}