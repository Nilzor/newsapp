using Android.App;
using Android.Widget;
using Android.OS;
using System;
using sharedproj;
using sharedproj.Models;
using xam_android_news.Views;
using Android.Views;

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
            BindView(null);
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

            BindView(promContent);
            string title = "?";
            if (promContent.Count > 0) title = promContent[0].promotionContent.title.value;
            resultTextView.SetText(title, TextView.BufferType.Normal);
        }

        private void BindView(ArticleList list)
        {
            resultTextView.SetText("Yay", TextView.BufferType.Normal);
            ViewGroup scroller = FindViewById<ViewGroup>(Resource.Id.scroller);
            if (list != null)
            {
                foreach (ArticleTeaser teaser in list ) 
                {
                    ArticleTeaserView atv = new ArticleTeaserView(this, null);
                    atv.SetModel(teaser);
                    scroller.AddView(atv);
                }
            }
        }
    }
}

