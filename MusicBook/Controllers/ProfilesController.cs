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
    public class ProfilesController : Controller
    {
        


        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ProfilesController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
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

        public async Task<IActionResult> Search(string inputField)
        {
            var user = await _userManager.GetUserAsync(User);
            var checkUser = _context.ApplicationUsers.Where(au => au.UserName.Contains(inputField)).ToList();
            var playerInstrumentList = _context.PlayerInstruments.Include(pi => pi.Instrument).Include(au => au.ApplicationUser).Where(pi => pi.Instrument.InstrumentName.Contains(inputField)).ToList();

            List<ApplicationUser> finalResults = playerInstrumentList.Select(inst => inst.ApplicationUser).ToList();
            List<ApplicationUser> readout = new List<ApplicationUser>();

            var allResults = finalResults.Union(checkUser);

            foreach(ApplicationUser person in allResults)
            {
                if( person.Id != user.Id)
                {
                    readout.Add(person);
                }
            }
            return View(readout.ToList());
        }


        // GET: Profile/Details/5
        public async Task<IActionResult> Details(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
            /* var profile = await _context.ApplicationUsers
                 .FirstOrDefaultAsync(p => p.Id == id.ToString());
                 */
            var user = await _context.ApplicationUsers.FirstOrDefaultAsync(p => p.Id == id.ToString());
            List<Instrument> AllInstruments = _context.Instruments.ToList();
            var UserInstruments = _context.PlayerInstruments.Include(pi => pi.Instrument).Where(inst => inst.ApplicationUserId == id).ToList();
            List<Instrument> userInstrumentList = UserInstruments.Select(inst => inst.Instrument).ToList();

            ExternalProfileViewModel ExternalInfo = new ExternalProfileViewModel();
            ExternalInfo.ExternalUser = user;
            ExternalInfo.UserInstruments = userInstrumentList;
            return View(ExternalInfo);
        }
    }
}