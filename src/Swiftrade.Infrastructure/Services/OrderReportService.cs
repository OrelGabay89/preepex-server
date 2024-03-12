using Microsoft.EntityFrameworkCore;
using Swiftrade.Common.Paging;
using Swiftrade.Core.Application.Dtos;
using Swiftrade.Core.Application.Interfaces;
using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Application.Interfaces.Shared;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Core.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swiftrade.Infrastructure.Services
{
    public class OrderReportService : IOrderReportService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductManufacturerRepository _productManufacturerRepository;

        private readonly IGenericRepository<Product> _productRepository;

        public OrderReportService(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, IGenericRepository<Product> productRepository,
            IAddressRepository addressRepository, IProductCategoryRepository productCategoryRepository, IProductManufacturerRepository productManufacturerRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _addressRepository = addressRepository;
            _productCategoryRepository = productCategoryRepository;
            _productManufacturerRepository = productManufacturerRepository;
        }
        public async Task<PagedResult<BestsellersReportLineDto>> BestSellersReportAsync(
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
            bool showHidden = false)
        {

            var bestSellers = SearchOrderItems(categoryId, manufacturerId, storeId, vendorId, createdFromUtc, createdToUtc, os, ps, ss, billingCountryId, showHidden);

            var bsReport =
                //group by products
                from orderItem in bestSellers
                group orderItem by orderItem.ProductId into g
                select new BestsellersReportLineDto
                {
                    ProductId = g.Key,
                    TotalAmount = g.Sum(x => x.PriceExclTax),
                    TotalQuantity = g.Sum(x => x.Quantity)
                };

            bsReport = orderBy switch
            {
                OrderByEnum.OrderByQuantity => bsReport.OrderByDescending(x => x.TotalQuantity),
                OrderByEnum.OrderByTotalAmount => bsReport.OrderByDescending(x => x.TotalAmount),
                _ => throw new ArgumentException("Wrong orderBy parameter", nameof(orderBy)),
            };

            var result = new PagedResult<BestsellersReportLineDto>();
            result.CurrentPage = pageIndex;
            result.PageSize = pageSize;
            result.Results = await bsReport.ToListAsync();

            
            return result;
        }
        private IQueryable<Orderitem> SearchOrderItems(
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
            bool showHidden = false)
        {
            int? orderStatusId = null;
            if (os.HasValue)
                orderStatusId = (int)os.Value;

            int? paymentStatusId = null;
            if (ps.HasValue)
                paymentStatusId = (int)ps.Value;

            int? shippingStatusId = null;
            if (ss.HasValue)
                shippingStatusId = (int)ss.Value;

            var orderItems = from orderItem in _orderItemRepository.GetOrderItems()
                             join o in _orderRepository.GetOrders() on orderItem.OrderId equals o.Id
                             join p in _productRepository.Table on orderItem.ProductId equals p.Id
                             join oba in _addressRepository.GetAddresses() on o.BillingAddressId equals oba.Id
                             where (storeId == 0 || storeId == o.StoreId) &&
                                 (!createdFromUtc.HasValue || createdFromUtc.Value <= o.CreatedOnUtc) &&
                                 (!createdToUtc.HasValue || createdToUtc.Value >= o.CreatedOnUtc) &&
                                 (!orderStatusId.HasValue || orderStatusId == o.OrderStatusId) &&
                                 (!paymentStatusId.HasValue || paymentStatusId == o.PaymentStatusId) &&
                                 (!shippingStatusId.HasValue || shippingStatusId == o.ShippingStatusId) &&
                                 !o.Deleted && !p.Deleted &&
                                 (vendorId == 0 || p.VendorId == vendorId) &&
                                 (billingCountryId == 0 || oba.CountryId == billingCountryId) &&
                                 (showHidden || p.Published)
                             select orderItem;

            if (categoryId > 0)
            {
                orderItems = from orderItem in orderItems
                             join p in _productRepository.Table on orderItem.ProductId equals p.Id
                             join pc in _productCategoryRepository.GetProductCategories() on p.Id equals pc.ProductId
                             into p_pc
                             from pc in p_pc.DefaultIfEmpty()
                             where pc.CategoryId == categoryId
                             select orderItem;
            }

            if (manufacturerId > 0)
            {
                orderItems = from orderItem in orderItems
                             join p in _productRepository.Table on orderItem.ProductId equals p.Id
                             join pm in _productManufacturerRepository.GetProductManufactureres() on p.Id equals pm.ProductId
                             into p_pm
                             from pm in p_pm.DefaultIfEmpty()
                             where pm.ManufacturerId == manufacturerId
                             select orderItem;
            }

            return orderItems;
        }
    }
}
