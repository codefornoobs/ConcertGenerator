using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.ObjectModel;

namespace ConcertGenerator
{
    [Activity(Label = "ConcertGenerator", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button _btnInsert;
        ObservableCollection<string> someList = new ObservableCollection<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            someList.Add("teste");
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            _btnInsert = (Button)FindViewById(Resource.Id.BtnInsert);

            _btnInsert.Click += InsertAction;

        }

        private void InsertAction(object sender, EventArgs e)
        {
            TextView txtSongName = (TextView)FindViewById(Resource.Id.TxtMusicName);
            LinearLayout svSongsList = (LinearLayout)FindViewById(Resource.Id.LlSongsList);

            if (txtSongName.Text.Length == 0)
                return;
            TextView v = new TextView(ApplicationContext) { Text = txtSongName.Text };
            v.LongClick += (s, es) => { txtSongName.Text = v.Text; };
            v.Clickable = true;

            svSongsList.AddView(v);

            txtSongName.Text = "";
        }
    }
}

