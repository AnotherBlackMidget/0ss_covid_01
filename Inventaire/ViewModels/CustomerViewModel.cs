using app_models;
using BillingManagement.Business;
using BillingManagement.UI.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Windows.Controls;

namespace BillingManagement.UI.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        readonly CustomersDataService customersDataService = new CustomersDataService();

        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;
        private ObservableCollection<ContactInfo> contactInfos;


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

        public ObservableCollection<ContactInfo> ContactInfos
        {
            get => selectedCustomer.ContactInfos;
            private set
            {
                contactInfos = value;
                OnPropertyChanged();
            }
        }

        public CustomerViewModel()
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

        //-----------------------------------------------------------------------------------------------

        private void CustomerDelete()
        {
            if(SelectedCustomer != null)
            {
                int currentIndex = Customers.IndexOf(SelectedCustomer);

                if (currentIndex > 0)
                    currentIndex--;

                Customers.Remove(SelectedCustomer);

                SelectedCustomer = Customers[currentIndex];
            }       
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
