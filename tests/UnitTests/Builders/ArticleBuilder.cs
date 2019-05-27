using System;
using blogger.api.Models;
namespace UnitTests.Builders
{
    public class ArticleBuilder
    {        
        private string _title = "Game of Thrones";
        private string _content = "This TV serie is awesome.";
        private DateTime _createdAt = new DateTime();
        private DateTime _updatedAt = new DateTime();

        public static ArticleBuilder New()
        {
            return new ArticleBuilder();
        }

        public ArticleBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public ArticleBuilder WithContent(string content)
        {
            _content = content;
            return this;
        }

        public Article Build()
        {
            return new Article(_title, _content, _createdAt, _updatedAt);
        }

    }
}
