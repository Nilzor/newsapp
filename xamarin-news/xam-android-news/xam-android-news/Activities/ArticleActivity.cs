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
using sharedproj;
using Java.Lang;
using xam_android_news.ArticleLogic;
using Android.Support.V7.Widget;
using Android.Util;
using sharedproj.ViewModels;

namespace xam_android_news.Activities
{
    /// <summary>
    /// Activity presenting article content
    /// </summary>
    [Activity(Label = "@string/ApplicationName")]
    public class ArticleActivity : Activity
    {
        private static string TAG = "Article";

        private RecyclerView RecyclerView { get; set; }
        private TextView ErrorTextView { get; set; }
        private ProgressBar ProgressBar { get; set; }
        public dynamic Article { get; set; }

        private ArticleViewModel ViewModel; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var articleId = Intent.Extras.GetString("ArticleId");
            SetContentView(Resource.Layout.article_activity);
            InitViews();
            ViewModel = new ArticleViewModel(new NewsService());
            ViewModel.PropertyChanged += (sender, e) => Bind();
            Bind();
            ViewModel.LoadArticle(articleId);
        }

        private void InitViews()
        {
            RecyclerView = FindViewById<RecyclerView>(Resource.Id.article_container);
            RecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            ErrorTextView = FindViewById<TextView>(Resource.Id.article_error_view);
            ProgressBar = FindViewById<ProgressBar>(Resource.Id.article_progressbar);
        }

        // Manual data binding 
        private void Bind()
        {
            RecyclerView.Visibility = ViewModel.Article == null ? ViewStates.Gone : ViewStates.Visible;
            ErrorTextView.Visibility = ViewModel.IsErrorMessageVisible ? ViewStates.Visible : ViewStates.Gone;
            ProgressBar.Visibility = ViewModel.IsProgressBarVisible ? ViewStates.Visible : ViewStates.Gone;
            ErrorTextView.Text = ViewModel.ErrorMessage;
            if (ViewModel.Article != null)
            {
                ArticleActivityAdapter adapter = new ArticleActivityAdapter(this, ViewModel.Article);
                RecyclerView.SetAdapter(adapter);
            }
        }

        /// <summary>
        /// Creates an intent for launching this activity for a speicified article
        /// </summary>
        public static Intent CreateIntent(Context context, string articleId)
        {
            Intent intent = new Intent(context, typeof(ArticleActivity));
            intent.PutExtra("ArticleId", articleId);
            return intent;
        }
    }
}