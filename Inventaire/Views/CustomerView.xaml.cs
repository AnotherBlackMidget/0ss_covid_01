using app_models;
using BillingManagement.Business;
using BillingManagement.UI.ViewModels;
using Inventaire;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BillingManagement.UI.Views
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
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
    }
}
