using app_models;
using BillingManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingManagement.Business 
{
    class InvoicesDataService : IDataService<Invoice>
    {
        readonly List<Invoice> invoices;


        public IEnumerable<Invoice> GetAll()
        {
            foreach (Invoice c in invoices)
            {
                yield return c;
            }
        }
    }
}
