﻿using FjRuiYiPack.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FjRuiYiPack.Web.Services
{
    public interface IArticleService
    {
        Task<Article> GetArticle(int id, string ip, string browser, string device, string os);

        Task<IEnumerable<Article>> GetArticles();

        Task<IEnumerable<Category>> GetCategoriesAsync();


        Task<IEnumerable<Carousel>> GetCarousels();
    }
}
