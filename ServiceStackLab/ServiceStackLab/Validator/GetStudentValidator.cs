using ServiceStack;
using ServiceStack.FluentValidation;
using ServiceStackLab.Common;
using ServiceStackLab.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStackLab.Validator
{
    public class GetStudentValidator : AbstractValidator<GetStudentRequest>
    {
        public GetStudentValidator()
        {
            RuleSet(ApplyTo.Get, () => 
            {
                RuleFor(i => i.Id).NotNull().NotEmpty().WithMessage(Resources.StudentIdIsNULL);
            });
        }
    }
}