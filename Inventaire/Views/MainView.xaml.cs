using app_models;
using BillingManagement.Business;
using BillingManagement.UI.ViewModels;
using System;
using System.Windows;

namespace Inventaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window, IClosable
    {
        CustomerViewModel _vm1;
        InvoiceViewModel _vm2;
        

        public MainView(CustomerViewModel vm1, InvoiceViewModel vm2)
        {
            InitializeComponent();

            _vm1 = vm1;
            _vm2 = vm2;
            DataContext = _vm1;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            viewCustomer.IsEnabled = true;
            viewCustomer.Visibility = Visibility.Visible;
            viewInvoice.IsEnabled = false;
            viewInvoice.Visibility = Visibility.Hidden;
            DataContext = _vm1;
        }

        private void Invoice_Click(object sender, RoutedEventArgs e)
        {
            viewCustomer.IsEnabled = false;
            viewCustomer.Visibility = Visibility.Hidden;
            viewInvoice.IsEnabled = true;
            viewInvoice.Visibility = Visibility.Visible;
            DataContext = _vm2;
        }
    }
}
