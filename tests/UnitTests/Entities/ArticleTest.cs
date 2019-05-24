using System;
using Xunit;
using Xunit.Abstractions;
using blogger.api.Models;
using ExpectedObjects;
using UnitTests._utils;
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
        }

        public void Dispose()
        {

        }

        [Fact]
        public void MustCreateArticle()
        {
            var expectedArticle = new
            {
                Id = 1,
                Title = "Game of Thrones",
                Content = "This TV serie is awesome.",
                CreatedAt = new DateTime(),
                UpdatedAt = new DateTime()
            };

            var article = new Article(expectedArticle.Id, expectedArticle.Title, expectedArticle.Content, expectedArticle.CreatedAt, expectedArticle.UpdatedAt);
            expectedArticle.ToExpectedObject().ShouldMatch(article);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TheArticleMustNotHaveAInvalidTitle(string invalidTitle)
        {
            var expectedArticle = new
            {
                Id = 1,
                Title = "Game of Thrones",
                Content = "This TV serie is awesome.",
                CreatedAt = new DateTime(),
                UpdatedAt = new DateTime()
            };

            Assert.Throws<ArgumentException>(() =>
                new Article(expectedArticle.Id, invalidTitle, expectedArticle.Content, expectedArticle.CreatedAt, expectedArticle.UpdatedAt))
                .WithMessage("Invalid title");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TheArticleMustNotHaveAInvalidContent(string invalidContent){
            var expectedArticle = new
            {
                Id = 1,
                Title = "Game of Thrones",
                Content = "This TV serie is awesome.",
                CreatedAt = new DateTime(),
                UpdatedAt = new DateTime()
            };

            Assert.Throws<ArgumentException>(() =>
                new Article(expectedArticle.Id, expectedArticle.Title, invalidContent, expectedArticle.CreatedAt, expectedArticle.UpdatedAt))
                .WithMessage("Invalid Content");
        }
    }
}