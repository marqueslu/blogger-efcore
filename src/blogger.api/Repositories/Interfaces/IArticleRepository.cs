using System.Collections.Generic;
using blogger.api.Models;
using blogger.api.ViewModels;

namespace blogger.api.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        IEnumerable<ListArticleViewModel> Get();
        Article GetById(int id);
        Article GetByTitle(string title);
        void save(Article article);
        void update(Article article);
        void Delete(Article article);
    }
}
