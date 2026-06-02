using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_11_LABA.model
{
    internal class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action _execute;


        public RelayCommand(Action action) => _execute = action;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _execute();
        
    }
}
