using E_CommerceAPI.Application.Abstractions.Services;
using E_CommerceAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Application.Features.Commands.Product.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
    {
        private readonly IProductService _productService;

        public RemoveProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _productService.RemoveProductAsync(request.Id);
                return new RemoveProductCommandResponse();
            }
            catch (ArgumentException ex)
            {
                throw new Exception("Invalid product ID", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while removing the product", ex);
            }
        }




    }
}
