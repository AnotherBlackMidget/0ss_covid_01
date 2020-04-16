using BillingManagement.UI.ViewModels;
using System.Windows;

namespace Inventaire
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainView _window;

        public App()
        {
            CustomerViewModel vm1 = new CustomerViewModel();
            InvoiceViewModel vm2 = new InvoiceViewModel();

            _window = new MainView(vm1, vm2);

            _window.Show();
        }
    }
}
