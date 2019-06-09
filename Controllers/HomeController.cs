using System.Linq;
using System.Threading.Tasks;
using ForgetMeNot.Models;
using ForgetMeNot.Models.ManageViewModels;
using ForgetMeNot.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ForgetMeNot.Data;
using System;


namespace ForgetMeNot.Controllers
{
    public class HomeController : Controller
    {


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public HomeController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ApplicationDbContext context,
        ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _logger = loggerFactory.CreateLogger<HomeController>();
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetEvents()
        {
            var userIdFilter = (await GetCurrentUserAsync()).Id.ToString();
            IQueryable<Event> userEvents = from e in _context.Event select e;

            if (!String.IsNullOrEmpty(userIdFilter))
            {
                userEvents = userEvents.Where(e => e.OwnerID.Equals(userIdFilter));

                return Json(userEvents);
            }

            return Json("");
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}