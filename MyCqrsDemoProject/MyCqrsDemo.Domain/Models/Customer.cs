﻿using System;
using MyCqrsDemo.Domain.Core.Models;

namespace MyCqrsDemo.Domain.Models
{
    public class Customer : Entity
    {
        public Customer(string id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;

        }

        protected Customer() { }

        public string Name { get; private set; }

        public string Email{get; private set;}

        public DateTime BirthDate { get; private set; }


    }
}