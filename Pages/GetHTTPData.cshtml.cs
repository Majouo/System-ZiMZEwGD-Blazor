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
    public class GetHTTPDataModel : PageModel
    {
        private readonly System_ZiMZEwGD_Blazor.Data.ApplicationDbContext _context;

        public GetHTTPDataModel(System_ZiMZEwGD_Blazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Consumption Consumption { get; set; } = new Consumption();
        public System_ZiMZEwGD_Blazor.Data.Monitor Monitor = new System_ZiMZEwGD_Blazor.Data.Monitor("PI", "test", "192.168.1.5", 8000,"test");
        public HTTPdata hTTPdata { get; set; } = new HTTPdata();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Consumption == null || Consumption == null)
            {
                return Page();
            }

            Consumption = await hTTPdata.get(Monitor, "output");
            Console.WriteLine("test");
            _context.Consumption.Add(Consumption);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
