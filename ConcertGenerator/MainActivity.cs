using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace ConcertGenerator
{
    [Activity(Label = "ConcertGenerator")]
    public class MainActivity : Activity
    {
        private Button _btnInsert;

        private IList<string> Songs;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Songs = new List<string>();

            //_btnInsert = (Button)FindViewById(Resource.Id.BtnInsert);
           // _btnInsert.Click += InsertAction;

        }

        private void InsertAction(object sender, EventArgs e)
        {
            TextView txtSongName = (TextView)FindViewById(Resource.Id.TxtMusicName);
            LinearLayout svSongsList = (LinearLayout)FindViewById(Resource.Id.LlSongsList);

            if (txtSongName.Text.Length == 0)
                return;

            TextView v = new TextView(ApplicationContext) { Text = txtSongName.Text };
            v.LongClick += (s, es) =>
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Delete Song");
                alert.SetMessage("Do you want to delete this song?\n" + $"  \"{v.Text}\"");
                alert.SetPositiveButton("Delete", (d, w) => { svSongsList.RemoveView(v); alert.Dispose(); });
                alert.SetNegativeButton("Cancel", (d, w) => { alert.Dispose(); });
                alert.Show();
            };
            v.Clickable = true;

            svSongsList.AddView(v);
            Songs.Add(v.Text);
            txtSongName.Text = "";
        }

    }
}

