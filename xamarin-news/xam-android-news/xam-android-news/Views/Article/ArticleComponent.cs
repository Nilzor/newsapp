﻿using System;
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

namespace xam_android_news.Views.Article
{
    public interface ArticleComponent 
    {
        void SetData(dynamic data);
    }
}