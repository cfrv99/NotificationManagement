using MediatR.NotificationHandler.EventHandlers;
using MediatR.NotificationHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.NotificationHandler.Handlers.Commands.Products
{
    public class AddProductCommand : IRequest<Guid>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        public AddProductCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }
        private List<Product> _products = new List<Product>();
        private readonly IMediator mediator;

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            string message = string.Empty;
            try
            {
                Product p = new Product
                {
                    Id = request.Id,
                    Name = request.Name
                };
                _products.Add(p);
                message = "Product Added";
                
            }
            catch (Exception e)
            {
                message = "Error occured";
            }
            await mediator.Publish(new ProductNotification()
            {
                Message = message
            });
            return Guid.NewGuid();
        }
    }
}
