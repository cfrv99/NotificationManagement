using MediatR.NotificationHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.NotificationHandler.Handlers.Queries.Products
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {

    }

    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        public GetAllProductsHandler()
        {

        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var list = new List<Product>
            {
                new Product{Id=1, Name="Senan"}
            };
            return list;
        }
    }
}
