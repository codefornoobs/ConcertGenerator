using System.Collections.Generic;

namespace ConcertGenerator
{
    public enum InstrumentType { Voice, Guitar, GuitarPT };

   public class Player
    {
        public string Name;

        public List<InstrumentType> _instruments;
        public Player(string name)
        {
            Name = name;
            _instruments=new List<InstrumentType>();
        }

        public void AddNewIntrument(InstrumentType instrument)
        {
            if (_instruments.Contains(instrument))
                return;

            _instruments.Add(instrument);
        }

        public void RemoveInstrument(InstrumentType instrument)
        {
            if (!_instruments.Contains(instrument))
                return;

            _instruments.Remove(instrument);
        }

        public void RemoveAllInstruments()
        {
            _instruments.Clear();
        }

        public List<InstrumentType> GetAllInstruments()
        {
            return  _instruments;
        }
    }
}