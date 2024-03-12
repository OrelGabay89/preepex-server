using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swiftrade.Common.Paging;
using Swiftrade.Core.Application.Attributes;
using Swiftrade.Core.Application.Dtos;
using Swiftrade.Core.Application.Errors;
using Swiftrade.Core.Application.Interfaces;
using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Application.Interfaces.Shared;
using Swiftrade.Core.Application.Request;
using Swiftrade.Core.Application.Specifications;
using Swiftrade.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swiftrade.Core.Application.Interfaces.Shared.Catalog;
using Swiftrade.Core.Application.Interfaces.Factories;
using Swiftrade.Core.Domain.Entities.ApplicationEntities;

namespace Swiftrade.Web.Presentation.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/productsv1")]
    public class OldProductsControlle : BaseApiController
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;
        private readonly IProductService _productService;

        private readonly IGenericRepository<Core.Domain.Entities.Product> _productRepository;
        private readonly IPictureRepository _pictureRepository;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IProductModelFactory _productModelFactory;

        private readonly IStoreContext _storeContext;

        public OldProductsControlle(IMapper mapper, IUnitOfWork unitOfWork, IPhotoService photoService, IProductService productService,
            IGenericRepository<Core.Domain.Entities.Product> productRepository, IPictureRepository pictureRepository, IUrlRecordService urlRecordService,
            IProductModelFactory productModelFactory, IStoreContext storeContext)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _photoService = photoService;
            _productService = productService;
            _productRepository = productRepository;
            _pictureRepository = pictureRepository;
            _urlRecordService = urlRecordService;
            _productModelFactory = productModelFactory;

            _storeContext = storeContext;
        }



        [HttpGet("Search")]
        public async Task<ActionResult<Pagination<ProductSearchResponseDto>>> SearchProducts([FromQuery] ProductSearchRequest request)
        {
            //var result = await _productService.SearchProducts(request);
            //foreach (var item in result.Data)
            //{
            //    item.Images = await _pictureRepository.GetPicturesByProductIdAsync(item.Id);
            //}
            return Ok(null);
        }

        [HttpDelete("{id}/photo/{photoId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteProductPhoto(int id, int photoId)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _unitOfWork.Repository<Core.Domain.Entities.ApplicationEntities.Product>().GetEntityWithSpec(spec);

            var photo = product.Photos.SingleOrDefault(x => x.Id == photoId);

            if (photo != null)
            {
                if (photo.IsMain)
                    return BadRequest(new ApiResponse(400,
                        "You cannot delete the main photo"));

                _photoService.DeleteFromDisk(photo);
            }
            else
            {
                return BadRequest(new ApiResponse(400, "Photo does not exist"));
            }

            product.RemovePhoto(photoId);

            _unitOfWork.Repository<Core.Domain.Entities.ApplicationEntities.Product>().Update(product);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem adding photo product"));

            return Ok();
        }

        [HttpPost("{id}/photo/{photoId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ProductToReturnDto>> SetMainPhoto(int id, int photoId)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _unitOfWork.Repository<Core.Domain.Entities.ApplicationEntities.Product>().GetEntityWithSpec(spec);

            if (product.Photos.All(x => x.Id != photoId)) return NotFound();

            product.SetMainPhoto(photoId);

            _unitOfWork.Repository<Core.Domain.Entities.ApplicationEntities.Product>().Update(product);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem adding photo product"));

            return _mapper.Map<Core.Domain.Entities.ApplicationEntities.Product, ProductToReturnDto>(product);
        }



        [HttpPut("{id}/photo")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ProductToReturnDto>> AddProductPhoto(int id, [FromForm] ProductPhotoDto photoDto)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _unitOfWork.Repository<Core.Domain.Entities.ApplicationEntities.Product>().GetEntityWithSpec(spec);

            if (photoDto.Photo.Length > 0)
            {
                var photo = await _photoService.SaveToDiskAsync(photoDto.Photo);

                if (photo != null)
                {
                    product.AddPhoto(photo.PictureUrl, photo.FileName);

                    _unitOfWork.Repository<Core.Domain.Entities.ApplicationEntities.Product>().Update(product);

                    var result = await _unitOfWork.Complete();

                    if (result <= 0) return BadRequest(new ApiResponse(400, "Problem adding photo product"));
                }
                else
                {
                    return BadRequest(new ApiResponse(400, "problem saving photo to disk"));
                }
            }

            return _mapper.Map<Core.Domain.Entities.ApplicationEntities.Product, ProductToReturnDto>(product);
        }


        [RedisCached(600)]
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
               [FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);

            var countSpec = new ProductWithFiltersForCountSpecificication(productParams);

            var totalItems = await _unitOfWork.Repository<Core.Domain.Entities.ApplicationEntities.Product>().CountAsync(countSpec);

            var products = await _unitOfWork.Repository<Core.Domain.Entities.ApplicationEntities.Product>().ListAsync(spec);

            var data = _mapper
                .Map<IReadOnlyList<Core.Domain.Entities.ApplicationEntities.Product>, IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ProductToReturnDto>> UpdateProduct(int id, ProductCreateDto productToUpdate)
        {
            var product = await _unitOfWork.Repository<Core.Domain.Entities.ApplicationEntities.Product>().GetByIdAsync(id);

            _mapper.Map(productToUpdate, product);

            _unitOfWork.Repository<Core.Domain.Entities.ApplicationEntities.Product>().Update(product);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem updating product"));

            return _mapper.Map<Core.Domain.Entities.ApplicationEntities.Product, ProductToReturnDto>(product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Repository<Core.Domain.Entities.ApplicationEntities.Product>().GetByIdAsync(id);

            foreach (var photo in product.Photos)
            {
                if (photo.Id > 18)
                {
                    _photoService.DeleteFromDisk(photo);
                }
            }

            _unitOfWork.Repository<Core.Domain.Entities.ApplicationEntities.Product>().Delete(product);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem deleting product"));

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ProductToReturnDto>> CreateProduct(ProductCreateDto productToCreate)
        {
            var product = _mapper.Map<ProductCreateDto, Core.Domain.Entities.ApplicationEntities.Product>(productToCreate);

            _unitOfWork.Repository<Core.Domain.Entities.ApplicationEntities.Product>().Add(product);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem creating product"));

            return _mapper.Map<Core.Domain.Entities.ApplicationEntities.Product, ProductToReturnDto>(product);
        }
    }
}