using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        [ValidationAspect(typeof(ProductImageValidator))]
        [SecuredOperation("carimage.add,admin,user")]
        [CacheRemoveAspect("IProductImageService.Get")]
        public IResult Add(ProductImage productImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimit(productImage.ProductId));

            if (result != null)
            {
                return result;
            }
            var imageResult = FileHelper.Add(file);
            productImage.ImagePath = imageResult.Message;
            productImage.Date = DateTime.Now;
            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.ProductImageAdded);
        }

        [ValidationAspect(typeof(ProductImageValidator))]
        [SecuredOperation("carimage.update,admin,user")]
        [CacheRemoveAspect("IProductImageService.Get")]
        public IResult Update(ProductImage productImage, IFormFile file)
        {
            var isImage = _productImageDal.Get(c => c.ProductId == productImage.ProductId);

            var updatedFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            productImage.ImagePath = updatedFile.Message;
            _productImageDal.Update(productImage);
            return new SuccessResult(Messages.ProductImageUpdated);
        }

        [ValidationAspect(typeof(ProductImageValidator))]
        [SecuredOperation("carimage.delete,admin,user")]
        [CacheRemoveAspect("IProductImageService.Get")]
        public IResult Delete(ProductImage productImage)
        {
            FileHelper.Delete(productImage.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult(Messages.ProductImageDeleted);
        }

        [CacheAspect]
        public IDataResult<ProductImage> Get(int Id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p => p.Id == Id));
        }

        [CacheAspect]
        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<ProductImage>> GetImagesByProductId(int ProductId)
        {
            var result = _productImageDal.GetAll(c => c.ProductId == ProductId).Any();
            if (!result)
            {
                List<ProductImage> carimage = new List<ProductImage>();
                //carimage.Add(new ProductImage { ProductId = ProductId, ImagePath = @"\Images\default.jpg" });
                carimage.Add(new ProductImage { ProductId = ProductId, ImagePath = "images/default.jpg" });
                return new SuccessDataResult<List<ProductImage>>(carimage);
            }
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(p => p.ProductId == ProductId));
        }

        private IResult CheckIfImageLimit(int carId)
        {
            var productImageCount = _productImageDal.GetAll(p => p.ProductId == carId).Count;
            if (productImageCount >= 5)
            {
                return new ErrorResult(Messages.ImageAddingLimit);
            }

            return new SuccessResult();
        }
    }
}
