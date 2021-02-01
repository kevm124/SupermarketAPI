using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Repositories
{
    public interface IUnitofWork
    {
        Task CompleteAsyc();
    }
}
