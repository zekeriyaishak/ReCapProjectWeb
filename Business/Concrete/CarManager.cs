    using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Transaction;
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
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        
        [ValidationAspect(typeof(CarValidator))]
        //[SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        [TransactionScopeAspect]
        public IResult AddTransactional(Car car)
        {
            Add(car);
            if(car.ModelYear <1980)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }

        //[SecuredOperation("admin,moderator")]
        
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarsDeleted);
        }

        [PerformanceAspect(10)]
        //[SecuredOperation("user,admin,moderator")]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);   
        }

      

        [PerformanceAspect(10)]
        //[SecuredOperation("user,admin,moderator")]
        [CacheAspect]
        public IDataResult<List<Car>> GetByBrand(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.BrandId == brandId));
        }

        [PerformanceAspect(10)]
        //[SecuredOperation("user,admin,moderator")]
        [CacheAspect]
        public IDataResult<List<Car>> GetByColor(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.ColorId==colorId));
        }

        [PerformanceAspect(10)]
        //[SecuredOperation("user,admin,moderator")]
        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id== carId));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(p=>p.CarId == carId));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailByColorAndByBrand(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(p=>p.ColorId == colorId && p.BrandId == brandId));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        //[SecuredOperation("admin,moderator")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUptade);
        }

   


        //Business Rules


    }
}
