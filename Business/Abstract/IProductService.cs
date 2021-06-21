using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
        IDataResult<Product> GetById(int id);
        IDataResult<List<Product>> GetAll();
    }
}
