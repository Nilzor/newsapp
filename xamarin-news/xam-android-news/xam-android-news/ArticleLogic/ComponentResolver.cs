using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using xam_android_news.Views.Article;
using Android.Views;

namespace xam_android_news.ArticleLogic
{
    /// <summary>
    /// Maps JSON data to Component Views
    /// </summary>
    public class ComponentResolver
    {
        LayoutInflater Inflater;
        public ComponentResolver(Context context)
        {
            Inflater = (LayoutInflater) context.GetSystemService(Context.LayoutInflaterService);
        }

        public ArticleComponent GetComponentFor(Context context, dynamic componentSegment)
        {
            string type = componentSegment.type;
            switch (type)
            {
                //case "text": return new ArticleTextView(context, null);
                case "text": return new ArticleTextView(Inflater.Inflate(Resource.Layout.comp_text, null));
            }
            return null;
        }
    }
}