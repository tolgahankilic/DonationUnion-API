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
    public class DonationManager : IDonationService
    {
        IDonationDal _donationDal;

        public DonationManager(IDonationDal donationDal)
        {
            _donationDal = donationDal;
        }

        [ValidationAspect(typeof(DonationValidator))]
        [SecuredOperation("donation.add,admin")]
        [CacheRemoveAspect("IDonationService.Get")]
        public IResult Add(Donation donation)
        {
            _donationDal.Add(donation);
            return new SuccessResult(Messages.DonationAdded);
        }

        [SecuredOperation("donation.delete,admin")]
        [CacheRemoveAspect("IDonationService.Get")]
        public IResult Delete(Donation donation)
        {
            _donationDal.Delete(donation);
            return new SuccessResult(Messages.DonationDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Donation>> GetAll()
        {
            return new SuccessDataResult<List<Donation>>(_donationDal.GetAll(), Messages.DonationListed);
        }

        [CacheAspect]
        public IDataResult<Donation> GetById(int id)
        {
            return new SuccessDataResult<Donation>(_donationDal.Get(b => b.DonationId == id));
        }

        [SecuredOperation("donation.update,admin")]
        [CacheRemoveAspect("IDonationService.Get")]
        public IResult Update(Donation donation)
        {
            _donationDal.Update(donation);
            return new SuccessResult(Messages.DonationUpdated);
        }
    }
}
