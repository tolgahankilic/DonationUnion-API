using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        [SecuredOperation("product.add,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        [SecuredOperation("product.delete,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(b => b.ProductId == id));
        }

        [SecuredOperation("product.update,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product Product)
        {
            _productDal.Update(Product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
