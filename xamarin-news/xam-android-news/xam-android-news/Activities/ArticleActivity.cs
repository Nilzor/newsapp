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

namespace xam_android_news.Activities
{
    /// <summary>
    /// Activity presenting article content
    /// </summary>
    [Activity(Label = "Article")]
    public class ArticleActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var articleId = Intent.Extras.GetString("ArticleId");
        }

        /// <summary>
        /// Creates an intent for launching this activity for a speicified article
        /// </summary>
        public static Intent CreateIntent(Context context, String articleId)
        {
            Intent intent = new Intent(context, typeof(ArticleActivity));
            intent.PutExtra("ArticleId", articleId);
            return intent;
        }
    }
}