﻿using Csp.Web.Extensions;
using Microsoft.Extensions.Options;
using FjRuiYiPack.Web.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FjRuiYiPack.Web.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IOptions<AppSettings> _settings;

        private readonly HttpClient _httpClient;

        private readonly string _remoteServiceBaseUrl;

        public ArticleService(IOptions<AppSettings> settings, HttpClient httpClient)
        {
            _settings = settings;
            _httpClient = httpClient;
            //_logger = logger;

            _remoteServiceBaseUrl = $"{_settings.Value.OcelotUrl}/blog/api/v1";
        }

        public async Task<Article> GetArticle(int id, string ip, string browser, string device, string os)
        {
            var browse = new BrowseHistory(id,ip,browser,os,device);

            string uri = API.Article.GetArticle(_remoteServiceBaseUrl);

            var forumContent = new StringContent(browse.ToJson(), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, forumContent);

            return await response.GetResult<Article>();
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            string uri = API.Article.GetArticles(_remoteServiceBaseUrl);

            var responseString = await _httpClient.GetStringAsync(uri);

            return responseString.FromJson<IEnumerable<Article>>();
        }

        public async Task<IEnumerable<Carousel>> GetCarousels()
        {
            string uri = API.Article.GetCarousels($"{_settings.Value.OcelotUrl}/ws/api/v1");

            var responseString = await _httpClient.GetStringAsync(uri);

            return responseString.FromJson<IEnumerable<Carousel>>();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            string uri = API.Article.GetCategories(_remoteServiceBaseUrl);

            var responseString = await _httpClient.GetStringAsync(uri);

            return responseString.FromJson<IEnumerable<Category>>();
        }
    }
}
