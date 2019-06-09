using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForgetMeNot.Pages.Events
{
    public class UpcomingModel : PageModel
    {
        private readonly ForgetMeNot.Data.ApplicationDbContext _context;

        public UpcomingModel(ForgetMeNot.Data.ApplicationDbContext context)
        {
            _context = context;
        }

    }
}
