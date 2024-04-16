using WpfApp10.ViewModel.Helpers;
using WpfApp10.Model;
using System.Windows;
using WpfApp10.View;
using System.Linq;

namespace WpfApp10.ViewModel
{
    internal class TableViewModel : Prompter
    {
        #region Properties
        private Handler _expression;
        public Handler Expression
        {
            get { return _expression; }
            set
            {
                if (_expression != value)
                {
                    _expression = value;
                }
                Changed();
            }
        }
        #endregion
        #region Commands
        public Commands CloseWindowCommand { get; set; }
        #endregion

        public TableViewModel()
        {
            Expression = new Handler();
            CloseWindowCommand = new Commands(_ => CloseWindow());
            Expression = Expression.GetExample();
        }

        private void CloseWindow()
        {
            TableWindow window = Application.Current.Windows.OfType<TableWindow>().FirstOrDefault();
            window?.Close();
        }
    }
}
