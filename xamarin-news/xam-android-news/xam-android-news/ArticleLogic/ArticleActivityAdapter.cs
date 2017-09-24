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
using xam_android_news.Views.Article;
using Android.Util;

namespace xam_android_news.ArticleLogic
{
    public class ArticleActivityAdapter : RecyclerView.Adapter
    {
        private const string TAG = "ArticleAdapter";
        private dynamic ArticleModel;
        private ComponentResolver Resolver;

        public ArticleActivityAdapter(Context context, dynamic articleModel)
        {
            ArticleModel = articleModel;
            Resolver = new ComponentResolver(context);
        }

        public override int ItemCount
        {
            get { return ArticleModel?.components?.Count ?? 0; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is ArticleComponent)
            {
                ((ArticleComponent)holder).SetData(ArticleModel.components[position]);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewPosition)
        {
            var context = parent.Context;
            dynamic componentModel = ArticleModel.components[viewPosition];
            var component = Resolver.GetComponentFor(context, componentModel);
            Log.Info(TAG, "Resolved component of type %s", componentModel.type);
            return component;
        } 

        public override int GetItemViewType(int position)
        {
            return position;
        }
    }
}