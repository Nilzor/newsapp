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
using sharedproj;
using sharedproj.Models;
using System.Threading.Tasks;
using Android.Util;

namespace xam_android_news.Views.Article
{
    public class ImageComponent : RecyclerView.ViewHolder, ArticleComponent
    {
        ImageSvc ImageService;
        ImageView Image;
        TextView Caption;
        TextView Byline;

        public ImageComponent(View view) : base(view)
        {
            ImageService = new ImageSvc();
        }

        public static ImageComponent Create(LayoutInflater inflater)
        {
            ViewGroup viewRoot = (ViewGroup) inflater.Inflate(Resource.Layout.comp_image, null);
            var comp = new ImageComponent(viewRoot);
            comp.Image = viewRoot.FindViewById<ImageView>(Resource.Id.img_view);
            comp.Caption = viewRoot.FindViewById<TextView>(Resource.Id.img_caption);
            comp.Byline = viewRoot.FindViewById<TextView>(Resource.Id.img_byline);
            return comp;
        }

        public void SetData(dynamic data)
        {
            Caption.Text = data.caption.value;
            Byline.Text = data.byline.title;
            ParseAndLoadImage(data);
        }

        private async void ParseAndLoadImage(dynamic data)
        {
            string uri = GetUriFrom(data.imageAsset);
            var bitmap = await ImageService.loadAndDecodeBitmap(uri);
            Image.SetImageBitmap(bitmap);
        }

        private string GetUriFrom(dynamic data)
        {
            ImageAsset asset = ImageAsset.FromDynamic(data);
            return asset.GetUrlWithMinHeight(800);
        }
    }
}