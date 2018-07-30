using System.Collections.Generic;
using SQLite;

namespace ConcertGenerator.Models
{


   public class Player
    {
        [PrimaryKey]
        public string Name { get; set; }

 
    }
}