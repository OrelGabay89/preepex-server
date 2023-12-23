using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Preepex.Core.Application.Models
{
    public partial record CatalogProductsFilterResponse
    {
        #region Properties
        public decimal minPrice { get; set; }
        public decimal maxPrice { get; set; }
        #endregion
    }
}
