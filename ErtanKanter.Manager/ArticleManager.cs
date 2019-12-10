using Ertan.Kanter.Repository;
using ErtanKanter.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErtanKanter.Manager
{
    public class ArticleManager : IDataRepository<Article>
    {
        readonly ArticleContext _ArticleContext;

        public ArticleManager(ArticleContext context)
        {
            _ArticleContext = context;
        }

        public IEnumerable<Article> GetAll()
        {
            return _ArticleContext.Articles.ToList();
        }

        public Article Get(long id)
        {
            return _ArticleContext.Articles.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Article entity)
        {
            _ArticleContext.Articles.Add(entity);
            _ArticleContext.SaveChanges();
        }

        public void Update(Article employee, Article entity)
        {
            employee.ImagePath = entity.ImagePath;
            employee.Subject = entity.Subject;
            employee.Content = entity.Content;
            employee.Date = entity.Date;
            employee.Author = entity.Author;
            employee.IsActive = entity.IsActive;

            _ArticleContext.SaveChanges();
        }

        public void Delete(Article employee)
        {
            _ArticleContext.Articles.Remove(employee);
            _ArticleContext.SaveChanges();
        }
    }
}
