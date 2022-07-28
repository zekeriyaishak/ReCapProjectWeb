using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                var result = from c in rentCarContext.CARS
                             join b in rentCarContext.BRANDS
                             on c.BrandId equals b.BrandId
                             join k in rentCarContext.COLORS
                             on c.ColorId equals k.Id
                             select new CarDetailsDto { CarId = c.Id, BrandName = b.BrandName,
                             CarName= c.Description,ColorName=k.ColorName,DailyPrice=c.DailyPrice};
                return result.ToList();
            }
        }
        public List<CarDetailsDto> GetCarDetailsByCarId(int carId)
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                var result = from c in rentCarContext.CARS
                             join b in rentCarContext.BRANDS
                                 on c.BrandId equals b.BrandId
                             join co in rentCarContext.COLORS
                                 on c.ColorId equals co.Id
                             where c.Id == carId
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 BrandId = b.BrandId,
                                 ColorId = co.Id,
                                 Description = c.Description,
                                 ImagePath = (from m in rentCarContext.CARIMAGES where m.CarId == c.Id select m.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailsDto> GetCarDetailsByColorAndByBrand(int colorId, int brandId)
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                var result = from c in rentCarContext.CARS
                             join b in rentCarContext.BRANDS
                                 on c.BrandId equals b.BrandId
                             join co in rentCarContext.COLORS
                                 on c.ColorId equals co.Id
                             where co.Id == colorId & b.BrandId == brandId
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 BrandId = b.BrandId,
                                 ColorId = co.Id,
                                 Description = c.Description,
                                 ImagePath = (from m in rentCarContext.CARIMAGES where m.CarId == c.Id select m.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }



        public List<CarDetailsDto> GetCarsByBrandId(int BrandId)
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                var result = from c in rentCarContext.CARS
                             join b in rentCarContext.BRANDS
                                 on c.BrandId equals b.BrandId
                             join co in rentCarContext.COLORS
                                 on c.ColorId equals co.Id
                             where b.BrandId == BrandId
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 BrandId = b.BrandId,
                                 ColorId = co.Id,
                                 Description = c.Description,
                                 ImagePath = (from m in rentCarContext.CARIMAGES where m.CarId == c.Id select m.ImagePath).FirstOrDefault()
                             };

                return result.ToList();
            }
        }
        public List<CarDetailsDto> GetCarsByColorId(int ColorId)
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                var result = from c in rentCarContext.CARS
                             join b in rentCarContext.BRANDS
                                 on c.BrandId equals b.BrandId
                             join co in rentCarContext.COLORS
                                 on c.ColorId equals co.Id
                             where c.ColorId == ColorId
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 BrandId = b.BrandId,
                                 ColorId = co.Id,
                                 Description = c.Description,
                                 ImagePath = (from m in rentCarContext.CARIMAGES where m.CarId == c.Id select m.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
    }
}
