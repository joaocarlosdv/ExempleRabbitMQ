using ExempleRabbitMq_2.CrossCutting;
using ExempleRabbitMq_2.Models;
using ExempleRabbitMq_2.Services;
using ExempleRabbitMq_2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ExempleRabbitMq_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly PublishRMQ publishRMQ;
        private readonly ReceiverRMQ receiverRMQ;

        public HomeController(IPublishRMQ _publishRMQ, IReceiverRMQ _receiverRMQ)
        {
            publishRMQ = (PublishRMQ)_publishRMQ;
            receiverRMQ = (ReceiverRMQ)_receiverRMQ;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Publish")]
        public ActionResult Publish()
        {
            return Ok(publishRMQ.Publish(new ModelExemple { Id = Guid.NewGuid(), Cpf = Functions.RandomCpf(), Name = Functions.RandomNames() }));
        }

        [HttpGet("Receiver")]
        public ActionResult Receiver()
        {
            return Ok(receiverRMQ.Consumer());
        }
    }
}
