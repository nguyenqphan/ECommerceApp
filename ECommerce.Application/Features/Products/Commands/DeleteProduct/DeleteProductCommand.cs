﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }
        public DeleteProductCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}
