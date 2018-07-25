using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ConcertGenerator.Models;
using SQLite;

namespace ConcertGenerator.Controllers
{
    class PlayerApiController
    {
        public static void InitializeDatabase()
        {
            var db = new SQLiteConnection(Globals.Globals.DbConnectionString);

            db.CreateTable<Player>();
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            var db = new SQLiteConnection(Globals.Globals.DbConnectionString);
           return db.Table<Player>();

        }


        public void AddNewPlayer(string playerName, List<InstrumentType> instruments)
        {
            var player = new Player
            {
                Name = playerName,
                Instruments = instruments
            };
            var db = new SQLiteConnection(Globals.Globals.DbConnectionString);
            db.Insert(player);

        }

        public void AddNewPlayer(Player newPlayer)
        {
          var db = new SQLiteConnection(Globals.Globals.DbConnectionString);
            db.Insert(newPlayer);

        }

        public void AddNewIntrumentToPlayer(string playerName,InstrumentType instrument)
        {
            var db = GetPlayerByName(playerName, out var player);

            if(player == null) return;

            if (player.Instruments.Contains(instrument))
                return;

            player.Instruments.Add(instrument);

            db.Update(player);
        }

        private static SQLiteConnection GetPlayerByName(string playerName, out Player player)
        {
            var db = new SQLiteConnection(Globals.Globals.DbConnectionString);

            player = db.Table<Player>().FirstOrDefault(s => s.Name == playerName);
            return db;
        }

        public void RemoveInstrumentFromPlayer(string playerName,InstrumentType instrument)
        {
            var db = GetPlayerByName(playerName, out var player);

            if(player==null) return;

            if (!player.Instruments.Contains(instrument))
                return;

            player.Instruments.Remove(instrument);

            db.Update(player);
        }

        public void RemoveAllInstrumentsFromPlayer(string playerName)
        {
            var db = GetPlayerByName(playerName, out var player);

            player.Instruments.Clear();

            db.Update(player);
        }

        public List<InstrumentType> GetAllInstrumentsFromPlayer(string playerName)
        {
            var db = GetPlayerByName(playerName, out var player);

            return player.Instruments;
        }
    }
}