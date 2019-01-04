using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicBook.Models.ViewModels
{
    public class HomeViewModel
    {
        // need all current user info and list of instruments
       public List<Instrument> UserInstruments { get; set; }
       public ApplicationUser CurrentUser { get; set; }
        


    }
}
