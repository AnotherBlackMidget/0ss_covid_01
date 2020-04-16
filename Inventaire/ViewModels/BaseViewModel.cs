using BillingManagement.Business;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BillingManagement.UI.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public RelayCommand<IClosable> CloseWindowCommand { get; private set; }

        public BaseViewModel()
        {
            this.CloseWindowCommand = new RelayCommand<IClosable>(this.CloseWindow);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CloseWindow(IClosable window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
    }

}
