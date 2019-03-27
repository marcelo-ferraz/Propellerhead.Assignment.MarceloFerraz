using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PassOn;
using Propellerhead.Assignment.MarceloFerraz.Core.Search;
using Propellerhead.Assignment.MarceloFerraz.Web.Areas.Search.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Propellerhead.Assignment.MarceloFerraz.Web.Areas.Search.Controllers
{
    [Route("api/search")]
    public class SearchController : Controller
    {
        private readonly ISearchRepository searchRepository;
        private readonly IMemoryCache memoryCache;

        public SearchController(
            IMemoryCache memoryCache,
            ISearchRepository searchRepository)
        {
            this.searchRepository = searchRepository;
            this.memoryCache = memoryCache;
        }

        // GET: api/search
        [HttpGet]
        public IList<CustomerSearchModel> Get(string term)
        {
            return Get(
                () => Search(term), term);
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public CustomerSearchModel Get(int id)
        {
            return Get(
                () => searchRepository.Get(id).To<CustomerSearchModel>(), id.ToString());
        }

        protected IList<CustomerSearchModel> Search(string term)
        {
            return searchRepository
                .Search(term)
                .Select(item => item.To<CustomerSearchModel>())
                .ToList();
        }

        protected T Get<T>(Func<T> getter, string key)
        {
            if (string.IsNullOrEmpty(key)) { return default(T); }

            var found =
                memoryCache.TryGetValue<T>(key, out T result);

            if (!found) { result = getter(); }

            return result;
        }
    }
}
