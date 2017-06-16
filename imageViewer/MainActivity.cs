using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using System.IO;

namespace imageViewer
{
	[Activity(Label = "imageViewer", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);
			ImageView imageView = FindViewById<ImageView>(Resource.Id.imageView1);

			button.Click += delegate
			{
				imageView.SetImageResource(Resource.Drawable.image);
				imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
			};

			string content;
			AssetManager assets = this.Assets;
			using (StreamReader sr = new StreamReader(assets.Open(("myText.txt"))))
			{
				content = sr.ReadToEnd();
			}

			Android.Util.Log.Debug("Message for you: ", content);
		}
	}
}

