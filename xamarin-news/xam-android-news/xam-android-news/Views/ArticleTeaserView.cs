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
using sharedproj.Models;
using Android.Graphics;
using sharedproj;

namespace xam_android_news.Views
{
    public class ArticleTeaserView : FrameLayout
    {
        LayoutInflater inflater;
        private const String TAG = "ArticleTeaserView";

        private TextView description;
        private TextView title;
        private ImageView image;

        public ArticleTeaserView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            Initialize();
        }

        public ArticleTeaserView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            inflater = (LayoutInflater) context.GetSystemService(Context.LayoutInflaterService);
            Initialize();
        }

        private void Initialize()
        {
            inflater.Inflate(Resource.Layout.article_teaser, this);
            initViews();
        }

        private void initViews()
        {
            title = FindViewById<TextView>(Resource.Id.teaserTitle);
            description = FindViewById<TextView>(Resource.Id.teaserDescription);
            image = FindViewById<ImageView>(Resource.Id.teaserImage);
        }

        public void SetModel(ArticleTeaser model)
        {
            try
            {
                Android.Net.Uri uri = Android.Net.Uri.Parse(model.promotionContent.imageAsset.urls[0].url);

                Log.Debug(TAG, "Image loading starting: " + uri);
                LoadAsync(model.promotionContent.imageAsset.GetUrlWithMinHeight(240));
                Log.Debug(TAG, "Image loading started: " + uri);
            } catch (Exception ex) {
                Log.Debug(TAG, ex.Message);
            }

            title.SetText(model.promotionContent.title.value, TextView.BufferType.Normal);
            description.SetText(model.promotionContent.description.value, TextView.BufferType.Normal);
        }

        private async void LoadAsync(String uri)
        {
            ImageSvc imgSvc = new ImageSvc();
            Bitmap bitmap = await imgSvc.asyncLoadIt(uri);
            Log.Debug(TAG, "Image load completed: " + uri);
            if (bitmap != null)
            {
                try
                {
                    image.SetImageBitmap(bitmap);
                }
                catch (Exception ex)
                {
                    Log.Debug(TAG, ex.Message);
                }
            }
        }
    }
}