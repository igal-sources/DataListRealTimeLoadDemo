using DataListRealTimeLoadDemo.DataModels;
using DataListRealTimeLoadDemo.Helpers;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace EventTypesDemo.ViewModels
{
    public class DataListRealTimeViewModel : ViewModelBase
    {
        #region Properties

        private ObservableCollection<CleanerLogInfo> _processResults;
        public ObservableCollection<CleanerLogInfo> ProcessResults
        {
            get { return _processResults; }
            set { if (_processResults == value) return; _processResults = value; OnPropertyChanged("ProcessResults"); }
        }

        private CleanerLogInfo _selectedCleanerLogInfo;
        public CleanerLogInfo SelectedCleanerLogInfo
        {
            get { return _selectedCleanerLogInfo; }
            set { if (_selectedCleanerLogInfo == value) return; _selectedCleanerLogInfo = value; OnPropertyChanged("SelectedCleanerLogInfo"); }
        }

        #endregion Properties

        public DataListRealTimeViewModel()
        {
            ProcessResults = new ObservableCollection<CleanerLogInfo>();
        }

        #region Commands

        private RelayCommand<object> _addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand<object>(x => AddCleanerLogInfo());
                }

                return _addCommand;
            }
        }

        private RelayCommand<object> _removeCommand;

        public ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new RelayCommand<object>(x => RemoveCleanerLogInfo());
                }

                return _removeCommand;
            }
        }

        private RelayCommand<object> _realTimeLoadCommand;

        public ICommand RealTimeLoadCommand
        {
            get
            {
                if (_realTimeLoadCommand == null)
                {
                    _realTimeLoadCommand = new RelayCommand<object>(x => RealTimeLoad());
                }

                return _realTimeLoadCommand;
            }
        }

        private ICommand _selectItemCommand;

        public ICommand SelectItemCommand
        {
            get
            {
                if (_selectItemCommand == null)
                {
                    _selectItemCommand = new RelayCommand<CleanerLogInfo>(x => _selectedCleanerLogInfo = x);
                }

                return _selectItemCommand;
            }
        }

        #endregion Commands

        private void AddCleanerLogInfo(string description = "New Description")
        {
            var newLog = new CleanerLogInfo
            {
                Description = description,
                Severity = EventTypes.ErrorSeverity.Error
            };

            ProcessResults.Add(newLog);
        }

        private void RemoveCleanerLogInfo()
        {
        }

        private void RealTimeLoad()
        {
            for (int i = 0; i < 150; i++)
            {
                Application.Current.Dispatcher.Invoke(
                    DispatcherPriority.Background, new ThreadStart(
                        delegate 
                        { 
                            AddCleanerLogInfo($"Description {i}");
                            Thread.Sleep(100);
                        }));
            }
        }
    }
}