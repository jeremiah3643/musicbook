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
using static Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal.ExternalLoginModel;

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

        
        [BindProperty]
        public MessageData MessageInput { get; set; }
        public string ReturnUrl { get; set; }
        public class MessageData
        {
            [Display(Name = "Subject")]
            public string Subject { get; set; }

            [Display(Name = "Message")]
            public string MessageBody { get; set; }
        }



        public void OnGet(string returnUrl = null)
        {
            MessageInput = new MessageData();



            ReturnUrl = returnUrl;
        }

       

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var setDate = DateTime.Now;
           var sendingMessage = new Message { SendToId = SendToId, ApplicationUserId = SentFromId, Subject = MessageInput.Subject, MessageBody = MessageInput.MessageBody, MessageDate = setDate.ToString(),};
            var MessageBoxCreator = new MessageBox { ApplicationUserId = SentFromId, SenderId = SendToId, };

            _context.Add(sendingMessage);
            _context.Add(MessageBoxCreator);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}