using BillingManagement.Business;
using BillingManagement.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace BillingManagement.UI.ViewModels
{
    public class CustomersViewModel : BaseViewModel
    {
        CustomersDataService customersDataService = new CustomersDataService();

        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;

        public RelayCommand CustomerDelete_Click { get; private set; }
        public RelayCommand CustomerNew_Click { get; private set; }
        public RelayCommand<IClosable> Exit_Click { get; private set; }

        public ObservableCollection<Customer> Customers
        {
            get => customers;
            private set
            {
                customers = value;
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public CustomersViewModel()
        {
            InitValues();

            this.CustomerDelete_Click = new RelayCommand(this.CustomerDelete);
            this.CustomerNew_Click = new RelayCommand(this.CustomerNew);
            this.Exit_Click = new RelayCommand<IClosable>(this.Exit);
        }

        private void InitValues()
        {
            Customers = new ObservableCollection<Customer>(customersDataService.GetAll());
            Debug.WriteLine(Customers.Count);
        }

        private void CustomerDelete()
        {
            int currentIndex = Customers.IndexOf(SelectedCustomer);

            if (currentIndex > 0)
                currentIndex--;

            Customers.Remove(SelectedCustomer);

            SelectedCustomer = Customers[currentIndex];
        }

        private void CustomerNew()
        { 
            Customer temp = new Customer() { Name = "Undefined", LastName = "Undefined" };
            Customers.Add(temp);
            SelectedCustomer = temp;  
        }

        private void Exit(IClosable window)
        {
            CloseWindow(window);
        }


    }
}
