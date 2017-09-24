using Android.Util;
using GalaSoft.MvvmLight;
using System;

namespace sharedproj.ViewModels
{
    /// <summary>
    /// View model for article activity
    /// </summary>
    public class ArticleViewModel : ViewModelBase
    {
        const string TAG = "AVM";
        // Set to null to hide error
        public string ErrorMessage { get; set; }
        public dynamic Article { get; set; }
        public bool IsProgressBarVisible { get; set; }
        public bool IsErrorMessageVisible { get { return ErrorMessage != null; } }

        private NewsService NewsService;

        public ArticleViewModel(NewsService newsService)
        {
            NewsService = newsService;
        }

        public async void LoadArticle(string articleId)
        {
            ResetState();

            if (string.IsNullOrEmpty(articleId)) throw new Exception("ArticleId not set in ArticleActivity.LoadActivity");
            Log.Info(TAG, "Loading article %s...", articleId); // Todo: Wrap the logger to make class platform agnostic
            try
            {
                IsProgressBarVisible = true;
                RaisePropertyChanged();
                Article = await NewsService.LoadArticle(articleId);
                Log.Info(TAG, "Presenting article %s...", articleId);
            }
            catch (HttpRequestError reqErr)
            {
                ErrorMessage = "Error loading article: " + reqErr.ErrorCode;
            }
            finally
            {
                IsProgressBarVisible = false;
                RaisePropertyChanged();
            }           
        }

        private void ResetState()
        {
            ErrorMessage = null;
            Article = null;
            IsProgressBarVisible = false;
            RaisePropertyChanged();
        }
    }
}
