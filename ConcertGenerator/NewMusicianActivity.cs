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
using ConcertGenerator.Controllers;
using ConcertGenerator.Models;
using Newtonsoft.Json;

namespace ConcertGenerator
{
    [Activity(Label = "Add Musician", MainLauncher = true)]
    public class NewMusicianActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewMusician);

            var musiciansListButton = (Button)FindViewById(Resource.Id.btnListMusician);
            var addNewMusician = (Button)FindViewById(Resource.Id.btnAddNewMusician);

            musiciansListButton.Click += LoadMusiciansListActivity;
            addNewMusician.Click += AddNewMusicianOnClick;

            PlayerApiController.InitializeDatabase();
        }

        private void AddNewMusicianOnClick(object sender, EventArgs e)
        {
            var playerName = (EditText)FindViewById(Resource.Id.txtMusician);
            var cbVoice = (CheckBox)FindViewById(Resource.Id.cbVoice);
            var cbGuitar= (CheckBox)FindViewById(Resource.Id.cbGuitar);
            var cbGuitarPt = (CheckBox)FindViewById(Resource.Id.cbBass);

            var playerApi = new PlayerApiController();


            var instruments = CheckInstrumentsSelected(cbVoice, cbGuitar, cbGuitarPt);

            playerApi.AddNewPlayer(playerName.Text,instruments);
        }

        private static List<InstrumentType> CheckInstrumentsSelected(CheckBox cbVoice, CheckBox cbGuitar, CheckBox cbGuitarPt)
        {
            var instruments = new List<InstrumentType>();
            if (cbVoice.Checked)
                instruments.Add(InstrumentType.Voice);
            if (cbGuitar.Checked)
                instruments.Add(InstrumentType.Guitar);
            if (cbGuitarPt.Checked)
                instruments.Add(InstrumentType.GuitarPt);

            return instruments;
        }

        private void LoadMusiciansListActivity(object sender, EventArgs e)
        {
            var playerApi = new PlayerApiController();

            var intent = new Intent(this,typeof(MusiciansListActivity));
            intent.PutExtra("players", JsonConvert.SerializeObject(playerApi.GetAllPlayers()));

            StartActivity(intent);
        }
    }
}