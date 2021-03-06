using System;
using Xunit;
using Xunit.Abstractions;
using blogger.api.Models;
using ExpectedObjects;
using UnitTests._utils;
using UnitTests.Builders;
using Bogus;

namespace UnitTests
{
    public class ArticleTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly int _id;
        private readonly string _title;
        private readonly string _content;
        private readonly DateTime _createdAt;
        private readonly DateTime _updatedAt;

        public ArticleTest(ITestOutputHelper output)
        {
            _output = output;
            var fake = new Faker();
            _id = fake.Random.Number();
            _title = fake.Lorem.Sentence();
            _content = fake.Lorem.Paragraph();
            _output.WriteLine(_content);
        }

        public void Dispose()
        {

        }

        [Fact]
        public void MustCreateArticle()
        {
            var expectedArticle = new
            {                
                Title = "Game of Thrones",
                Content = "This TV serie is awesome.",
                CreatedAt = new DateTime(),
                UpdatedAt = new DateTime()
            };

            var article = new Article(expectedArticle.Title, expectedArticle.Content, expectedArticle.CreatedAt, expectedArticle.UpdatedAt);
            expectedArticle.ToExpectedObject().ShouldMatch(article);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TheArticleMustNotHaveAInvalidTitle(string invalidTitle)
        {
            Assert.Throws<ArgumentException>(() =>
            ArticleBuilder.New().WithTitle(invalidTitle).Build())
                .WithMessage("Invalid title");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TheArticleMustNotHaveAInvalidContent(string invalidContent)
        {
            Assert.Throws<ArgumentException>(() =>
                ArticleBuilder.New().WithContent(invalidContent).Build())
                .WithMessage("Invalid Content");
        }
    }
}
