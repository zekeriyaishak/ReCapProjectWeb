using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                var result = from ca in rentCarContext.CARS
                             join b in rentCarContext.BRANDS
                             on ca.BrandId equals b.BrandId
                             join re in rentCarContext.RENTALS
                             on ca.Id equals re.Id
                             join co in rentCarContext.COLORS
                             on ca.ColorId equals co.Id
                             from u in rentCarContext.USERS
                             join cu in rentCarContext.CUSTOMERS
                             on u.Id equals cu.UserId
                             select new RentalDetailsDto
                             {
                                 Id = ca.Id,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 ModelName = ca.Description,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                                 UserName = u.FirstName,
                                 UserLastname = u.LastName
                                 
                             };
                return result.ToList();
            }
        }

     
    }
    
}

