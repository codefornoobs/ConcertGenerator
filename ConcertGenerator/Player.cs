namespace ConcertGenerator
{
    class Player
    {
        public string Name;
        public enum InstrumentType { Voice, Guitar, GuitarPT };

        public int Instrument;
        public Player(string name, InstrumentType instrument)
        {
            Name = name;
            Instrument = (int)instrument;
        }
    }
}