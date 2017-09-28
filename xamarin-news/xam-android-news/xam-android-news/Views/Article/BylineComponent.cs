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
using Android.Support.V7.Widget;
using Android.Content.Res;

namespace xam_android_news.Views.Article
{
    public class BylineComponent : RecyclerView.ViewHolder, ArticleComponent
    {

        public BylineComponent(View view) : base(view)
        {
        }

        public void SetData(dynamic data)
        {
            TextView textView = ItemView.FindViewById<TextView>(Resource.Id.byline_text);
            string byLine = "";
            int i = 0;
            foreach (dynamic author in data.authors) {
                if (i++ != 0) byLine += ", ";
                string name = author.title;
                byLine += name;
            }
            textView.SetText(byLine, TextView.BufferType.Normal);
        }

        internal static ArticleComponent Create(LayoutInflater inflater)
        {
            return new BylineComponent(inflater.Inflate(Resource.Layout.comp_byline, null));

        }
    }
}