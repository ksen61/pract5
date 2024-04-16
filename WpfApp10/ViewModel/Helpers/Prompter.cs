using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp10.ViewModel.Helpers
{
    internal class Prompter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Changed([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}