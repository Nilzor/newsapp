using System;
using System.Net.Http;
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