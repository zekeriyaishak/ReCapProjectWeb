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
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult AddRental(Rental car);
        IResult UpdateRental(Rental car);
        IResult DeleteRental(Rental car);
        IDataResult<List<RentalDetailsDto>> GetRentalDetails();

        IDataResult<Rental> GetById(int rentalId);
     

    }
}
