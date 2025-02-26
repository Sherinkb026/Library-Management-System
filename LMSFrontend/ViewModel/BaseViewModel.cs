using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace LMSFrontend.ViewModel
{
    public class BaseViewModel<T> : INotifyPropertyChanged where T : class
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Dictionary<string, Action> _propertyChangedActions = new();


        protected bool SetProperty<U>(ref U field, U value, [CallerMemberName] string propertyName = "")
        {
            if(EqualityComparer<U>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;

        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
            if (_propertyChangedActions.TryGetValue(propertyName, out var action))
            {
                action?.Invoke();
            }
        }


        public void RegisterPropertyChangedAction(string propertyName, Action action)
        {
            if (!_propertyChangedActions.ContainsKey(propertyName))
            {
                _propertyChangedActions[propertyName] = action;
            }
        }
    }
}
