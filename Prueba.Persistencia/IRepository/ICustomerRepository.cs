﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Persistencia
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();
    }
}
