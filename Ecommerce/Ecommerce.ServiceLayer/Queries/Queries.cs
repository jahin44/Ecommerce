﻿using Ecommerce.ServiceLayer.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServiceLayer.Queries
{
    public class Queries
    {
        public record GetProductListQuery(): IRequest<List<Product>>;
    }
}