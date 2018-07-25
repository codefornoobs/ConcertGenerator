using System.Collections.Generic;
using ConcertGenerator.Models;

namespace ConcertGenerator
{
    class Song
    {
        public string Name;
        public bool MustPlayInConcert;
        public List<Player> Players;
    }
}