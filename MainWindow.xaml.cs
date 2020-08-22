using EventTypesDemo.ViewModels;
using System.Windows;

namespace DataListRealTimeLoadDemo
{
    public partial class MainWindow : Window
    {
        private DataListRealTimeViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new DataListRealTimeViewModel();
            DataContext = _viewModel;
        }
    }
}
