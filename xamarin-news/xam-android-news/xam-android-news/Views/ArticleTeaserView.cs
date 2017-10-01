using System;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using sharedproj.Models;
using Android.Graphics;
using sharedproj;
using System.Threading.Tasks;
using xam_android_news.Messages;

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
        private Android.Net.Uri uri;

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
            // Todo invoke listener
            String articleId = model.id;
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send(new ArticleClickedMessage(articleId));
        }

        private ArticleTeaser model;

        private static int ctr = 0;
        public void SetModel(ArticleTeaser model)
        {
            this.model = model;
            try
            {
                uri = Android.Net.Uri.Parse(model.promotionContent.imageAsset.urls[0].url);
                container.Tag = model.id;
                
            } catch (Exception ex) {
                Log.Debug(TAG, ex.Message);
            }

            title.SetText(model.promotionContent.title.value, TextView.BufferType.Normal);
            description.SetText(model.promotionContent.description.value, TextView.BufferType.Normal);
        }

        public Task<Bitmap> LoadImageAsync()
        {
            return LoadImageAsync(uri.ToString());
        }

        private async Task<Bitmap> LoadImageAsync(String uri)
        {
            Log.Debug(TAG, "Image " + (++ctr) + " load starting...");
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
            Log.Debug(TAG, "Image " + ctr + " load started");
            return bitmap;
        }
    }
}