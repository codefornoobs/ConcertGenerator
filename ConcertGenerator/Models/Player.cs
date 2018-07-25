using System.Collections.Generic;
using SQLite;

namespace ConcertGenerator.Models
{
    public enum InstrumentType { Voice, Guitar, GuitarPt };

   public class Player
    {
        [PrimaryKey]
        public string Name { get; set; }

        public List<InstrumentType> Instruments { get; set; }
       
      
    }
}