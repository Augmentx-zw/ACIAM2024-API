using Ark.Gateway.Domain.CommandHandler.PaymentDetails;
using Ark.Gateway.Domain.Models;
using Ark.Gateway.Domain.QueryHandlers.PaymentDetails;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml;

namespace Ark.Gateway.API.BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly string? _serviceType;
        private readonly Mediator _mediator;
        private readonly string? _companyToken;

        public PaymentController(IConfiguration configuration, Mediator mediator)
        {
            _mediator = mediator;

            _serviceType = configuration["serviceType"];
            _companyToken = configuration["companyToken"];
        }

        [HttpPost("InitiatePayment")]
        public async Task<IActionResult> Initiate([FromBody] AddPaymentCommand command)
        {
            command.PaymentId = Guid.NewGuid();
            string? payment = "USD";
            var url = command.ReturnURL + command.PaymentId;
            command.CurrencyCode = payment;
            try
            {
                var amount = (int)command.Amount;
                var desc = command.ReasonForPayment;
                string? refrence = await InitTransaction(_companyToken, desc, amount, _serviceType, url);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(refrence);

                string? result = xmlDoc.SelectSingleNode("//Result")?.InnerText;
                string? resultExplanation = xmlDoc.SelectSingleNode("//ResultExplanation")?.InnerText;
                string? transToken = xmlDoc.SelectSingleNode("//TransToken")?.InnerText;
                string? transRef = xmlDoc.SelectSingleNode("//TransRef")?.InnerText;



                command.Token = Guid.Parse(transToken?.ToString());

                command.ReferenceNumber = transRef;
                _mediator.Dispatch(command);
                return Ok(transToken);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("CheckPayment")]
        public async Task<IActionResult> Check(Guid payment)
        {
            Payment result = _mediator.Dispatch(new GetPaymentByPaymentIdQuery { PaymentId = payment });

            var companyToken = _companyToken;

            var transToken = result.Token.ToString();

            string status = await CheckStatusAsync(companyToken, transToken);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(status);

            string? resultExplanation = xmlDoc.SelectSingleNode("//ResultExplanation").InnerText;

            if (resultExplanation == "Transaction Paid")
            {
                resultExplanation = "SUCCESS";
            }

            var updatecommand = new UpDatePaymentCommand
            {
                PaymentId = payment,
                Status = resultExplanation,
                UpdatedOn = DateTime.Now
            };

            Update(updatecommand);

            return Ok(payment);
        }

        [HttpGet("GetPayment")]
        public IActionResult Get(Guid payment)
        {
            Payment result = _mediator.Dispatch(new GetPaymentByPaymentIdQuery { PaymentId = payment });
            return Ok(result);
        }

        [HttpGet("GetPayments")]
        public IActionResult Getuserall(Guid user)
        {
            var result = _mediator.Dispatch(new GetPaymentByRegistrationDetailIdQuery { RegistrationId = user });
            return Ok(result);
        }

        [HttpGet("GetAllPayments")]
        public IActionResult Getall()
        {
            var result = _mediator.Dispatch(new GetPaymentsQuery { });
            return Ok(result);
        }

        [HttpPost("UpdatePayment")]
        public IActionResult Update(UpDatePaymentCommand command)
        {
            try
            {
                _mediator.Dispatch(command);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return Ok(new { Error = true, ex.Message });
            }
        }



        private async Task<string> CheckStatusAsync(string companyToken, string transToken)
        {
            var endpoint = "https://secure.3gdirectpay.com/API/v6/";
            var xmlData = $"<?xml version=\"1.0\" encoding=\"utf-8\"?><API3G><CompanyToken>{companyToken}</CompanyToken><Request>verifyToken</Request><TransactionToken>{transToken}</TransactionToken></API3G>";

            var httpClient = new HttpClient();
            var stringContent = new StringContent(xmlData, Encoding.UTF8, "application/xml");
            var response = await httpClient.PostAsync(endpoint, stringContent);
            string xmlString = await response.Content.ReadAsStringAsync();

            return xmlString;
        }

        private async Task<string> InitTransaction(string? companyToken, string? desc, int amount, string? serviceType, string? returnURL)
        {
            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("yyyy/MM/dd");
            string url = returnURL.ToString();
            var endpoint = "https://secure.3gdirectpay.com/API/v6/";
            var xmlData = $"<?xml version=\"1.0\" encoding=\"utf-8\"?><API3G><CompanyToken>{companyToken}</CompanyToken><Request>createToken</Request><Transaction><PaymentAmount>{amount}</PaymentAmount><PaymentCurrency>USD</PaymentCurrency><CompanyRef>MHINT</CompanyRef><RedirectURL>{url}</RedirectURL><BackURL>{url}</BackURL><CompanyRefUnique>0</CompanyRefUnique><PTL>5</PTL></Transaction><Services><Service><ServiceType>{serviceType}</ServiceType><ServiceDescription>{desc}</ServiceDescription><ServiceDate>{formattedDate}</ServiceDate></Service></Services></API3G>";

            var httpClient = new HttpClient();
            var stringContent = new StringContent(xmlData, Encoding.UTF8, "application/xml");
            var response = await httpClient.PostAsync(endpoint, stringContent);
            string xmlString = await response.Content.ReadAsStringAsync();

            return xmlString;
        }


    }
}
