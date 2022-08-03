using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByBrand(int brandId);
        IDataResult<List<Car>> GetByColor(int colorId);

        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<CarDetailsDto>> GetCarDetailByColorAndByBrand(int colorId, int brandId);
        
        IDataResult<List<CarDetailsDto>> GetCarDetailByCarId(int carId);


        IDataResult<Car> GetById(int carId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

        IResult AddTransactional(Car car);
        
         
    }
}
