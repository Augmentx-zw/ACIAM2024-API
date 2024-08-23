using Ark.Gateway.API.BE.Dto;
using Ark.Gateway.Domain.Models;
using Ark.Gateway.Domain.QueryHandlers.PaymentDetails;
using Ark.Gateway.Domain.QueryHandlers.RegistrationDetails;
using Newtonsoft.Json;

namespace Ark.Gateway.API.BE.Services
{
    public class Messaging : IMessaging
    {
        private readonly string urlEndpoint = "https://2waychat.com";
        private readonly string apiEndpoint = "/2wc/single-sms/v1/api";
        private readonly string apiToken = "wVbrXVoss1Y4DvxbrpglmVbkAzeYshkgN2OyhB8MQ6SBshi5eQ";
        private readonly MessageRepository messageRepository = new();
        private readonly Mediator _mediator;

        public Messaging(Mediator mediator)
        {
            _mediator = mediator;
        }
        public bool Notify(Guid payment, string messageTemplate)
        {
            Payment paymentResult = _mediator.Dispatch(new GetPaymentByPaymentIdQuery { PaymentId = payment });
            var user = paymentResult.RegistrationId;
            var userDetail = _mediator.Dispatch(new GetRegistrationByRegistrationIdQuery { RegistrationId = user });
            var phone = userDetail.PhoneNumber;
            if (!phone.StartsWith("263"))
            {
                phone = phone.TrimStart('0');
                phone = "263" + phone;
            }

            if (phone.StartsWith("+263"))
            {
                phone = phone.Substring(1);
            }
            phone = phone.Replace(" ", "");

            string? name = userDetail.FirstName;

            MessageDto command = new()
            {
                Destination = phone,
                MessgeTemplate = messageTemplate,
                DestinationName = name
            };

            try
            {
                var res = SendMessage(command);
                return res;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public bool NotifyAdmin(Guid payment, string messageTemplate)
        {
            Payment paymentResult = _mediator.Dispatch(new GetPaymentByPaymentIdQuery { PaymentId = payment });
            var user = paymentResult.RegistrationId;
            var userDetail = _mediator.Dispatch(new GetRegistrationByRegistrationIdQuery { RegistrationId = user });
            string? name = userDetail.FirstName;

            MessageDto command = new()
            {
                Destination = "263712961142",
                MessgeTemplate = messageTemplate,
                DestinationName = "Evonam Admin",
                RefrenceName = name
            };
            try
            {
                var res = SendMessage(command);
                return res;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public bool SendMessage(MessageDto command)
        {
            var currentMessage = string.IsNullOrEmpty(command.MessgeTemplate) ? command.MessageText : GetMessage(command.MessgeTemplate);
            if (string.IsNullOrEmpty(command.RefrenceName))
                currentMessage = $"Hello {command.DestinationName}, {currentMessage}";
            else
                currentMessage = $"Hello {command.DestinationName},  {command.RefrenceName}, {currentMessage}";

            string jsonPayload = JsonConvert.SerializeObject(new
            {
                token = apiToken,
                destination = command.Destination,
                messageText = currentMessage,
                messageReference = Guid.NewGuid(),
                messageDate = DateTime.UtcNow.ToString("yyyyMMddHHmmss"),
                messageValidity = DateTime.UtcNow.ToString("HH:mm"),
                sendDateTime = DateTime.UtcNow.ToString("HH:mm")
            });

            //var client = new RestClient(urlEndpoint);
            //var request = new RestRequest(apiEndpoint, Method.Post);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", jsonPayload, ParameterType.RequestBody);
            //var res = client.Execute(request);
            //return res.IsSuccessful;

            return true;
        }

        private string GetMessage(string messageKey)
        {
            return messageRepository.GetMessage(messageKey);
        }
    }
}
