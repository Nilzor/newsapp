using Android.App;
using Android.Widget;
using Android.OS;
using System;
using sharedproj;
using sharedproj.Models;
using xam_android_news.Views;
using Android.Views;
using Android.Util;
using System.Collections.Generic;
using Android.Graphics;
using System.Threading.Tasks;

namespace xam_android_news
{
    [Activity(Label = "xam_android_news", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private const string TAG = "MainActivity";
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
        }

        private void LoadDataAsync()
        {
            var svc = new NewsService();
            var promContent = svc.syncLoadStrong();

            BindView(promContent);
        }

        private async void BindView(ArticleList list)
        {
            Log.Debug(TAG, "Binding MainActivity");
            ViewGroup scroller = FindViewById<ViewGroup>(Resource.Id.scroller);
            var tasks = new List<Task<Bitmap>>();
            if (list != null)
            {
                int i = 0;
                foreach (ArticleTeaser teaser in list ) 
                {
                    ArticleTeaserView atv = new ArticleTeaserView(this, null);
                    tasks.Add(atv.SetModel(teaser));
                    scroller.AddView(atv);
                }
            }
            await Task.WhenAll(tasks);
        }
    }
}

