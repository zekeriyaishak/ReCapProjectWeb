using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        ICarDal _carDal;

        public RentalManager(IRentalDal rentalDal, ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
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

        public IDataResult<List<RentalDetailsDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetails());
        }


        public IResult UpdateRental(Rental car)
        {
            _rentalDal.Update(car);
            return new SuccessResult(Messages.RentAlUptaded);
        }
        public IDataResult<List<Rental>> GetById(int rentalId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.Id == rentalId));
        }

        public IResult IsCarAvaible(int carId)
        {
            IResult result = BusinessRules.Run(IsCarAvaibleForRent(carId));
            if (result != null)
            {
                return new ErrorResult("Araç belirtilen aralıkta uygun değil.");
            }
            return new SuccessResult("Belirtilen tarihte araç durumu müsait");
        }

        public List<int> CalculateTotalPrice(DateTime rentDate, DateTime returnDate, int carId)
        {
            List<int> totalAmount = new List<int>();
            var dateDifference = (returnDate - rentDate).Days;
            //var datesOfDifference = dateDifference.Days;
            var dailyCarPrice = decimal.ToInt32(_carDal.Get(c => c.Id == carId).DailyPrice);

            var totalPrice = dateDifference * dailyCarPrice;

            totalAmount.Add(dateDifference);
            totalAmount.Add(totalPrice);


            return totalAmount;
        }



        //Business Rules
        private IResult IsCarAvaibleForRent(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

    }
}
