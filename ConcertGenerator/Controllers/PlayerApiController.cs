using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ConcertGenerator.Models;
using ConcertGenerator.Globals;
using SQLite;

namespace ConcertGenerator.Controllers
{
    class PlayerApiController
    {
        
        public static void InitializeDatabase()
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "ConcertGenerator.db3");
            var db = new SQLiteConnection(path);

            db.CreateTable<Player>();
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "ConcertGenerator.db3");
            var db = new SQLiteConnection(path);
           return db.Table<Player>();

        }


        public void AddNewPlayer(string playerName, List<InstrumentType> instruments)
        {
            var player = new Player
            {
                Name = playerName,
                //Instruments = instruments
            };
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "ConcertGenerator.db3");
            var db = new SQLiteConnection(path);
            db.Insert(player);

        }

        public void AddNewPlayer(Player newPlayer)
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "ConcertGenerator.db3");
            var db = new SQLiteConnection(path);
            db.Insert(newPlayer);

        }

        public void AddNewIntrumentToPlayer(string playerName,InstrumentType instrument)
        {
            var db = GetPlayerByName(playerName, out var player);

            if(player == null) return;

           // if (player.Instruments.Contains(instrument))
           //     return;

            //player.Instruments.Add(instrument);

            db.Update(player);
        }

        private static SQLiteConnection GetPlayerByName(string playerName, out Player player)
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "ConcertGenerator.db3");
            var db = new SQLiteConnection(path);

            player = db.Table<Player>().FirstOrDefault(s => s.Name == playerName);
            return db;
        }

        public void RemoveInstrumentFromPlayer(string playerName,InstrumentType instrument)
        {
            var db = GetPlayerByName(playerName, out var player);

            if(player==null) return;

           // if (!player.Instruments.Contains(instrument))
          //      return;

          //  player.Instruments.Remove(instrument);

            db.Update(player);
        }

        public void RemoveAllInstrumentsFromPlayer(string playerName)
        {
            var db = GetPlayerByName(playerName, out var player);

         //   player.Instruments.Clear();

            db.Update(player);
        }

        public List<InstrumentType> GetAllInstrumentsFromPlayer(string playerName)
        {
            var db = GetPlayerByName(playerName, out var player);
            return null;
            // return player.Instruments;
        }
    }
}