using WpfApp10.ViewModel;
using System.ComponentModel;
using System.Windows;

namespace WpfApp10.View
{
    /// <summary>
    /// Логика взаимодействия для TableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        public TableWindow()
        {
            InitializeComponent();
            DataContext = new TableViewModel();
        }
    }
}
