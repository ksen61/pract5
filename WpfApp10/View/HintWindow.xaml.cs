using WpfApp10.ViewModel;
using System.Windows;

namespace WpfApp10.View
{
    /// <summary>
    /// Логика взаимодействия для HintWindow.xaml
    /// </summary>
    public partial class HintWindow : Window
    {
        public HintWindow()
        {
            InitializeComponent();
            DataContext = new HintViewModel();
        }
    }
}
 