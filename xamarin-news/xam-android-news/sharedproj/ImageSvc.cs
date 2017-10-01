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
using System.Net.Http;
using System.Net.Http.Headers;
using Android.Graphics;
using System.Threading.Tasks;
using Android.Util;

namespace sharedproj
{
    class ImageSvc
    {
        private static HttpClient client = new HttpClient();
        public async Task<Bitmap> loadAndDecodeBitmap(String uri) { 
            try
            {
                byte[] data = await client.GetByteArrayAsync(uri);

                Log.Info("MainActivity", "Load completed " + uri);
                Bitmap img = BitmapFactory.DecodeByteArray(data, 0, data.Length);
                return img;
            } catch (Exception ex)
            {
                Log.Debug("ImageService", String.Format("Failed loading image {0}: {1}", uri, ex.Message));
                return null;
            }
        }
    }
}