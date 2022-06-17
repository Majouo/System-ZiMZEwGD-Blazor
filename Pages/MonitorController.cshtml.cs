using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System_ZiMZEwGD_Blazor.Data;

namespace System_ZiMZEwGD_Blazor.Pages
{
    public class MonitorControllerModel : PageModel
    {
        private readonly System_ZiMZEwGD_Blazor.Data.ApplicationDbContext _context;

        public MonitorControllerModel(System_ZiMZEwGD_Blazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Data.Monitor Monitor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Monitor == null || Monitor == null)
            {
                return Page();
            }

            _context.Monitor.Add(Monitor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
