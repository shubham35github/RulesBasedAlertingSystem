using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmUtilityLib
{
    public class DelegateCommand : ICommand
    {


        public event EventHandler CanExecuteChanged;
        private Action<Object> _actionMethodAddress;
        private Func<object, bool> _canExceuteMethodAddress;
        public DelegateCommand(Action<object> actionMethodAddress, Func<Object, bool> canExceuteMethodAddress)
        {
            this._actionMethodAddress = actionMethodAddress;
            this._canExceuteMethodAddress = canExceuteMethodAddress;
        }

        public bool CanExecute(object parameter)
        {
            return this._canExceuteMethodAddress.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            this._actionMethodAddress.Invoke(parameter);
        }
    }
}
