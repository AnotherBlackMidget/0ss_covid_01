using BillingManagement.Models;
using BillingManagement.UI.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    class MainViewModel : BaseViewModel
    {
		private BaseViewModel _vm;

		public BaseViewModel VM
		{
			get { return _vm; }
			set {
				_vm = value;
				OnPropertyChanged();
			}
		}

		CustomerViewModel customerViewModel;
		InvoiceViewModel invoiceViewModel;

		public RelayComand ChangeViewCommand { get; set; }
		public RelayCommand NewCustomerCommand { get; private set; }
		public RelayCommand NewInvoiceCommand { get; private set; }
		public RelayCommand DisplayInvoiceCommand { get; private set; }
		public RelayCommand DisplayCustomerCommand { get; private set; }


		public MainViewModel()
		{
			ChangeViewCommand = new RelayCommand(ChangeView);

			NewCustomerCommand = new RelayCommand(NewCustomer);
			NewInvoiceCommand = new RelayCommand(NewInvoice, CanExecuteNewInvoice);

			DisplayInvoiceCommand = new RelayCommand(DisplayInvoice);
			DisplayCustomerCommand = new RelayCommand(DisplayCustomer, CanExecuteDisplayCustomer);

			customerViewModel = new CustomerViewModel();
			invoiceViewModel = new InvoiceViewModel(customerViewModel.Customers);

			VM = customerViewModel;

		}

		private void ChangeView(object vm)
		{
			switch ((String) vm)
			{
				case "customers":
					VM = customerViewModel;
					break;
				case "invoices":
					VM = invoiceViewModel;
					break;
			}
		}

		private void NewCustomer(object c)
		{
			Customer customer = new Customer();

			customerViewModel.Customers.Add(customer);

			DisplayCustomer(customer);
		}

		private void NewInvoice(object c)
		{
			var customer = (Customer)c;
			var invoice = new Invoice(customer);

			customer.Invoices.Add(invoice);

			DisplayInvoice(invoice);
		}


		private void DisplayCustomer(object c)
		{
			Customer customer = (Customer)c;

			customerViewModel.SelectedCustomer = customer;
			VM = customerViewModel;

		}

		private bool CanExecuteDisplayCustomer(object c)
		{
			if (c == null) return false;
			else return true;
		}

		private void DisplayInvoice(object i)
		{
			Invoice invoice = (Invoice)i;

			invoiceViewModel.SelectedInvoice = invoice;
			VM = invoiceViewModel;
		}

		private bool CanExecuteDisplayInvoice(object i)
		{
			if (i == null) return false;
			else return true;
		}

		private bool CanExecuteNewInvoice(object c)
		{
			if (c == null) return false;
			else return true;
		}
	}
}
