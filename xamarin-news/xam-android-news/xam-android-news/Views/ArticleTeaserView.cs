﻿using System;
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

namespace xam_android_news.Views
{
    public class ArticleTeaserView : FrameLayout
    {
        LayoutInflater inflater;

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
                image.SetImageURI(Android.Net.Uri.Parse(model.promotionContent.imageAsset.urls[0].url));
            } catch (Exception ex) { }

            title.SetText(model.promotionContent.title.value, TextView.BufferType.Normal);
            description.SetText(model.promotionContent.description.value, TextView.BufferType.Normal);
        }
    }
}