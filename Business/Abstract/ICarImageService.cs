using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IResult AddRental(CarImage carImage);
        IResult UpdateRental(CarImage carImage);
        IResult DeleteRental(CarImage carImage);
    }
}
