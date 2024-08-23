using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.CommandHandler.ArticleDetails
{
    public class DeleteArticleCommand : ICommand
    {
        public Guid ArticleId { get; set; }
    }
    public class DeleteArticleCommandHandler : ICommandHandler<DeleteArticleCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Article> _repo;

        public DeleteArticleCommandHandler(IUnitOfWork uow, IRepository<Article> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(DeleteArticleCommand command)
        {
            var Article = _repo.GetByID(command.ArticleId);
            _repo.Delete(Article);
            _uow.Save();
        }
    }
}
