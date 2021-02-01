using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketAPI.Models;

namespace SupermarketAPI.Services.Communication
{
    public class CategoryResponse : BaseResponse
    {
        public Category Category { get; private set; }

        private CategoryResponse(bool sucess, String message, Category category) : base(sucess, message)
        {
            Category = category;
        }

        //Creates success response
        public CategoryResponse(Category category) : this(true, string.Empty, category)
        {
        }

        //Creates an error response
        public CategoryResponse(string message) : this(false, message, null)
        {
        }
    }
}
