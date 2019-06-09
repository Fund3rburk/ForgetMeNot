using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ForgetMeNot.Models;


namespace ForgetMeNot.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly ForgetMeNot.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(UserManager<ApplicationUser> userManager, ForgetMeNot.Data.ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Event Event { get; set ;}

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Event.OwnerID = (await _userManager.GetUserAsync(HttpContext.User)).Id;
            _context.Event.Add(Event);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}