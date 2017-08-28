using Android.App;
using Android.Widget;
using Android.OS;
using System;
using sharedproj;

namespace xam_android_news
{
    [Activity(Label = "xam_android_news", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView resultTextView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            InitViews();
            BindView();
            LoadDataAsync();
        }

        private void InitViews()
        {
            resultTextView = FindViewById<TextView>(Resource.Id.result_text);
        }

        private void LoadDataAsync()
        {
            var svc = new NewsService();
            var promContent = svc.syncLoadStrong();
            string title = "?";
            if (promContent.Count > 0) title = promContent[0].promotionContent.title.value;
            resultTextView.SetText(title, TextView.BufferType.Normal);
        }

        private void BindView()
        {
            resultTextView.SetText("Yay", TextView.BufferType.Normal);
        }
    }
}

