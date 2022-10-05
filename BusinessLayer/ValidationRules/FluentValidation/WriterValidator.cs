using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(p => p.WriterName).NotEmpty().WithMessage("Writer adını boş geçemezsiniz");
            RuleFor(p => p.WriterAbout).NotEmpty().WithMessage("Açıklamayı boş geçemezsiniz");
            RuleFor(p => p.WriterName).MinimumLength(2).WithMessage("En az 2 karekter girişi yapın");
            RuleFor(p => p.WriterSurName).NotEmpty().WithMessage("Soyadını boş geçemezsiniz!");
            RuleFor(p => p.WriterSurName).MaximumLength(20).WithMessage("Maksimum 20 karekter olmalı!");
            RuleFor(p => p.WriterPassword).NotEmpty().WithMessage("Password  boş geçemezsiniz");
        }
    }
}
