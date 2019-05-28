using System;
using blogger.api.Models;
using blogger.api.ViewModels;
using blogger.api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

using Moq;
using Xunit;
using Bogus;
using UnitTests.Builders;
using UnitTests._utils;

namespace UnitTests
{
    public class ArticlesControllerTest
    {
        private readonly EditorArticleViewModel _articleModel;
        private readonly ArticlesController _articlesController;
        private readonly Mock<IArticleRepository> _articleRepositoryMock;
        public ArticlesControllerTest()
        {
            var fake = new Faker();
            _articleModel = new EditorArticleViewModel
            {
                Id = fake.Random.Number(1, 1000),
                Title = fake.Lorem.Sentence(),
                Content = fake.Lorem.Paragraph()
            };

            _articleRepositoryMock = new Mock<IArticleRepository>();
            _articlesController = new ArticlesController(_articleRepositoryMock.Object);
        }

        [Fact]
        public void MustAddArticle()
        {
            _articlesController.Post(_articleModel);
            _articleRepositoryMock.Verify(r => r.save(It.IsAny<Article>()));
        }

        public void MustNotAddAnArticleWithDuplicatedTitle()
        {
            var articleAlreadySaved = ArticleBuilder.New().WithTitle(_articleModel.Title).Build();
            _articleRepositoryMock.Setup(r => r.GetByTitle(_articleModel.Title)).Returns(articleAlreadySaved);

            Assert.Throws<ArgumentException>(() => _articlesController.Post(_articleModel)).WithMessage("This title is already taken");
        }
    }
}