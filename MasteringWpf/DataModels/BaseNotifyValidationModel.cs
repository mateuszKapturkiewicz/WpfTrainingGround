using MasteringWpf.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MasteringWpf.DataModels
{
    public abstract class BaseNotifyValidationModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> allPropertyErrors = new Dictionary<string, List<string>>();
        protected Dictionary<string, List<string>> AllPropertyErrors => allPropertyErrors;

        public abstract IEnumerable<string> this[string propertyName] { get; }

        public void NotifyPropertyChangedAndValidate(params string[] propertyNames)
        {
            foreach (string propertyName in propertyNames) NotifyPropertyChangedAndValidate(propertyName);
        }

        public void NotifyPropertyChangedAndValidate([CallerMemberName] string propertyName = "")
        {
            NotifyPropertyChanged(propertyName);
            Validate(propertyName, this[propertyName]);
        }

        public void Validate(string propertyName, IEnumerable<string> errors)
        {
            if (errors.Any()) errors.ForEach(e => AddValidationError(propertyName, e));
            else if (AllPropertyErrors.ContainsKey(propertyName)) RemoveValidationError(propertyName);
        }

        private void AddValidationError(string propertyName, string error)
        {
            if (AllPropertyErrors.ContainsKey(propertyName))
            {
                if (!AllPropertyErrors[propertyName].Contains(error))
                {
                    AllPropertyErrors[propertyName].Add(error);
                    OnErrorsChanged(propertyName);
                }
            }
            else
            {
                AllPropertyErrors.Add(propertyName, new List<string>() { error });
                OnErrorsChanged(propertyName);
            }
        }

        private void RemoveValidationError(string propertyName)
        {
            AllPropertyErrors.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged != null) propertyNames.ForEach(p => PropertyChanged(this, new PropertyChangedEventArgs(p)));
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion



        #region Implementation of INotifyDataErrorInfo

        public bool HasErrors => allPropertyErrors.Any(p => p.Value != null && p.Value.Any());

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public virtual ObservableCollection<string> Errors
        {
            get
            {
                 var errors = allPropertyErrors.Select(k => k.Key).ToList();

                return new ObservableCollection<string>(errors);

            }
        }



        public IEnumerable GetErrors(string propertyName)
        {
            List<string> propertyErrors = new List<string>();
            if (string.IsNullOrEmpty(propertyName)) return propertyErrors;
            allPropertyErrors.TryGetValue(propertyName, out propertyErrors);
            return propertyErrors;
        }

        public void OnErrorsChanged(string propertyName) => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        #endregion

    }
}
