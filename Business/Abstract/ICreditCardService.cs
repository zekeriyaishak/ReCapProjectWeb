using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IResult Add(CreditCard card);
        IResult Delete(CreditCard card);
        IResult Update(CreditCard card);

        IDataResult<List<CreditCard>> GetAll();
        IDataResult<CreditCard> GetByCardId(int cardId);
    }
}
