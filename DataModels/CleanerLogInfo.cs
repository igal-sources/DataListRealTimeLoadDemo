using DataListRealTimeLoadDemo.Helpers;
using static DataListRealTimeLoadDemo.DataModels.EventTypes;

namespace DataListRealTimeLoadDemo.DataModels
{
    public class CleanerLogInfo : ViewModelBase
    {
        public string _description;
        public string Description
        {
            get { return _description; }
            set { if (_description == value) return; _description = value; OnPropertyChanged("Description"); }
        }

        public ErrorSeverity _severity;
        public ErrorSeverity Severity
        {
            get { return _severity; }
            set { if (_severity == value) return; _severity = value; OnPropertyChanged("Severity"); }
        }
    }
}
