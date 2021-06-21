using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
        IDataResult<Category> GetById(int id);
        IDataResult<List<Category>> GetAll();
    }
}
