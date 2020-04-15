using System;
using System.Collections.Generic;
using System.Text;

namespace BillingManagement.Business
{
    //comment
    interface IDataService<T>
    {
        IEnumerable<T> GetAll();
    }
}
