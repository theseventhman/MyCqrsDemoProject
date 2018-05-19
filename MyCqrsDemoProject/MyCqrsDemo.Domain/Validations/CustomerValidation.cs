﻿using System;
using FluentValidation;
using MyCqrsDemo.Domain.Commands;

namespace MyCqrsDemo.Domain.Validations
{
    public class CustomerValidation<T> : AbstractValidator<T> where T:CustomerCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateBirthDate()
        {
            RuleFor(c => c.BirthDate)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("The customer must have 18 years or more");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(string.Empty);
        }

        protected  static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}