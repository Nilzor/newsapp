﻿using System;
using System.Collections.Generic;

namespace sharedproj.Models
{
    public class ArticleTeaser
    {
        public string id { get; set; }
        public PromotionContent promotionContent { get; set; }
    }

    public class PromotionContent
    {
        public ValueString description { get; set; }
        public ValueString title { get; set; }
        public ImageAsset imageAsset { get; set; }
    }

    public class ImageAsset
    {
        public Size size { get; set; }
        public List<Url> urls { get; set; }
        public String GetUrlWithMinHeight(int height)
        {
            if (urls == null || urls.Count == 0) return null;
            foreach (Url url in urls)
            {
                if (url.height >= height) return url.url;
            }
            return urls[urls.Count - 1].url;
        }

        public static ImageAsset FromDynamic(dynamic src)
        {
            var asset = new ImageAsset();
            asset.urls = new List<Url>();
            asset.size = new Size();
            asset.size.width = (int) src.size.width;
            asset.size.height = (int) src.size.height;
            foreach (dynamic dynUrl in src.urls) {
                Url url = new Url();
                url.height = (int) dynUrl.height;
                url.width = (int) dynUrl.width;
                url.url = dynUrl.url;
                asset.urls.Add(url);
            }
            return asset;
        }
    }

    public class Size
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Url
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class ValueString
    {
        public ValueString() { }
        public ValueString(String text)
        {
            value = text;
        }
        public string value { get; set; }
    }
}
 