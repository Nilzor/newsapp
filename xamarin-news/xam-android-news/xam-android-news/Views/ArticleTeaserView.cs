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
using System.Threading.Tasks;

namespace xam_android_news.Views
{
    public class ArticleTeaserView : FrameLayout
    {
        LayoutInflater inflater;
        private const String TAG = "ArticleTeaserView";

        private TextView description;
        private TextView title;
        private ImageView image;
        private ViewGroup container;

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
            container = FindViewById<ViewGroup>(Resource.Id.teaserContainer);
            container.Click += Container_Click;
        }

        private void Container_Click(object sender, EventArgs e)
        {
            // Tod//o invoke listener
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send(new ArticleClickedMessage(model.id));
        }

        private ArticleTeaser model;

        private static int ctr = 0;
        public Task<Bitmap> SetModel(ArticleTeaser model)
        {
            this.model = model;
            Task<Bitmap> task = null;
            try
            {
                Android.Net.Uri uri = Android.Net.Uri.Parse(model.promotionContent.imageAsset.urls[0].url);
                container.Tag = model.id;
                //LoadAsync(model.promotionContent.imageAsset.GetUrlWithMinHeight(240));
                Log.Debug(TAG, "Image " + (++ctr) + " load starting...");
                task = LoadAsync(model.promotionContent.imageAsset.GetUrlWithMinHeight(240));
                Log.Debug(TAG, "Image " + ctr + " load started");
            } catch (Exception ex) {
                Log.Debug(TAG, ex.Message);
            }

            title.SetText(model.promotionContent.title.value, TextView.BufferType.Normal);
            description.SetText(model.promotionContent.description.value, TextView.BufferType.Normal);
            return task;
        }

        private async Task<Bitmap> LoadAsync(String uri)
        {
            ImageSvc imgSvc = new ImageSvc();
            Bitmap bitmap = await imgSvc.loadAndDecodeBitmap(uri);
            Log.Debug(TAG, "Image " + ctr + " load completed");
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
            return bitmap;
        }
    }
}