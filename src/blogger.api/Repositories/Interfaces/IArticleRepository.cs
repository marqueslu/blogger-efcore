using System.Collections.Generic;
using blogger.api.Models;
using blogger.api.ViewModels;

namespace blogger.api.Repositories.Interfaces
{
    public interface IArticlerepository
    {
        IEnumerable<ListArticleViewModel> Get();
        Article GetById(int id);
        void save(Article article);
        void update(Article article);
        void Delete(Article article);
    }
}
