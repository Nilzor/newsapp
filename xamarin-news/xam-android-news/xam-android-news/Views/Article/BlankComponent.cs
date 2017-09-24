using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace xam_android_news.Views.Article
{
    public class BlankComponent : RecyclerView.ViewHolder, ArticleComponent
    {
        public BlankComponent(Context context) : base(CreateView(context))
        {
        }

        private static View CreateView(Context context)
        {
            var fl = new FrameLayout(context);
            var lp = new FrameLayout.LayoutParams(0,0);
            fl.LayoutParameters = lp;
            return fl;
        }

        public void SetData(dynamic data)
        { 
        }
    }
}