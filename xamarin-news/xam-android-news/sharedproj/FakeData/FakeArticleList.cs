using sharedproj.Models;

namespace sharedproj.FakeData
{
    public class FakeArticleList : ArticleList
    {
        public FakeArticleList()
        {
            ArticleTeaser teaser1 = new ArticleTeaser();
            teaser1.id = "abc";
            teaser1.promotionContent = new PromotionContent();
            teaser1.promotionContent.title = new ValueString("Some news happened");
            teaser1.promotionContent.description = new ValueString("It was huge");
            Add(teaser1);
        }
    }
}
