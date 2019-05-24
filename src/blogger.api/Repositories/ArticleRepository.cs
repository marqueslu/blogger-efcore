using System.Collections.Generic;
using System.Linq;
using blogger.api.Data;
using blogger.api.Models;
using blogger.api.Repositories.Interfaces;
using blogger.api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace blogger.api.Repositories
{
    public class ArticleRepository : IArticlerepository
    {
        private readonly BloggerDataContext _context;

        public ArticleRepository(BloggerDataContext context)
        {
            _context = context;
        }

        public IEnumerable<ListArticleViewModel> Get()
        {
            return _context.Articles.Select(x => new ListArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content
            }).AsNoTracking().ToList();
        }

        public Article GetById(int id)
        {
            return _context.Articles.Find(id);
        }

        public void save(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public void update(Article article)
        {
            _context.Entry<Article>(article).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Article article)
        {
            _context.Articles.Remove(article);
            _context.SaveChanges();
        }
    }
}