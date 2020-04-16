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
        CustomerViewModel _vm;
        

        public MainView(CustomerViewModel vm)
        {
            InitializeComponent();

            _vm = vm;
            DataContext = _vm;
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
        }

        private void Invoice_Click(object sender, RoutedEventArgs e)
        {
            viewCustomer.IsEnabled = false;
            viewCustomer.Visibility = Visibility.Hidden;
            viewInvoice.IsEnabled = true;
            viewInvoice.Visibility = Visibility.Visible;
        }
    }
}
