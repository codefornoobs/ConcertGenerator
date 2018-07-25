using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcertGenerator.Models;

namespace ConcertGenerator.Test
{
    [TestFixture]
    public class PayerTest
    {
        [Test]
        public void NewPlayerTest()
        {
            var newPlayer = new Player("Diogo");

            Assert.AreEqual("Diogo", newPlayer.Name);
            Assert.AreEqual(0, newPlayer.GetAllInstruments().Count);
        }


        [Test]
        public void AddNewGuitarInstrument()
        {
            var newPlayer = new Player("Diogo");

            newPlayer.AddNewIntrument(InstrumentType.Guitar);
          
            Assert.AreEqual(1, newPlayer.GetAllInstruments().Count);
            Assert.AreEqual(InstrumentType.Guitar, newPlayer.GetAllInstruments()[0]);
        }
        [Test]
        public void AddNewGuitarPtAndVoiceInstruments()
        {
            var newPlayer = new Player("Diogo");

            newPlayer.AddNewIntrument(InstrumentType.Guitar);
            newPlayer.AddNewIntrument(InstrumentType.Voice);

            Assert.AreEqual(2, newPlayer.GetAllInstruments().Count);
            Assert.AreEqual(InstrumentType.Guitar, newPlayer.GetAllInstruments()[0]);
            Assert.AreEqual(InstrumentType.Voice, newPlayer.GetAllInstruments()[1]);
        }

        [Test]
        public void AddNewInstrumentsMultipletimes()
        {
            var newPlayer = new Player("Diogo");

            newPlayer.AddNewIntrument(InstrumentType.Guitar);
            newPlayer.AddNewIntrument(InstrumentType.Guitar);
            newPlayer.AddNewIntrument(InstrumentType.GuitarPt);

            Assert.AreEqual(2, newPlayer.GetAllInstruments().Count);
            Assert.AreEqual(InstrumentType.Guitar, newPlayer.GetAllInstruments()[0]);
            Assert.AreEqual(InstrumentType.GuitarPt, newPlayer.GetAllInstruments()[1]);
        }
        [Test]
        public void RemoveInstrumentGuitar()
        {
            var newPlayer = new Player("Diogo");

            newPlayer.AddNewIntrument(InstrumentType.Guitar);
            newPlayer.AddNewIntrument(InstrumentType.GuitarPt);
            newPlayer.RemoveInstrument(InstrumentType.Guitar);

            Assert.AreEqual(1, newPlayer.GetAllInstruments().Count);
            Assert.AreEqual(InstrumentType.GuitarPt, newPlayer.GetAllInstruments()[0]);
        }
        [Test]

        public void RemoveAllInstruments()
        {
            var newPlayer = new Player("Diogo");

            newPlayer.AddNewIntrument(InstrumentType.Guitar);
            newPlayer.AddNewIntrument(InstrumentType.Voice);
            newPlayer.AddNewIntrument(InstrumentType.GuitarPt);

            Assert.AreEqual(3, newPlayer.GetAllInstruments().Count);

            newPlayer.RemoveAllInstruments();

            Assert.AreEqual(0, newPlayer.GetAllInstruments().Count);

        }
    }
}
