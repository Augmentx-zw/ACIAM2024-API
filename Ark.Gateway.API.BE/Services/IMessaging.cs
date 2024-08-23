using Ark.Gateway.API.BE.Dto;

namespace Ark.Gateway.API.BE.Services
{

	public interface IMessaging
	{
		bool SendMessage(MessageDto command);
		bool Notify(Guid payment, string messageTemplate);
		bool NotifyAdmin(Guid payment, string messageTemplate);
    }
}
