using Business.Abstract;
using Business.Constants;
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
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            _paymentDal.Add(creditCard);
            return new SuccessResult(Messages.CreditCardAdded);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _paymentDal.Delete(creditCard);
            return new SuccessResult(Messages.CreditCardDeleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_paymentDal.GetAll(),Messages.CreditCardListed);
        }

        public IDataResult<CreditCard> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<CreditCard>(_paymentDal.Get(p => p.CardNumber == cardNumber));
        }

        public IDataResult<CreditCard> GetByCustomerId(int id)
        {
            return new SuccessDataResult<CreditCard>(_paymentDal.Get(p => p.CustomerId == id));
        }

        public IDataResult<CreditCard> GetById(int id)
        {
            return new SuccessDataResult<CreditCard>(_paymentDal.Get(p => p.Id == id));
        }

        public IResult Update(CreditCard creditCard)
        {
            _paymentDal.Update(creditCard);
            return new SuccessResult(Messages.CreditCardUptaded);
        }
    }
}
