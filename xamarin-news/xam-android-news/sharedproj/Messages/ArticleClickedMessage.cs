namespace xam_android_news.Messages
{
    /// <summary>
    /// Event indicvating an article has been clicked
    /// </summary>
    public class ArticleClickedMessage
    {
        public string Id;

        public ArticleClickedMessage(string id)
        {
            this.Id = id;
        }
    }
}