using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(2).NotEmpty().WithMessage(Messages.RentCarNotDescription);
            RuleFor(c => c.DailyPrice).GreaterThan(0).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty(); 
            RuleFor(c=> c.ModelYear).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            
        }
    }
}
