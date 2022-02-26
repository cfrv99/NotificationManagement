using MediatR.NotificationHandler.Handlers.Commands.Products;
using MediatR.NotificationHandler.Handlers.Queries.Products;
using MediatR.NotificationHandler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MediatR.NotificationHandler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator mediator;

        public HomeController(ILogger<HomeController> logger,IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            mediator.Send(new GetAllProductsQuery());
            return View();
        }

        public IActionResult Privacy()
        {
            mediator.Send(new AddProductCommand
            {
                Id = 2,
                Name = "Ali"
            });
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
