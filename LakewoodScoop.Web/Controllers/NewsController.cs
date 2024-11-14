using LakewoodScoop.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace LakewoodScoop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        [HttpGet]
        [Route("scrape")]
        public List<NewsItem> Scrape()
        {
            return LakewoodScoop.Data.NewsClass.Scrape();
        }
    }
}
