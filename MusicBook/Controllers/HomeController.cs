using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicBook.Data;
using MusicBook.Models;
using MusicBook.Models.ViewModels;

namespace MusicBook.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager< ApplicationUser > signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            List<Instrument> AllInstruments = _context.Instruments.ToList();
           
            var UserInstruments = _context.PlayerInstruments.Include(pi => pi.Instrument).Where(inst => inst.ApplicationUserId == user.Id).ToList();
            List<Instrument> userInstrumentList = UserInstruments.Select(inst => inst.Instrument).ToList();
            
            HomeViewModel currentHomeInfo = new HomeViewModel();
            currentHomeInfo.CurrentUser = user;
            currentHomeInfo.UserInstruments = userInstrumentList;
        
            
            return View(currentHomeInfo);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
