using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class SessionValidator:AbstractValidator<Session>
    {
        public SessionValidator()
        {
            RuleFor(s => s.SessionTime).NotNull();
            RuleFor(s => s.SessionTime).GreaterThan(DateTime.Today).WithMessage("İleri bir tarih seçilmeli");
        }
    }
}
