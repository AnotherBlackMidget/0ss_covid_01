using app_models;
using BillingManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BillingManagement.Business 
{
    public class InvoicesDataService : IDataService<Invoice>
    {
        readonly List<Invoice> invoices;

        public InvoicesDataService()
        {
            invoices = new List<Invoice>()
            {
                new Invoice() {},
                new Invoice() {},
                new Invoice() {},
                new Invoice() {},
                new Invoice() {},
                new Invoice() {},
                new Invoice() {},
                new Invoice() {},
                new Invoice() {},
                new Invoice() {},
                new Invoice() {},
                new Invoice() {},
                new Invoice() {},
                new Invoice() {},
                new Invoice() {},
                new Invoice() {}
            };
        }

        public IEnumerable<Invoice> GetAll()
        {
            foreach (Invoice c in invoices)
            {
                yield return c;
            }
        }
    }
}
