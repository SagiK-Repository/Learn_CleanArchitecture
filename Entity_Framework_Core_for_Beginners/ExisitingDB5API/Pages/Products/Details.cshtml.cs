using System;
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
    public class DetailsModel : PageModel
    {
        private readonly ExisitingDB3API.Data.ContosoPizzaPart1Context _context;

        public DetailsModel(ExisitingDB3API.Data.ContosoPizzaPart1Context context)
        {
            _context = context;
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }
    }
}
