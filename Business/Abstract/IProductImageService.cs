using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IDataResult<List<ProductImage>> GetAll();
        IDataResult<ProductImage> Get(int id);
        IResult Add(ProductImage productImage, IFormFile file);
        IResult Update(ProductImage productImage, IFormFile file);
        IResult Delete(ProductImage productImage);
        IDataResult<List<ProductImage>> GetImagesByProductId(int id);
    }
}
