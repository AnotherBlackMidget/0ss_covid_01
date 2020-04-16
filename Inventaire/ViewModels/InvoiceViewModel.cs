using app_models;
using BillingManagement.Business;
using BillingManagement.Models;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BillingManagement.UI.ViewModels
{
    public class InvoiceViewModel : BaseViewModel
    {
        readonly InvoicesDataService invoicesDataService = new InvoicesDataService();

        private ObservableCollection<Invoice> invoices;
        private Invoice selectedInvoice;


        public RelayCommand CustomerDelete_Click { get; private set; }
        public RelayCommand CustomerNew_Click { get; private set; }
        public RelayCommand<IClosable> Exit_Click { get; private set; }

        public ObservableCollection<Invoice> Invoices
        {
            get => invoices;
            private set
            {
                invoices = value;
                OnPropertyChanged();
            }
        }

        public Invoice SelectedInvoice
        {
            get => selectedInvoice;
            set
            {
                selectedInvoice = value;
                OnPropertyChanged();
            }
        }

        public InvoiceViewModel()
        {
            InitValues();

            this.CustomerDelete_Click = new RelayCommand(this.InvoiceDelete);
            this.CustomerNew_Click = new RelayCommand(this.InvoiceNew);
            this.Exit_Click = new RelayCommand<IClosable>(this.Exit);
        }

        private void InitValues()
        {
            Invoices = new ObservableCollection<Invoice>(invoicesDataService.GetAll());
            Debug.WriteLine(Invoices.Count);
        }



        //-----------------------------------------------------------------------------------------------

        private void InvoiceDelete()
        {
            if (SelectedInvoice != null)
            {
                int currentIndex = Invoices.IndexOf(SelectedInvoice);

                if (currentIndex > 0)
                    currentIndex--;

                Invoices.Remove(SelectedInvoice);

                SelectedInvoice = Invoices[currentIndex];
            }
        }

        private void InvoiceNew()
        {
            
        }

        private void Exit(IClosable window)
        {
            CloseWindow(window);
        }

        
    }
}


