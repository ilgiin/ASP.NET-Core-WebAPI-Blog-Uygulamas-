using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        static private readonly List<Article> _articles = new();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Article> GetList()
        {
            return _articles;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Article? GetArticle(int id)
        {
            return _articles.Find(x => x.Id == id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        public void AddArticle(string Title, string Content)
        {
            var item = new Article
            {
                Id = _articles.Count + 1,
                Title = Title,
                Content = Content
            };

            _articles.Add(item);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        public void UpdateArticle(int id, string Title, string Content)
        {
            var index = _articles.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return;
            }
            _articles[index].Title = Title;
            _articles[index].Content = Content;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public void DeleteArticle(int id)
        {
            var index = _articles.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return;
            }
            _articles.RemoveAt(index);

















































        }
    }
}
