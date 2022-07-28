using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]

        public IResult AddRental(Rental car)
        {
            _rentalDal.Add(car);
            return new SuccessResult(Messages.RentAlAdded);
        }

        public IResult DeleteRental(Rental car)
        {
            _rentalDal.Delete(car);
            return new SuccessResult(Messages.RentAlDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentAlListed);
        }

       

        public IResult UpdateRental(Rental car)
        {
            _rentalDal.Update(car);
            return new SuccessResult(Messages.RentAlUptaded);
        }
     
    }
}
