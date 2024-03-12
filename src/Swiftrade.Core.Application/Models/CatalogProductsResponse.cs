using Microsoft.AspNetCore.Mvc;
using Swiftrade.Core.Application.Dtos;
using Swiftrade.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Swiftrade.Core.Application.Models
{
    public partial record CatalogProductsResponse /*: BasePageableModel*/
    {
        public IReadOnlyList<ProductDetailsDto> products { get; set; }

        public CatalogProductsFilterResponse filter { get; set; }
    }
}
