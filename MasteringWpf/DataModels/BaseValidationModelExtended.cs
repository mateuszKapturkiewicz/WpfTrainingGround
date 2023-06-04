using MasteringWpf.Extensions;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MasteringWpf.DataModels
{
    public class BaseValidationModelExtended : INotifyPropertyChanged, IDataErrorInfo
    {
        protected ObservableCollection<string> errors = new ObservableCollection<string>();
        protected ObservableCollection<string> externalErrors = new ObservableCollection<string>();

        protected BaseValidationModelExtended()
        {
            ExternalErrors.CollectionChanged += ExternalErrors_CollectionChanged;
        }

        public virtual ObservableCollection<string> Errors => errors;
        public ObservableCollection<string> ExternalErrors => externalErrors;

        public virtual bool HasError => errors != null && Errors.Any();

        #region Implementiaiton of IDataErrorInfo

        public virtual string this[string columnName] => string.Empty;

        public string Error
        {
            get
            {
                if (!HasError) return string.Empty;
                StringBuilder errors = new StringBuilder();
                Errors.ForEach(e => errors.AppendUniqueOnNewLineIfNotEmpty(e));
                return errors.ToString();
            }
        }

        #endregion

        #region implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames)
                {
                    if (propertyName != nameof(HasError)) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(HasError)));
            }
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                if (propertyName != nameof(HasError)) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(HasError)));
            }
        }

        #endregion

        private void ExternalErrors_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => NotifyPropertyChanged(nameof(Errors));

    }
}
