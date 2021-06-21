using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class DonationValidator : AbstractValidator<Donation>
    {
        public DonationValidator()
        {
            RuleFor(d => d.GiverId).NotEmpty();
        }
    }
}
