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
using Newtonsoft.Json;

namespace ConcertGenerator
{
    [Activity(Label = "Add Musician", MainLauncher = true)]
    public class NewMusicianActivity : Activity
    {
        private List<Player> _players = new List<Player>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewMusician);

            var musiciansListButton = (Button)FindViewById(Resource.Id.btnListMusician);
            var AddNewMusician = (Button)FindViewById(Resource.Id.btnAddNewMusician);

            musiciansListButton.Click += LoadMusiciansListActivity;
            AddNewMusician.Click += AddNewMusicianOnClick;
        }

        private void AddNewMusicianOnClick(object sender, EventArgs e)
        {
            var playerName = (EditText)FindViewById(Resource.Id.txtMusician);
            var cbVoice = (CheckBox)FindViewById(Resource.Id.cbVoice);
            var cbGuitar= (CheckBox)FindViewById(Resource.Id.cbGuitar);
            var cbGuitarPt = (CheckBox)FindViewById(Resource.Id.cbBass);

           var newPlayer = new Player(playerName.Text);

            if (cbVoice.Checked)
                newPlayer.AddNewIntrument(InstrumentType.Voice);
            if (cbGuitar.Checked)
                newPlayer.AddNewIntrument(InstrumentType.Guitar);
            if (cbGuitarPt.Checked)
                newPlayer.AddNewIntrument(InstrumentType.GuitarPT);

            _players.Add(newPlayer);
        }

        private void LoadMusiciansListActivity(object sender, EventArgs e)
        {
            var intent = new Intent(this,typeof(MusiciansListActivity));
            intent.PutExtra("players", JsonConvert.SerializeObject(_players));

            StartActivity(intent);
        }
    }
}