using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForgetMeNot.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly ForgetMeNot.Data.ApplicationDbContext _context;

        public IndexModel(ForgetMeNot.Data.ApplicationDbContext context)
        {
            _context = context;
        }

    }
}
