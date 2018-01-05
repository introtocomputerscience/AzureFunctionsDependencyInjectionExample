using AzureFunctions.Autofac.Configuration;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionExample.Models;
using DependencyInjectionExample.Interfaces;

namespace DependencyInjectionExample.Configs
{
    public class AutofacConfig
    {
        public AutofacConfig()
        {
            DependencyInjection.Initialize(builder =>
            {
                builder.RegisterType<Dog>().As<IAnimal>();
            });
        }
    }
}
