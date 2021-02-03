using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketAPI.Models;

namespace SupermarketAPI.Services.Communication
{
    public class ProductResponse : BaseResponse
    {
        public Products Product { get; private set; }

        private ProductResponse(bool success, String message, Products product) : base(success, message)
        {
            Product = product;
        }

        //Create succes response
        public ProductResponse(Products product) : this(true, string.Empty, product)
        {
        }

        //Create an error response
        public ProductResponse(string message) : this(false, message, null)
        {
        }
    }
}
