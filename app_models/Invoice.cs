using app_models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BillingManagement.Models
{
    public class Invoice : INotifyPropertyChanged
    {
        private static List<bool> UsedCounter = new List<bool>();
        private static object Lock = new object();

        int InvoiceID;
        readonly DateTime CreationDateTime;
        Customer Customer;
        Double SubTotal
        {
            get => SubTotal;
            set
            {
                FedTax = SubTotal * 0.05;
                ProvTax = SubTotal * 0.09975;
                Total = SubTotal + FedTax + ProvTax;
                OnPropertyChanged();
            }
        }
        Double FedTax;
        Double ProvTax;
        Double Total;


        public Invoice()
        {
            lock (Lock)
            {
                int nextIndex = GetAvailableIndex();
                if (nextIndex == -1)
                {
                    nextIndex = UsedCounter.Count;
                    UsedCounter.Add(true);
                }

                InvoiceID = nextIndex;
            }

            CreationDateTime = DateTime.Now;
        }

        public Invoice(Customer cm)
        {
            lock (Lock)
            {
                int nextIndex = GetAvailableIndex();
                if (nextIndex == -1)
                {
                    nextIndex = UsedCounter.Count;
                    UsedCounter.Add(true);
                }

                InvoiceID = nextIndex;
            }

            CreationDateTime = DateTime.Now;
            Customer = cm;
        }

        public void Dispose()
        {
            lock (Lock)
            {
                UsedCounter[InvoiceID] = false;
            }
        }


        private int GetAvailableIndex()
        {
            for (int i = 0; i < UsedCounter.Count; i++)
            {
                if (UsedCounter[i] == false)
                {
                    return i;
                }
            }

            // Nothing available.
            return -1;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
