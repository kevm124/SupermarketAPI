using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketAPI.Models;

namespace SupermarketAPI.Services.Communication
{
    public class SaveCategoryResponse : BaseResponse
    {
        public Category Category { get; private set; }

        private SaveCategoryResponse(bool sucess, String message, Category category) : base(sucess, message)
        {
            Category = category;
        }

        //Creates success response
        public SaveCategoryResponse(Category category) : this(true, string.Empty, category)
        {
        }

        //Creates an error response
        public SaveCategoryResponse(string message) : this(false, message, null)
        {
        }
    }
}
