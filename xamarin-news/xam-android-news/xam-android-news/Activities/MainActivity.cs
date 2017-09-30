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
using xam_android_news.Activities;
using xam_android_news.Messages;

namespace xam_android_news
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private const string TAG = "MainActivity";
        TextView resultTextView;
        private List<ArticleTeaserView> TeaserList = new List<ArticleTeaserView>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.activity_main);
            InitViews();
            BindView(null);
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ArticleClickedMessage>(this, OnArticleClicked);
            //LoadDataAsync();
            LoadImages();
        }

        private void InitViews()
        {
        }

        public void OnArticleClicked(ArticleClickedMessage msg)
        {
            StartActivity(ArticleActivity.CreateIntent(this, msg.Id));
        }

        private async void LoadDataAsync()
        {
            var svc = new NewsService();
            var promContent = await svc.loadLatestList();
            BindView(promContent);
            //LoadImages();
        }

        private void BindView(ArticleList list)
        {
            Log.Debug(TAG, "Binding MainActivity");
            ViewGroup scroller = FindViewById<ViewGroup>(Resource.Id.scroller);
            if (list != null)
            {
                int i = 0;
                foreach (ArticleTeaser teaser in list)
                {
                    ArticleTeaserView atv = new ArticleTeaserView(this, null);
                    atv.SetModel(teaser);
                    scroller.AddView(atv);
                    TeaserList.Add(atv);
                }
            }
        }

        private async Task LoadImages()
        {
            var tasks = new List<Task<Bitmap>>();

            Log.Debug(TAG, "Starting image list load");
            foreach (ArticleTeaserView view in TeaserList)
            {
                var task = view.LoadImageAsync();
                if (task != null) tasks.Add(task);
            }
            
            Log.Debug(TAG, "Awaiting images...");
            await Task.WhenAll(tasks);

        }
    }
}

