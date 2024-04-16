using WpfApp10.View;
using WpfApp10.ViewModel.Helpers;
using System.Linq;
using System.Windows;

namespace WpfApp10.ViewModel
{
    internal class HintViewModel : Prompter
    {
        #region Commands
        public Commands CloseWindowCommand { get; set; }
        #endregion

        public HintViewModel()
        {
            CloseWindowCommand = new Commands(_ => CloseWindow());
        }

        private void CloseWindow()
        {
            HintWindow window = Application.Current.Windows.OfType<HintWindow>().FirstOrDefault();
            window?.Close();
        }
    }
}
