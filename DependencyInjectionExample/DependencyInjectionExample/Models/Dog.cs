﻿using DependencyInjectionExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample.Models
{
    public class Dog : IAnimal
    {
        public string MakeNoise()
        {
            return "Bark!";
        }
    }
}
