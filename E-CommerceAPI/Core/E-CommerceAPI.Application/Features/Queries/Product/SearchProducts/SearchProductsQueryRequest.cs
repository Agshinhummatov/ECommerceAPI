using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Application.Features.Queries.Product.SearchProducts
{
    public class SearchProductsQueryRequest : IRequest<SearchProductsQueryResponse>
    {
        public string SearchTerm { get; set; }
    }
}
