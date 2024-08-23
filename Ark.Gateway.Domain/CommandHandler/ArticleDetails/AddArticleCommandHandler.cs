using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.CommandHandler.ArticleDetails
{
    public class AddArticleCommand : ICommand
    {
        public Guid ArticleId { get; set; }
        public string? Title { get; set; }
        public string? YoutubeId { get; set; }
        public string? Image { get; set; }
        public string? Story { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpDatedOn { get; set; }
    }

    public class AddArticleCommandHandler : ICommandHandler<AddArticleCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Article> _repo;

        public AddArticleCommandHandler(IUnitOfWork uow, IRepository<Article> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(AddArticleCommand command)
        {
            var Init = new Article
            {
                ArticleId = Guid.NewGuid(),
                Image = command.Image,
                Story = command.Story,
                Title = command.Title,
                YoutubeId = command.YoutubeId,
                CreatedOn = DateTime.Now,
                UpDatedOn = DateTime.Now
            };
            _repo.Insert(Init);
            _uow.Save();
        }
    }
}
