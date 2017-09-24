using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace xam_android_news.Views.Article
{
    /// <summary>
    /// Represents any text section in an article.
    /// </summary>
    public class ArticleTextView : RecyclerView.ViewHolder, ArticleComponent
    {
        TextView TextView;

        public ArticleTextView(View view) : base(view)
        {
            TextView = (TextView) view;
        }

        private void Initialize()
        {
        }

        public void SetData(dynamic data)
        {
            TextView.Text = data.text.value;
        }
    }
}