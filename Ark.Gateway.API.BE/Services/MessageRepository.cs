namespace Ark.Gateway.API.BE.Services
{
    public class MessageRepository
    {
        private static readonly Dictionary<string, string> Messages = new()
        {
            { "OrderPlaced", "Your order has been placed" },
            { "OrderDispatched", "Your order has been dispatched" },
            { "OrderDelivered", "Your order has been delivered" },
            { "OrderCancelled", "Your order has been cancelled" },
            { "OrderCompleted", "Your order has been completed" },
            { "OrderReceived", "Your order has been received" },
            { "NewOrderPlaced", "Has placed a new order" },
            { "OrderDispatchedNotification", "Order has been dispatched" },
            { "OrderReceivedNotification", "Order has been received" },
            { "OrderCompletedNotification", "Order has been completed" }
        };

        public string GetMessage(string key)
        {
            if (Messages.TryGetValue(key, out var message))
            {
                return message;
            }
            else
            {
                return "Unknown message key";
            }
        }
    }
}
