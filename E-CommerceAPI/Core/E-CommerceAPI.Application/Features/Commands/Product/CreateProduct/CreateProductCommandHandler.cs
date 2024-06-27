﻿
using E_CommerceAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequset, CreateProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;

       

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
          
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequset request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.AddAsync(new()
            {

                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            });

            await _productWriteRepository.SaveAsync();
          

            return new();
        }
    }
}
