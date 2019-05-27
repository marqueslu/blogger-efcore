using blogger.api.Models;
using blogger.api.Repositories.Interfaces;
using blogger.api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

public class ArticlesController : Controller
{
    private readonly IArticlerepository _articleRepository;
    public ArticlesController(IArticlerepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    [Route("v1/articles")]
    [HttpGet]
    public IEnumerable<ListArticleViewModel> Get()
    {
        return _articleRepository.Get();
    }

    [Route("v1/articles/{id}")]
    [HttpGet]
    public Article GetById(int id)
    {
        return _articleRepository.GetById(id);
    }

    [Route("v1/articles")]
    [HttpPost]
    public ResultViewModel Post([FromBody]EditorArticleViewModel model)
    {

        if (string.IsNullOrEmpty(model.Title) || string.IsNullOrEmpty(model.Content))
        {
            return new ResultViewModel
            {
                Success = false,
                Message = "It was not possible to create an article."
            };
        }

        var article = new Article(model.Title, model.Content, DateTime.Now, DateTime.Now);
        _articleRepository.save(article);

        return new ResultViewModel
        {
            Success = true,
            Message = "Article create with success.",
            Data = article
        };
    }

    [Route("v1/articles")]
    [HttpPut]
    public ResultViewModel Put([FromBody]EditorArticleViewModel model)
    {
        if (string.IsNullOrEmpty(model.Title) || string.IsNullOrEmpty(model.Content))
        {
            return new ResultViewModel
            {
                Success = false,
                Message = "It was not possible to update an article.",
                Data = model
            };
        }

        var article = _articleRepository.GetById(model.Id);
        article.Title = model.Title;
        article.Content = model.Content;
        article.UpdatedAt = DateTime.Now;

        _articleRepository.update(article);

        return new ResultViewModel
        {
            Success = true,
            Message = "Article updated with success.",
            Data = article
        };
    }

    [Route("v1/articles/{id}")]
    [HttpDelete]
    public ResultViewModel Delete(int id)
    {
        var article = _articleRepository.GetById(id);
        if (article == null)
        {
            return new ResultViewModel
            {
                Success = false,
                Message = "Article not found."
            };
        }
        _articleRepository.Delete(article);
        return new ResultViewModel
        {
            Success = true,
            Message = "Article deleted with success.",
            Data = article
        };
    }
}