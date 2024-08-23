using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.QueryHandlers.ArticleDetails
{
    public class GetArticleByArticleIdQuery : IQuery<Article>
    {
        public Guid ArticleId { get; set; }
    }

    public class GetArticleByArticleIdQueryHandler : IQueryHandler<GetArticleByArticleIdQuery, Article>
    {
        private readonly IRepository<Article> _repo;

        public GetArticleByArticleIdQueryHandler(IRepository<Article> repo)
        {
            _repo = repo;
        }

        public Article Handle(GetArticleByArticleIdQuery query)
        {
            return _repo.GetByID(query.ArticleId);
        }
    }
}
