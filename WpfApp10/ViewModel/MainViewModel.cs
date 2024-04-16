using WpfApp10.ViewModel.Helpers;
using WpfApp10.Model;
using System;
using WpfApp10.View;
using System.Windows;
using System.Windows.Input;

namespace WpfApp10.ViewModel
{
    internal class MainViewModel : Prompter
    {
        #region Properties
        private Handler _term;
        public Handler Expression
        {
            get { return _term; }
            set
            {
                if (_term != value)
                {
                    _term = value;
                }
                Changed();
            }
        }

        private Visibility _isDataGridVisible;
        public Visibility IsDataGridVisible
        {
            get { return _isDataGridVisible; }
            set
            {
                _isDataGridVisible = value;
                Changed();
            }
        }
        #endregion

        #region Commands
        public Commands AddSymbolCommand { get; set; }
        public Commands GetAnswerCommand { get; set; }
        public Commands TakeAwayTruthTableCommand { get; set; }
        public Commands OpenHelpWindowCommand { get; set; }
        #endregion

        public MainViewModel()
        {
            Expression = new Handler();
            Expression.Text = "a→b";
            AddSymbolCommand = new Commands(AddSymbol);
            GetAnswerCommand = new Commands(_ => GetAnswer());
            TakeAwayTruthTableCommand = new Commands(_ => TakeAwayTruthTable());
            OpenHelpWindowCommand = new Commands(OpenHelpWindow);
        }

        private void AddSymbol(object parameter)
        {
            string symbol = parameter?.ToString();
            Expression.Text += symbol;
        }

        private void GetAnswer()
        {
            Expression.Table = Expression.SetTable();
        }

        private void TakeAwayTruthTable()
        {
            TableWindow truthTableWindow = new TableWindow();

            truthTableWindow.Closed += (sender, e) =>
            {
                IsDataGridVisible = Visibility.Visible;
            };

            IsDataGridVisible = Visibility.Collapsed;

            truthTableWindow.Show();
        }

        private void OpenHelpWindow(object parameter)
        {
            HintWindow helpWindow = new HintWindow();
            helpWindow.Show();
        }
    }
}
