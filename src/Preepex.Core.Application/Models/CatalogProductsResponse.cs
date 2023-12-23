using Microsoft.AspNetCore.Mvc;
using Preepex.Core.Application.Dtos;
using Preepex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Preepex.Core.Application.Models
{
    public partial record CatalogProductsResponse /*: BasePageableModel*/
    {
        public IReadOnlyList<ProductDetailsDto> products { get; set; }

        public CatalogProductsFilterResponse filter { get; set; }
    }
}
