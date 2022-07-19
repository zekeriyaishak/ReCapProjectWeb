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
                             on c.ColorId equals k.ColorId
                             select new CarDetailsDto { CarId = c.Id, BrandName = b.BrandName,
                             CarName= c.Description,ColorName=k.ColorName,DailyPrice=c.DailyPrice};
                return result.ToList();
            }
        }
    }
}
