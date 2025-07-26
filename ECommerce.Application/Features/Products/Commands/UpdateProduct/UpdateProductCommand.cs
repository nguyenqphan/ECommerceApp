using ECommerce.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public UpdateProductDto UpdateProductDto { get; set; }
        public UpdateProductCommand(UpdateProductDto updateProductDto)
        {
            UpdateProductDto = updateProductDto;
        }
    }
}
