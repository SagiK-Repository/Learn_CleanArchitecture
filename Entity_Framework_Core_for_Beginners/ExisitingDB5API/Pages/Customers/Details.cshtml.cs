using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExisitingDB3API.Data;
using ExisitingDB3API.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ExisitingDB5API.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly ExisitingDB3API.Data.ContosoPizzaPart1Context _context;

        public DetailsModel(ExisitingDB3API.Data.ContosoPizzaPart1Context context)
        {
            _context = context;
        }

        public Customer Customer { get; set; } = default!;
        public int CustomerId { get; private set; }
        public Product? Product { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnGetAsync(int? id, int customerId)
        {
            if (id == null)
                return NotFound();

            CustomerId = customerId;

            Product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
                return NotFound();

            if (CustomerId > 0)
                Customer = await _context.Customers
                    .FromSqlInterpolated($"SELECT * FROM Customers WHERE Id = {CustomerId}")
                    .FirstOrDefaultAsync();

            return Page();
        }
    }
}
