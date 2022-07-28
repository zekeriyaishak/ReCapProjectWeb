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
      

        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                var result = from c in rentCarContext.CARS
                             join b in rentCarContext.BRANDS
                             on c.BrandId equals b.BrandId
                             join k in rentCarContext.COLORS
                             on c.ColorId equals k.Id
                             select new CarDetailsDto { CarId = c.Id,ColorId =k.Id ,BrandId =b.BrandId ,BrandName = b.BrandName,
                             CarName= c.Description,ColorName=k.ColorName,DailyPrice=c.DailyPrice, ModelYear = c.ModelYear,
                             CarImages = (from i in rentCarContext.CARIMAGES where i.CarId == c.Id select i).ToList(),
                             };
                return result.ToList();
            }
        }

       

    }
}
