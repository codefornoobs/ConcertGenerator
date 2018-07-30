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
using SQLite;

namespace ConcertGenerator.Models
{
    class InstrumentApiController
    {
        public static void InitializeDatabase()
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "ConcertGenerator.db3");
            var db = new SQLiteConnection(path);

            db.CreateTable<Instrument>();
        }
    }
}