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
using Newtonsoft.Json;

namespace ConcertGenerator
{
    [Activity(Label = "MusiciansListActivity")]
    public class MusiciansListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

          

            // Create your application here
            SetContentView(Resource.Layout.MusiciansList);

            var test = Intent.GetSerializableExtra("players");
            var player = JsonConvert.DeserializeObject<List<Player>>(test.ToString());
        }
    }
}