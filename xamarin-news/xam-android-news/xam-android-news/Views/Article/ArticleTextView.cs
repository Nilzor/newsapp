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

        /// <summary>
        /// View constructor which inflates a view based on subtype
        /// </summary>
        internal static ArticleTextView Create(LayoutInflater inflater, dynamic component)
        {
            int viewId = ResolveViewFromSubtype((string) component.subtype);
            return new ArticleTextView(inflater.Inflate(viewId, null));
        }

        private static int ResolveViewFromSubtype(string subType)
        {
            switch (subType)
            {
                case "title": return Resource.Layout.comp_text_title;
                case "lead": return Resource.Layout.comp_text_lead;
                case "heading": return Resource.Layout.comp_text_heading;
                case "subtitle": return Resource.Layout.comp_text_heading;
                case "blockquote": return Resource.Layout.comp_text_blockquote;
                default: return Resource.Layout.comp_text;
            }
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