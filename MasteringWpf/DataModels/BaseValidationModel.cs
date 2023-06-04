using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MasteringWpf.DataModels
{
    public abstract class BaseValidationModel : INotifyPropertyChanged, IDataErrorInfo
    {
        protected string error = string.Empty;

        #region Implementiaiton of IDataErrorInfo

        public virtual string this[string columnName] => error;

        public string Error => error;

        #endregion

        #region implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged(params string[] propertyNames)
        {
            //if (PropertyChanged != null) propertyNames.ForEach(p => PropertyChanged(this, new PropertyChangedEventArgs(p)));
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
