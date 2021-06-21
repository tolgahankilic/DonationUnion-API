using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDonationService
    {
        IResult Add(Donation donation);
        IResult Update(Donation donation);
        IResult Delete(Donation donation);
        IDataResult<Donation> GetById(int id);
        IDataResult<List<Donation>> GetAll();
    }
}
