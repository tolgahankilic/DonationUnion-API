using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ConditionManager : IConditionService
    {
        IConditionDal _conditionDal;

        public ConditionManager(IConditionDal conditionDal)
        {
            _conditionDal = conditionDal;
        }

        [ValidationAspect(typeof(ConditionValidator))]
        [SecuredOperation("condition.add,admin")]
        [CacheRemoveAspect("IConditionService.Get")]
        public IResult Add(Condition condition)
        {
            _conditionDal.Add(condition);
            return new SuccessResult(Messages.ConditionAdded);
        }

        [SecuredOperation("condition.delete,admin")]
        [CacheRemoveAspect("IConditionService.Get")]
        public IResult Delete(Condition condition)
        {
            _conditionDal.Delete(condition);
            return new SuccessResult(Messages.ConditionDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Condition>> GetAll()
        {
            return new SuccessDataResult<List<Condition>>(_conditionDal.GetAll(), Messages.ConditionListed);
        }

        [CacheAspect]
        public IDataResult<Condition> GetById(int id)
        {
            return new SuccessDataResult<Condition>(_conditionDal.Get(b => b.ConditionId == id));
        }

        [SecuredOperation("condition.update,admin")]
        [CacheRemoveAspect("IConditionService.Get")]
        public IResult Update(Condition condition)
        {
            _conditionDal.Update(condition);
            return new SuccessResult(Messages.ConditionUpdated);
        }
    }
}
