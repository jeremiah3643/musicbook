using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MusicBook.Models.ViewModels
{
    public class EditProfileViewModel
    {
    public List<Instrument> AllInstruments { get; set; }
    public List<Instrument> UserInstruments { get; set; }
    public List<int> PreselectedInstrumentIds { get; set; }


    public List<SelectListItem> AllInstrumentsOptions
        { get
            {
                if (AllInstruments == null)
                {
                    return null;
                }

                PreselectedInstrumentIds = UserInstruments.Select((ui) => ui.InstrumentId).ToList();

                List<SelectListItem> allOptions = AllInstruments
                    .Select((ai) => new SelectListItem(ai.InstrumentName, ai.InstrumentId.ToString()))
                    .ToList();

                foreach (int Id in PreselectedInstrumentIds)
                {
                    foreach (SelectListItem sli in allOptions) {
                        if (sli.Value == Id.ToString())
                        {
                           sli.Selected = true;
                        }
                    }
                }
                return allOptions;
            }
                }


    }
}
