using DataListRealTimeLoadDemo.Helpers;

namespace DataListRealTimeLoadDemo.DataModels
{
    public sealed partial class EventTypes : ViewModelBase
    {
        public enum ErrorSeverity
        {
            Default,
            Info,
            Warning,
            Error,
            Critical
        }
    }
}
