using Android.App;
using Android.Widget;
using Android.OS;

namespace xam_android_news
{
    [Activity(Label = "xam_android_news", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
        }
    }
}

