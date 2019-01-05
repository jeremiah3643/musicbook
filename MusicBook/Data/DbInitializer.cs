using Microsoft.EntityFrameworkCore;
using MusicBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicBook.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            //Looks for instruments
            if (context.Instruments.Any())
            {
                return;
            }
            var instruments = new Instrument[]
            {
                new Instrument{InstrumentName = "Bass"},
                new Instrument{InstrumentName = "Guitar"},
                new Instrument{InstrumentName = "Drums"},
                new Instrument{InstrumentName = "Piano"},
                new Instrument{InstrumentName = "Keyboard"},
                new Instrument{InstrumentName = "Vocals"},
                new Instrument{InstrumentName = "Violin"},
                new Instrument{InstrumentName = "Upright Bass"},
                new Instrument{InstrumentName = "Banjo"},
                new Instrument{InstrumentName = "Mandolin"},
                new Instrument{InstrumentName = "Cello"},
                new Instrument{InstrumentName = "Viola"},
                new Instrument{InstrumentName = "Saxophone"},
            };
            foreach(Instrument i in instruments)
            {
                context.Instruments.Add(i);
            }
            context.SaveChanges();
        }

    }
}
