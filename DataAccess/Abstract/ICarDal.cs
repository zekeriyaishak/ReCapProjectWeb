using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailsDto> GetCarDetails();
        List<CarDetailsDto> GetCarsByBrandId(int brandId);
        List<CarDetailsDto> GetCarsByColorId(int colorId);
        List<CarDetailsDto> GetCarDetailsByColorAndByBrand(int colorId, int brandId);
        List<CarDetailsDto> GetCarDetailsByCarId(int carId);
    }
}
