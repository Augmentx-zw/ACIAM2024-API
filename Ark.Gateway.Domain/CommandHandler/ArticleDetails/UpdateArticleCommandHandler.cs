using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.CommandHandler.ArticleDetails
{
    public class UpdateArticleCommand : ICommand
    {
        public Guid ArticleId { get; set; }
        public string? Title { get; set; }
        public string? YoutubeId { get; set; }
        public string? Story { get; set; }
        public DateTime UpDatedOn { get; set; }
    }
    public class UpdateArticleCommandHandler : ICommandHandler<UpdateArticleCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Article> _repo;

        public UpdateArticleCommandHandler(IUnitOfWork uow, IRepository<Article> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(UpdateArticleCommand command)
        {
            var update = _repo.GetByID(command.ArticleId);
            if (update == null)
            {
                throw new Exception($"Article with ID {command.ArticleId} not found.");
            }
            update.Title = command.Title;
            update.YoutubeId = command.YoutubeId;
            update.Story = command.Story;
            update.UpDatedOn = DateTime.Now;
            _uow.Save();
        }
    }
}
