using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CreditCardManager: ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard card)
        {
            _creditCardDal.Add(card);
            return new SuccessResult("Card Added");
        }

        public IResult Delete(CreditCard card)
        {
            _creditCardDal.Delete(card);
            return new SuccessResult("Card Deleted");
        }
        public IResult Update(CreditCard card)
        {
            _creditCardDal.Update(card);
            return new SuccessResult("Card updated");
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<CreditCard> GetByCardId(int cardId)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.CardId == cardId));
        }
    }
}
