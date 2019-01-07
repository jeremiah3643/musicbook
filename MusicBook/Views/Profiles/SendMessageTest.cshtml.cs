using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MusicBook.Data;
using MusicBook.Models;

namespace MusicBook.Views.Profiles
{
    public class SendMessageTestModel : PageModel
    {
        public SendMessageTestModel() { }
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public SendMessageTestModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public string SendToId { get; set; }
        public string SentFromId { get; set; }

        public SendMessageTestModel(MusicBook.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MessageInput messageInput { get; set; }
        public class MessageInput
        {
            [Display(Name = "Subject")]
            public string Subject { get; set; }
            [Required]
            [Display(Name = "Message")]
            public string MessageBody { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
           
            if (!ModelState.IsValid)
            {
                return Page();
            }
           var sendingMessage = new Message { SendToId = SendToId, SentFromId = SentFromId, Subject = messageInput.Subject, MessageBody = messageInput.MessageBody,};
            SendToId = SendToId;

            _context.Messages.Add(sendingMessage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}