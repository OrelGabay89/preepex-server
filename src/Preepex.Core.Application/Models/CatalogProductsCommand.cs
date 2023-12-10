using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Preepex.Core.Application.Models
{
    public partial record CatalogProductsFilter /*: BasePageableModel*/
    {
        #region Properties

        /// <summary>
        /// Gets or sets the price ('min-max' format)
        /// </summary>
        [FromQuery(Name = "price")]
        public string Price { get; set; }

        /// <summary>
        /// Gets or sets the specification attribute option ids
        /// </summary>
        [FromQuery(Name = "specs")]
        public List<int> SpecificationOptionIds { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer ids
        /// </summary>
        [FromQuery(Name = "ms")]
        public List<int> ManufacturerIds { get; set; }

        /// <summary>
        /// Gets or sets a order by
        /// </summary>
        [FromQuery(Name = "sort")]
        public string? OrderBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wether the order direction is ascending or descending, false is descending
        /// </summary>
        [FromQuery(Name = "asc")]
        public bool? OrderByAscending { get; set; }

        #endregion
    }
}
