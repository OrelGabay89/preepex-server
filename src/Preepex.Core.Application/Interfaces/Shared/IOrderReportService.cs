﻿using Preepex.Common.Paging;
using Preepex.Core.Application.Dtos;
using Preepex.Core.Domain.Enumerations;
using System;
using System.Threading.Tasks;

namespace Preepex.Core.Application.Interfaces.Shared
{
    public interface IOrderReportService
    {
        Task<PagedResult<BestsellersReportLineDto>> BestSellersReportAsync(
            int categoryId = 0,
            int manufacturerId = 0,
            int storeId = 0,
            int vendorId = 0,
            DateTime? createdFromUtc = null,
            DateTime? createdToUtc = null,
            OrderStatusEnum? os = null,
            PaymentStatusEnum? ps = null,
            ShippingStatusEnum? ss = null,
            int billingCountryId = 0,
            OrderByEnum orderBy = OrderByEnum.OrderByQuantity,
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            bool showHidden = false);
    }
}
