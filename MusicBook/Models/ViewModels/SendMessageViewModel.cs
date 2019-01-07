using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicBook.Models.ViewModels
{
    public class SendMessageViewModel
    {
        // Gets Ids from logged Users Id and the Profiles User Id
        public string SendToId { get; set; }
        public string SentFromId { get; set; }
        public Message Message { get; set; }

    }
}
