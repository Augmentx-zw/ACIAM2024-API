using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.QueryHandlers.ArticleDetails
{
    public class GetArticlesQuery : IQuery<IEnumerable<Article>>
    {

    }
    public class GetArticlesQueryHandler : IQueryHandler<GetArticlesQuery, IEnumerable<Article>>
    {
        private readonly IRepository<Article> _repo;
        public GetArticlesQueryHandler(IRepository<Article> repo)
        {
            _repo = repo;
        }
        public IEnumerable<Article> Handle(GetArticlesQuery query)
        {
            return _repo.Get();
        }
    }
}
